using System;
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
		
		public bool IsConnected => !(socket.Poll(1000, SelectMode.SelectRead) && socket.Available == 0);
		
		public Communicator(IContainer container)
		{
			socket = container.Resolve<Socket>();
			packetsComposer = container.Resolve<IPacketsComposer>();
			configuration = container.Resolve<IConfiguration>();
		}

		public Task Connect()
		{
			return Task.Run(async () =>
			{
				socket.Connect(configuration.Host, configuration.Port);
				await Task.Yield();
			});
		}

		public Task Send(IPacket packet)
		{
			return Task.Run(async () =>
			{
				var data = await packetsComposer.GetBytes(packet);

				socket.Send(data, 0, data.Length, SocketFlags.None);
			});
		}

		public Task<IPacket> Receive()
		{
			return Task.Run(async () =>
			{
				var buffer = await packetsComposer.GetBuffer();

				while(!socket.Connected)
				{
					await Task.Yield();
				}
				
				socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
				
				return await packetsComposer.GetPacket(buffer);
			});
		}
	}
}