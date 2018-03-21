using System.Threading.Tasks;

namespace Shaykhullin.Network.Core
{
	public interface IProtocol
	{
		Task Send(IPacket packet);
		ValueTask<IPacket> Receive();
	}
}