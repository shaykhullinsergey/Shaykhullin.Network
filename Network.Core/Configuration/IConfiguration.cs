using System.Collections.Generic;
using System.Text;

namespace Network.Core
{
	public interface IConfiguration
	{
		ISerializer Serializer { get; }
		ICompression Compression { get; }
		IEncryption Encryption { get; }
		string Host { get; }
		int Port { get; }
	}
}
