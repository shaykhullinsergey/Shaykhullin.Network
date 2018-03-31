namespace Shaykhullin.Network.Core
{
	internal class EncryptionBuilder : IEncryptionBuilder
	{
		private Configuration configuration;

		public EncryptionBuilder(Configuration configuration)
		{
			this.configuration = configuration;
		}

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			configuration.Encryption = typeof(TEncryption);
			return new CommunicatorBuilder(configuration);
		}

		public IContainerBuilderBuilder UseCommunicator<TProtocol>() 
			where TProtocol : ICommunicator
		{
			return new CommunicatorBuilder(configuration)
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new CommunicatorBuilder(configuration)
				.UseContainer<TContainer>();
		}
	}
}
