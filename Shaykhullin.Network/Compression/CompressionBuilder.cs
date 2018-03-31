namespace Shaykhullin.Network.Core
{
	internal class CompressionBuilder : ICompressionBuilder
	{
		private Configuration configuration;

		public CompressionBuilder(Configuration configuration)
		{
			this.configuration = configuration;
		}

		public IEncryptionBuilder UseCompression<TCompression>() 
			where TCompression : ICompression
		{
			configuration.Compression = typeof(TCompression);
			return new EncryptionBuilder(configuration);
		}

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new EncryptionBuilder(configuration)
				.UseEncryption<TEncryption>();
		}

		public IContainerBuilderBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator
		{
			return new EncryptionBuilder(configuration)
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new EncryptionBuilder(configuration)
				.UseContainer<TContainer>();
		}
	}
}
