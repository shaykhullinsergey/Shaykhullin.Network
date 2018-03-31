using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public abstract class NodeConfig : IConfigurable, IInjectable, IHandlerable
	{
		protected readonly IList<Dependency> dependencies = new List<Dependency>();
		protected readonly Configuration configuration = new Configuration();
		protected readonly IList<EventHandler> handlers = new List<EventHandler>();

		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>
		{
			var eventHandler = new EventHandler(typeof(TEvent));
			handlers.Add(eventHandler);

			return new ConfigBuilder<TEvent>(eventHandler);
		}

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			var dependency = new Dependency(typeof(TRegister));
			dependencies.Add(dependency);
			return new RegisterBuilder<TRegister>(dependency);
		}

		public ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer
		{
			configuration.Serializer = typeof(TSerializer);
			return new CompressionBuilder(configuration);
		}

		public IEncryptionBuilder UseCompression<TCompression>()
			where TCompression : ICompression
		{
			return new CompressionBuilder(configuration)
				.UseCompression<TCompression>();
		}

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new CompressionBuilder(configuration)
				.UseEncryption<TEncryption>();
		}

		public IContainerBuilderBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator
		{
			return new CompressionBuilder(configuration)
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>()
			where TContainer : IContainerBuilder
		{
			new CompressionBuilder(configuration)
				.UseContainer<TContainer>();
		}
	}
}
