namespace Network.Core
{
	public interface IEncryptionBuilder : ICommunicatorBuilder
	{
		ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption;
	}
}