using Network.Core;

namespace Network.Core
{
	internal class CompressionBuilder : ICompressionBuilder
	{
		private ConfigurationTypeDto dto;

		public CompressionBuilder(ConfigurationTypeDto dto)
		{
			this.dto = dto;
		}

		public IEncryptionBuilder UseCompression<TCompression>() 
			where TCompression : ICompression
		{
			dto.Compression = typeof(TCompression);
			return new EncryptionBuilder(dto);
		}

		public void UseEncryption<TEncryption>() 
			where TEncryption : IEncryption
		{
			new EncryptionBuilder(dto)
				.UseEncryption<TEncryption>();
		}
	}
}
