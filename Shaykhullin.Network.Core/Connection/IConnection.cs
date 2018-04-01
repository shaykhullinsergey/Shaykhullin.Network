using Network.Core;

namespace Network
{
	public interface IConnection : ISendable
	{
		ICommunicator Procotol { get; }
	}
}