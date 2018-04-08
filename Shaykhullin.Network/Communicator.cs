using System.Net.Sockets;
using System.Threading.Tasks;
using DependencyInjection;

namespace Network.Core
{
	internal class Communicator : ICommunicator
	{
		private readonly TcpClient tcpClient;
		private readonly IPacketsComposer packetsComposer;
		private readonly IConfiguration configuration;

		public Communicator(IContainer container)
		{
			tcpClient = container.Resolve<TcpClient>();
			packetsComposer = container.Resolve<IPacketsComposer>();
			configuration = container.Resolve<IConfiguration>();
		}

		public async Task Connect()
		{
			await tcpClient.ConnectAsync(configuration.Host, configuration.Port);
		}

		public async Task Send(IPacket packet)
		{
			var data = await packetsComposer.GetBytes(packet);

			while (!isConnected && !IsConnected)
			{
				await Connect();
			}

			await tcpClient.GetStream().WriteAsync(data, 0, data.Length);
			await Task.Delay(5);
		}

		public async Task<IPacket> Receive()
		{
			var buffer = await packetsComposer.GetBuffer();

			while (!isConnected && !IsConnected)
			{
				await Connect();
			}

			await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
			return await packetsComposer.GetPacket(buffer);
		}

		private bool isConnected = false;
		public bool IsConnected
		{
			get
			{
				try
				{
					if (tcpClient != null && tcpClient.Client != null && tcpClient.Client.Connected)
					{
						if (tcpClient.Client.Poll(0, SelectMode.SelectRead))
						{
							byte[] buff = new byte[1];
							if (tcpClient.Client.Receive(buff, SocketFlags.Peek) == 0)
							{
								return false;
							}
							else
							{
								return isConnected = true;
							}
						}
						return isConnected = true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}
	}
}