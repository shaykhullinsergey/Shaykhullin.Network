using System.Threading.Tasks;

namespace Network.Core
{
	public interface ICommunicator
	{
		int Id { get; }
		Task Send(IPacket packet);
		ValueTask<IPacket> Receive();
	}
}