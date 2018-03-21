namespace Shaykhullin.Network.Core
{
	public interface IEncryptionBuilder : IProtocolBuilder
	{
		IProtocolBuilder UseProtocol<TProtocol>()
			where TProtocol : IProtocol;
	}
}