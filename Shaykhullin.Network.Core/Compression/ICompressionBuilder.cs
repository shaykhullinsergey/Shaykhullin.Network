namespace Shaykhullin.Network.Core
{
	public interface ICompressionBuilder : IEncryptionBuilder
	{
		IEncryptionBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption;
	}
}