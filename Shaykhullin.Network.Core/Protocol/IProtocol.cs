using System.Threading.Tasks;

namespace Shaykhullin.Network.Core
{
	public interface IProtocol
	{
		int Id { get; }
		Task Send(IPacket packet);
		ValueTask<IPacket> Receive();
	}
}