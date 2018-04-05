using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	public class Communicator
	{
		private readonly Socket socket;

		public Communicator(Socket socket)
		{
			this.socket = socket;
		}

		public async Task Send(IPacket packet)
		{
			var data = await new PacketsComposer().GetBytes(packet);
			await Task.Factory.FromAsync((callback, state) => ((Socket)state)
					.BeginSend(data, 0, data.Length, SocketFlags.Partial, callback, state),
				result => ((Socket)result.AsyncState).EndSend(result), socket);
		}

		public Task<IPacket> Receive()
		{
			var data = new PacketsComposer().GetBuffer();

			return Task<IPacket>.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginReceive(data, 0, data.Length, SocketFlags.Partial, callback, state),
				result =>
				{
					((Socket)result.AsyncState).EndReceive(result);
					return new PacketsComposer().GetPacket(data);
				},
				socket);
		}
	}
}
