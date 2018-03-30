namespace Shaykhullin.Network.Core
{
	internal class ChannelConfig : IChannelConfig
	{
		public IRegisterBuilder<TRegister> Register<TRegister>() 
			where TRegister : class
		{
			return new RegisterBuilder<TRegister>();
		}

		public ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer
		{
			return new CompressionBuilder();
		}

		public IEncryptionBuilder UseCompression<TCompression>()
			where TCompression : ICompression
		{
			return new CompressionBuilder()
				.UseCompression<TCompression>();
		}

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new EncryptionBuilder()
				.UseEncryption<TEncryption>();
		}

		public IDependencyContainerBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator
		{
			return new CommunicatorBuilder()
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>()
			where TContainer : IContainerBuilder
		{
			new ContainerBuilder()
				.UseContainer<TContainer>();
		}
	}
}
