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

		public Task Run()
		{
			var container = config.Container;
			
			var configuration = container.Resolve<IConfiguration>();
			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
			socket.Bind(new IPEndPoint(IPAddress.Parse(configuration.Host), configuration.Port));
			socket.Listen(10);
			
			while (true)
			{
				var client = socket.Accept();

				using (var scope = config.Scope())
				{
					scope.Register<IContainerConfig>()
						.ImplementedBy(c => scope)
						.As<Singleton>();
				
					scope.Register<Socket>()
						.ImplementedBy(c => client)
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