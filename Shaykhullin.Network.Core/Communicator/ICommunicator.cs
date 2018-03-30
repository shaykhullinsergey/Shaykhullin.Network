using System.Threading.Tasks;

namespace Shaykhullin.Network.Core
{
	public interface ICommunicator
	{
		int Id { get; }
		Task Send(IPacket packet);
		ValueTask<IPacket> Receive();
	}
}