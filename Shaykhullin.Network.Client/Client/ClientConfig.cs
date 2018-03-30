using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class ClientConfig : IClientConfig
	{
		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>
		{
			throw new System.NotImplementedException();
		}

		public IRegisterBuilder<TRegister> Register<TRegister>() 
			where TRegister : class
		{
			throw new System.NotImplementedException();
		}

		public IClient Create(string host, int port)
		{
			throw new System.NotImplementedException();
		}

		public ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer
		{
			return new CompressionBuilder();
		}

		public IEncryptionBuilder UseCompression<TCompression>() where TCompression : ICompression
		{
			return new CompressionBuilder()
				.UseCompression<TCompression>();
		}

		public IProtocolBuilder UseEncryption<TEncryption>() where TEncryption : IEncryption
		{
			return new EncryptionBuilder()
				.UseEncryption<TEncryption>();
		}

		public IDependencyContainerBuilder UseProtocol<TProtocol>() where TProtocol : IProtocol
		{
			return new ProtocolBuilder()
				.UseProtocol<TProtocol>();
		}

		public void UseDependencyContainer<TContainer>() where TContainer : IContainerBuilder
		{
			new DependencyContainerBuilder()
				.UseDependencyContainer<TContainer>();
		}
	}
}