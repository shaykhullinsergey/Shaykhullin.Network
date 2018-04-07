using System;

namespace Network.Core
{
	internal class ConfigurationBuilder : IConfigurationBuilder
	{
		private readonly ConfigurationTypeDto dto = new ConfigurationTypeDto();

		public IEncryptionBuilder UseCompression<TCompression>() 
			where TCompression : ICompression
		{
			return new CompressionBuilder(dto)
				.UseCompression<TCompression>();
		}

		public void UseEncryption<TEncryption>() 
			where TEncryption : IEncryption
		{
			new CompressionBuilder(dto)
				.UseEncryption<TEncryption>();
		}

		public ICompressionBuilder UseSerializer<TSerializer>() 
			where TSerializer : ISerializer
		{
			dto.Serializer = typeof(TSerializer);
			return new CompressionBuilder(dto);
		}

		public IConfiguration Build(string host, int port)
		{
			var serializer = (ISerializer)Activator.CreateInstance(dto.Serializer);
			var compression = (ICompression)Activator.CreateInstance(dto.Compression);
			var encryption = (IEncryption)Activator.CreateInstance(dto.Encryption);

			return new Configuration(serializer, compression, encryption, host, port);
		}
	}
}
