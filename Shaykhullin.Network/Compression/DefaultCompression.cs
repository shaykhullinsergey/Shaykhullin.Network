namespace Network.Core
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