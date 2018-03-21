using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public interface IConnection : ISender
	{
		IProtocol Procotol { get; }
	}
}