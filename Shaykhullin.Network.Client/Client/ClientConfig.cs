using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class ClientConfig : IClientConfig
	{
		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>
		{
			return new ConfigBuilder<TEvent>();
		}

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			return new RegisterBuilder<TRegister>();
		}

		public IClient Create(string host, int port)
		{
			return new Client();
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