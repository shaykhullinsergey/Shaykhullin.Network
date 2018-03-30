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

		public IProtocolBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new EncryptionBuilder()
				.UseEncryption<TEncryption>();
		}

		public IDependencyContainerBuilder UseProtocol<TProtocol>()
			where TProtocol : IProtocol
		{
			return new ProtocolBuilder()
				.UseProtocol<TProtocol>();
		}

		public void UseDependencyContainer<TContainer>()
			where TContainer : IContainerBuilder
		{
			new DependencyContainerBuilder()
				.UseDependencyContainer<TContainer>();
		}
	}
}
