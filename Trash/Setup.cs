using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	internal class Setup : ISetup
	{
		public Setup(IConfiguration configuration, IEventContainer eventContainer, IContainer container)
		{
			Configuration = configuration;
			EventContainer = eventContainer;
			Container = container;
		}

		public IConfiguration Configuration { get; }
		public IEventContainer EventContainer { get; }
		public IContainer Container { get; }

		public async Task<IConnection> CreateConnection(Socket socket, Func<ICommunicator, Task> action = null)
		{
			var packetsComposer = new PacketsComposer();
			var messageComposer = new MessageComposer(Configuration, EventContainer);

			var eventRaiser = new EventRaiser(EventContainer, Container);
			var communicator = new Communicator(socket, packetsComposer);
			await (action?.Invoke(communicator) ?? Task.CompletedTask);

			var connection = new Connection(communicator, messageComposer, packetsComposer, eventRaiser);
			((Container)Container).Connection = connection;
			return connection;
		}
	}
}
