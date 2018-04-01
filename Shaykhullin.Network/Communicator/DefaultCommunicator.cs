using System.Threading.Tasks;

namespace Network.Core
{
	public class DefaultCommunicator : ICommunicator
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