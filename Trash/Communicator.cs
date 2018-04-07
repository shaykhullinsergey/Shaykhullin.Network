using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	internal class Communicator : ICommunicator
	{
		private readonly Socket socket;
		private readonly IPacketsComposer packetsComposer;

		public Communicator(Socket socket, IPacketsComposer packetsComposer)
		{
			this.socket = socket;
			this.packetsComposer = packetsComposer;
		}

		public Task Connect(string host, int port)
		{
			return Task.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginConnect(host, port, callback, socket),
				result => ((Socket)result.AsyncState).EndConnect(result), 
				socket);
		}

		public async Task Send(IPacket packet)
		{
			var data = await packetsComposer.GetBytes(packet);
			await Task.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginSend(data, 0, data.Length, SocketFlags.Partial, callback, state),
				result => ((Socket)result.AsyncState).EndSend(result), 
				socket);
		}

		public Task<IPacket> Receive()
		{
			var data = packetsComposer.GetBuffer();

			return Task<IPacket>.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginReceive(data, 0, data.Length, SocketFlags.Partial, callback, state),
				result =>
				{
					((Socket)result.AsyncState).EndReceive(result);
					return packetsComposer.GetPacket(data);
				},
				socket);
		}
	}
}
