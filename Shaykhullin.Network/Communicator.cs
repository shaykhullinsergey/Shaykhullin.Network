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
			await tcpClient.ConnectAsync(configuration.Host, configuration.Port).ConfigureAwait(false);
		}

		public async Task Send(IPacket packet)
		{
			var data = await packetsComposer.GetBytes(packet).ConfigureAwait(false);

			while (!isConnected && !IsConnected)
			{
				await Connect().ConfigureAwait(false);
			}

			await tcpClient.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
			await Task.Delay(100);
		}

		public async Task<IPacket> Receive()
		{
			var buffer = await packetsComposer.GetBuffer();

			if(isConnected && !IsConnected)
			{
				System.Console.WriteLine("DISCONNECT");
			}

			while (!isConnected && !IsConnected)
			{
				await Connect().ConfigureAwait(false);
			}

			await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
			return await packetsComposer.GetPacket(buffer).ConfigureAwait(false);
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