using System.Net.Sockets;
using System.Threading.Tasks;
using DependencyInjection;

namespace Network.Core
{
	internal class Communicator : ICommunicator
	{
		private readonly Socket socket;
		private readonly IPacketsComposer packetsComposer;
		private readonly IConfiguration configuration;
		
		public Communicator(IContainer container)
		{
			socket = container.Resolve<Socket>();
			packetsComposer = container.Resolve<IPacketsComposer>();
			configuration = container.Resolve<IConfiguration>();
		}

		public Task Connect()
		{
			return Task.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginConnect(configuration.Host, configuration.Port, callback, state),
				result =>
				{
					((Socket)result.AsyncState).EndConnect(result);
				}, 
				socket);
		}

		public async Task Send(IPacket packet)
		{
			var data = await packetsComposer.GetBytes(packet);
			await Task.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginSend(data, 0, data.Length, SocketFlags.None, callback, state),
				result => ((Socket)result.AsyncState).EndSend(result), 
				socket);
		}

		public async Task<IPacket> Receive()
		{
			var data = await packetsComposer.GetBuffer();

			while (!socket.Connected)
			{
				await Task.Delay(100);
			}

			return await Task<IPacket>.Factory.FromAsync(
				(callback, state) => ((Socket)state).BeginReceive(data, 0, data.Length, SocketFlags.None, callback, state),
				result =>
				{
					((Socket)result.AsyncState).EndReceive(result);
					return packetsComposer.GetPacket(data).Result;
				},
				socket);
		}
	}
}
