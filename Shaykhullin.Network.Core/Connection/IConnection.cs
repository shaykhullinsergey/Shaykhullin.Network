using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public interface IConnection : ISendable
	{
		ICommunicator Procotol { get; }
	}
}