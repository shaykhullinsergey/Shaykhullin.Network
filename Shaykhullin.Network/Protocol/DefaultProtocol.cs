using System.Threading.Tasks;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class DefaultProtocol : IProtocol
	{
		public int Id { get; }

		public Task Send(IPacket packet)
		{
			throw new System.NotImplementedException();
		}

		public ValueTask<IPacket> Receive()
		{
			throw new System.NotImplementedException();
		}
	}
}