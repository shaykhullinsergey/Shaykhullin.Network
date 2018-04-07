using System.Threading.Tasks;

namespace Network.Core
{
	internal class SendBuilder : ISendBuilder
	{
		private readonly object data;
		private readonly ICommunicator communicator;
		private readonly IMessageComposer messageComposer;
		private readonly IPacketsComposer packetsComposer;

		public SendBuilder(object data, 
			IMessageComposer messageComposer, 
			IPacketsComposer packetsComposer, 
			ICommunicator communicator)
		{
			this.data = data;
			this.communicator = communicator;
			this.messageComposer = messageComposer;
			this.packetsComposer = packetsComposer;
		}

		public async Task In<TEvent>() 
			where TEvent : IEvent<object>
		{
			var payload = new Payload { Event = typeof(TEvent), Object = data };
			var message = messageComposer.GetMessage(payload);
			var packets = await packetsComposer.GetPackets(message);

			foreach (var packet in packets)
			{
				await communicator.Send(packet);
				await Task.Delay(1);
			}
		}
	}
}
