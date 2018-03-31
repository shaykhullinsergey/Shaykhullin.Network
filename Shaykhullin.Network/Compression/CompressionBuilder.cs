namespace Shaykhullin.Network.Core
{
	internal class CompressionBuilder : ICompressionBuilder
	{
		public IEncryptionBuilder UseCompression<TCompression>() 
			where TCompression : ICompression
		{
			return new EncryptionBuilder();
		}

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new EncryptionBuilder()
				.UseEncryption<TEncryption>();
		}

		public IContainerBuilderBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator
		{
			return new EncryptionBuilder()
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new EncryptionBuilder()
				.UseContainer<TContainer>();
		}
	}
}
