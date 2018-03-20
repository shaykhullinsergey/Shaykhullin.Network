namespace Shaykhullin.Network
{
	public interface ICompressionBuilder : IEncryptionBuilder
	{
		IEncryptionBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption;
	}
}