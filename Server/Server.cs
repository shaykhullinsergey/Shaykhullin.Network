using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	internal class Server : IServer
	{
		private ISetup setup;

		public Server(ISetup setup)
		{
			this.setup = setup;
		}

		public async Task Run()
		{
			var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
			serverSocket.Bind(new IPEndPoint(IPAddress.Parse(setup.Configuration.Host), setup.Configuration.Port));
			serverSocket.Listen(10);

			while (true)
			{
				var socket = serverSocket.Accept();

				await setup.CreateConnection(socket);
			}
		}
	}
}
