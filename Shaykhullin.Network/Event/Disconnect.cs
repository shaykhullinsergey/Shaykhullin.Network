using System.Net.Sockets;

namespace Shaykhullin.Network
{
	public class DisconnectInfo
	{
		public SocketError SocketError { get; set; }
	}
	
	public class Disconnect : IEvent<DisconnectInfo>
	{
		public Disconnect(IConnection connection, DisconnectInfo data)
		{
			Connection = connection;
			Data = data;
		}

		public IConnection Connection { get; }
		public DisconnectInfo Data { get; }
	}
}