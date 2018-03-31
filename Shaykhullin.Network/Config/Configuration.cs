using System;

namespace Shaykhullin.Network.Core
{
	public class Configuration
	{
		public Type Serializer { get; set; }
		public Type Compression { get; set; }
		public Type Encryption { get; set; }
		public Type Communicator { get; set; }
		public Type Container { get; set; }
	}
}
