namespace Network.Core
{
	public class DefaultEncryption : IEncryption
	{
		public byte[] Encrypt(byte[] data)
		{
			return data;
		}

		public byte[] Decrypt(byte[] data)
		{
			return data;
		}
	}
}