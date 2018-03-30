namespace Shaykhullin.Network.Core
{
	public interface IEncryptionBuilder : IProtocolBuilder
	{
		IProtocolBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption;
	}
}