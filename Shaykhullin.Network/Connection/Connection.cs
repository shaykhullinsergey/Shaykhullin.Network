using System;
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

			Task.Run(async () => await ReceiveLoop());
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

			Console.WriteLine("Loop");

			IPacket packet = null;

			while (true)
			{
				try
				{
					packet = await communicator.Receive().ConfigureAwait(false);
				}
				catch (Exception exception)
				{
					await eventRaiser.Raise(new Payload
					{
						Event = typeof(Disconnect),
						Data = new DisconnectInfo("Connection lost", exception)
					}).ConfigureAwait(false);

					throw;
				}

				if (messages.TryGetValue(packet.Id, out var packets))
				{
					packets.Add(packet);
				}
				else
				{
					packets = new List<IPacket> { packet };
					messages.Add(packet.Id, packets);
				}

				if (packet.End)
				{
					Task.Run(async () =>
					{
						var message = await packetsComposer.GetMessage(packets).ConfigureAwait(false);
						var payload = await messageComposer.GetPayload(message).ConfigureAwait(false);
						messages.Remove(packet.Id);

						await eventRaiser.Raise(payload).ConfigureAwait(false);
					}).ConfigureAwait(false);
				}
			}
		}
	}
}
