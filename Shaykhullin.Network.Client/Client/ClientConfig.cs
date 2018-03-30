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