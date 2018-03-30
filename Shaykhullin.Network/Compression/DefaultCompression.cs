using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class DefaultCompression : ICompression
	{
		public byte[] Compress(byte[] data)
		{
			return data;
		}

		public byte[] Decompress(byte[] data)
		{
			return data;
		}
	}
}