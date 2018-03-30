using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
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