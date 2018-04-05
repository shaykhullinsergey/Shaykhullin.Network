using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Sockets;
using System;

namespace Network.Core
{
  public class Connection : IConnection
  {
    private readonly Communicator communicator;

    public Connection(Socket socket)
    {
      communicator = new Communicator(socket);
			Task.Run(() => ReceiveLoop().Wait());
    }

    public async Task Send(IPayload payload)
    {
      var message = new MessageComposer().GetMessage(payload);
			var packets = await new PacketsComposer().GetPackets(message);

      foreach (var packet in packets)
      {
        await communicator.Send(packet);
				await Task.Delay(1);
      }
    }

    private async Task ReceiveLoop()
    {
      var messages = new Dictionary<int, IList<IPacket>>();

      while (true)
      {
        var packet = await communicator.Receive();
        if(messages.TryGetValue(packet.Id, out var packets))
        {
          packets.Add(packet);
        }
        else
        {
          packets = new List<IPacket> {packet};
          messages.Add(packet.Id, packets);
        }

				var end = packets.FirstOrDefault(x => x.End);

	      if (end == null || end.Order != packets.Count)
	      {
		      continue;
	      }

	      var message = new PacketsComposer().GetMessage(packets);
	      var payload = new MessageComposer().GetPayload(message);

	      await new EventRaiser().Raise(payload);
	      messages.Remove(end.Id);
      }
    }
  }


	public class EventRaiser
	{
		public async Task Raise(IPayload payload)
		{
			var handlers = new Container().GetHandlers(payload.Event);
			await Console.Out.WriteLineAsync(payload.Object.ToString());
		}
	}
}
