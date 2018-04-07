using Network.Core;

namespace Network.Core
{
	internal class EncryptionBuilder : IEncryptionBuilder
	{
		private ConfigurationTypeDto dto;

		public EncryptionBuilder(ConfigurationTypeDto dto)
		{
			this.dto = dto;
		}

		public void UseEncryption<TEncryption>() 
			where TEncryption : IEncryption
		{
			dto.Encryption = typeof(TEncryption);
		}
	}
}
