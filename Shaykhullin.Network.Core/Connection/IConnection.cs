using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public interface IConnection : ISendable
	{
		IProtocol Procotol { get; }
	}
}