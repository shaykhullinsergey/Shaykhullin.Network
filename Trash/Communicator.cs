using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	public class Communicator
	{
		private Socket socket;

		public Communicator(Socket socket)
		{
			this.socket = socket;
		}

		public async Task Send(Packet packet)
		{
			var data = await new PacketsComposer().GetBytes(packet);
			await Task.Factory.FromAsync((callback, state) => (state as Socket)
					.BeginSend(data, 0, data.Length, SocketFlags.Partial, callback, state),
				result => (result.AsyncState as Socket).EndSend(result), socket);
		}

		public Task<Packet> Receive()
		{
			var data = new PacketsComposer().GetBuffer();

			return Task<Packet>.Factory.FromAsync(
				(callback, state) => (state as Socket).BeginReceive(data, 0, data.Length, SocketFlags.Partial, callback, state),
				result =>
				{
					(result.AsyncState as Socket).EndReceive(result);
					return new PacketsComposer().GetPacket(data);
				},
				socket);
		}
	}
}
