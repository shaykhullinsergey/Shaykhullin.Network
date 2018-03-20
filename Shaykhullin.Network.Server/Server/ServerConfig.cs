using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class ServerConfig : IServerConfig
	{
		public void UseDependencyContainer<TContainer>() where TContainer : IContainerBuilder
		{
			throw new System.NotImplementedException();
		}

		public IEncryptionBuilder UseEncryption<TEncryption>() where TEncryption : IEncryption
		{
			throw new System.NotImplementedException();
		}

		public ICompressionBuilder UseCompression<TCompression>() where TCompression : ICompression
		{
			throw new System.NotImplementedException();
		}

		public ISerializerBuilder UseSerializer<TSerializer>() where TSerializer : ISerializer
		{
			throw new System.NotImplementedException();
		}

		public IRegisterBuilder<TRegister> Register<TRegister>() where TRegister : class
		{
			throw new System.NotImplementedException();
		}

		public IChannelConfig Channel<TChannel>() where TChannel : IChannel
		{
			throw new System.NotImplementedException();
		}

		public IHandlerConfig<TEvent> When<TEvent>() where TEvent : IEvent<object>
		{
			throw new System.NotImplementedException();
		}

		public IServer Create(string host, int port)
		{
			throw new System.NotImplementedException();
		}
	}
}