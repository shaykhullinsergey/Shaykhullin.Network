using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Network.Core
{
	internal class Connection : IConnection
	{
		private readonly ICommunicator communicator;
		private readonly IMessageComposer messageComposer;
		private readonly IPacketsComposer packetsComposer;
		private readonly IEventRaiser eventRaiser;

		public Connection(
			ICommunicator communicator,
			IMessageComposer messageComposer,
			IPacketsComposer packetsComposer,
			IEventRaiser eventRaiser)
		{
			this.communicator = communicator;
			this.messageComposer = messageComposer;
			this.packetsComposer = packetsComposer;
			this.eventRaiser = eventRaiser;
			Task.Run(() => ReceiveLoop().Wait());
		}

		public ISendBuilder Send<TData>(TData data)
		{
			return new SendBuilder(data, messageComposer, packetsComposer, communicator);
		}

		private async Task ReceiveLoop()
		{
			var messages = new Dictionary<int, IList<IPacket>>();

			while (true)
			{
				var packet = await communicator.Receive();

				if (messages.TryGetValue(packet.Id, out var packets))
				{
					packets.Add(packet);
				}
				else
				{
					packets = new List<IPacket> { packet };
					messages.Add(packet.Id, packets);
				}

				var end = packets.FirstOrDefault(x => x.End);
				if (end == null || end.Order != packets.Count)
				{
					continue;
				}

				var message = packetsComposer.GetMessage(packets);
				var payload = messageComposer.GetPayload(message);

				await eventRaiser.Raise(payload);
				messages.Remove(end.Id);
			}
		}
	}
}
