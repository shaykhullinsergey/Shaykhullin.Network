using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DependencyInjection;

namespace Network.Core
{
	internal class Connection : IConnection
	{
		private readonly IContainer container;

		public Connection(IContainerConfig config)
		{
			config.Register<IContainer>()
				.ImplementedBy(c => c)
				.As<Singleton>();
			
			config.Register<IPacketsComposer>()
				.ImplementedBy<PacketsComposer>()
				.As<Singleton>();
			
			config.Register<IMessageComposer>()
				.ImplementedBy<MessageComposer>()
				.As<Singleton>();
			
			config.Register<IEventRaiser>()
				.ImplementedBy<EventRaiser>()
				.As<Singleton>();
			
			config.Register<ICommunicator>()
				.ImplementedBy<Communicator>()
				.As<Singleton>();

			container = config.Container;
			
			Task.Run(() => ReceiveLoop().Wait());
		}

		public ISendBuilder<TData> Send<TData>(TData data)
		{
			return new SendBuilder<TData>(container, data);
		}

		private async Task ReceiveLoop()
		{
			var messages = new Dictionary<int, IList<IPacket>>();
			var communicator = container.Resolve<ICommunicator>();
			var packetsComposer = container.Resolve<IPacketsComposer>();
			var messageComposer = container.Resolve<IMessageComposer>();
			var eventRaiser = container.Resolve<IEventRaiser>();
			
			while (true)
			{
				var packet = await communicator.Receive().ConfigureAwait(false);
				Task.Run(async () =>
				{
					if (messages.TryGetValue(packet.Id, out var packets))
					{
						packets.Add(packet);
					}
					else
					{
						packets = new List<IPacket>
						{
							packet
						};
						messages.Add(packet.Id, packets);
					}

					var end = packets.FirstOrDefault(x => x.End);

					if (end == null || end.Order != packets.Count)
					{
						return;
					}

					var message = await packetsComposer.GetMessage(packets).ConfigureAwait(false);
					var payload = await messageComposer.GetPayload(message).ConfigureAwait(false);
					messages.Remove(end.Id);

					await eventRaiser.Raise(payload);
				});
			}
		}
	}
}
