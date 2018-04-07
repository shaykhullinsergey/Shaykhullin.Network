using System;
namespace Network.Core
{
	internal class ConfigurationTypeDto
	{
		public Type Serializer { get; set; }
		public Type Compression { get; set; }
		public Type Encryption { get; set; }

		public ConfigurationTypeDto()
		{
			Serializer = typeof(Serializer);
			Compression = typeof(Compression);
			Encryption = typeof(Encryption);
		}
	}
}
