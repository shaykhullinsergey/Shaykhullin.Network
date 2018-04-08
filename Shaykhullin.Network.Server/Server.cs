using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using DependencyInjection;

namespace Network.Core
{
	internal class Server : IServer
	{
		private readonly IContainerConfig config;

		public Server(IContainerConfig config)
		{
			this.config = config;
		}

		public async Task Run()
		{
			var container = config.Container;

			var configuration = container.Resolve<IConfiguration>();

			var tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse(configuration.Host), configuration.Port));
			tcpListener.Start();

			while (true)
			{
				var tcpClient = await tcpListener.AcceptTcpClientAsync();

				using (var scope = config.Scope())
				{
					scope.Register<IContainerConfig>()
						.ImplementedBy(c => scope)
						.As<Singleton>();
				
					scope.Register<TcpClient>()
						.ImplementedBy(c => tcpClient)
						.As<Singleton>();

					var connection = scope.Container.Resolve<IConnection>();
				
					scope.Register<IConnection>()
						.ImplementedBy(c => connection)
						.As<Singleton>();
				}
			}
		}
	}
}