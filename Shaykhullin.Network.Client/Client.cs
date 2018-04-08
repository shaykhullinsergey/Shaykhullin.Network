using System.Net.Sockets;
using System.Threading.Tasks;

using Network.Core;
using DependencyInjection;

namespace Network
{
	internal class Client : IClient
	{
		private readonly IContainerConfig config;

		public Client(IContainerConfig config)
		{
			this.config = config;
		}

		public async Task<IConnection> Connect()
		{
			config.Register<TcpClient>()
				.ImplementedBy(c => new TcpClient())
				.As<Singleton>();

			var container = config.Container;

			var connection = container.Resolve<IConnection>();

			config.Register<IConnection>()
				.ImplementedBy(c => connection)
				.As<Singleton>();
			
			await container.Resolve<ICommunicator>().Connect();

			return connection;
		}
	}
}