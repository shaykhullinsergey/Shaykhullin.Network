using System;

namespace Network.Core
{
	internal class Configuration : IConfiguration
	{
		public Configuration(ISerializer serializer, ICompression compression, IEncryption encryption, string host, int port)
		{
			Serializer = serializer;
			Compression = compression;
			Encryption = encryption;
			Host = host;
			Port = port;
		}

		public ISerializer Serializer { get; }
		public ICompression Compression { get; }
		public IEncryption Encryption { get; }
		public string Host { get; }
		public int Port { get; }
	}
}
