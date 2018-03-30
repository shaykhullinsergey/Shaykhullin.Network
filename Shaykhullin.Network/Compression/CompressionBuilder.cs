namespace Shaykhullin.Network.Core
{
	internal class CompressionBuilder : ICompressionBuilder
	{
		public IEncryptionBuilder UseCompression<TCompression>() 
			where TCompression : ICompression
		{
			return new EncryptionBuilder();
		}

		public IProtocolBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new EncryptionBuilder()
				.UseEncryption<TEncryption>();
		}

		public IDependencyContainerBuilder UseProtocol<TProtocol>()
			where TProtocol : IProtocol
		{
			return new EncryptionBuilder()
				.UseProtocol<TProtocol>();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new EncryptionBuilder()
				.UseContainer<TContainer>();
		}
	}
}
