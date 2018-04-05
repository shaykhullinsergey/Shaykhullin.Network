using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Sockets;
using System;

namespace Network.Core
{
  public class Connection : IConnection
  {
    private Communicator communicator;

    public Connection(Socket socket)
    {
      communicator = new Communicator(socket);
			Task.Run(() => ReceiveLoop().Wait());
    }

    public async Task Send(Payload payload)
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
      var messages = new Dictionary<int, List<Packet>>();

      while (true)
      {
        var packet = await communicator.Receive();
        if(messages.TryGetValue(packet.Id, out var packets))
        {
          packets.Add(packet);
        }
        else
        {
          packets = new List<Packet> {packet};
          messages.Add(packet.Id, packets);
        }

				var end = packets.FirstOrDefault(x => x.End);

        if(end != null && end.Order == packets.Count)
        {
          var message = new PacketsComposer().GetMessage(packets);
          var payload = new MessageComposer().GetPayload(message);

					await new EventRaiser().Raise(payload);
					messages.Remove(end.Id);
				}
      }
    }
  }


	public class EventRaiser
	{
		public async Task Raise(Payload payload)
		{
			var handlers = new Container().GetHandlers(payload.Event);
			await Console.Out.WriteLineAsync(payload.Object.ToString());
		}
	}
}
