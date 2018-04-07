using System.Threading.Tasks;

namespace Network.Core
{
	public interface ICommunicator
	{
		Task Connect(string host, int port);
		Task<IPacket> Receive();
		Task Send(IPacket packet);
	}
}