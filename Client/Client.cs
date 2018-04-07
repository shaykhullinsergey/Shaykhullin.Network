using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	internal class Client : IClient
  {
		private readonly ISetup setup;

		public Client(ISetup setup)
		{
			this.setup = setup;
		}

		public async Task<IConnection> Connect()
    {
			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
			return await setup.CreateConnection(
				socket, 
				async communicator =>
					await communicator.Connect(setup.Configuration.Host, setup.Configuration.Port));
    }
  }
}
