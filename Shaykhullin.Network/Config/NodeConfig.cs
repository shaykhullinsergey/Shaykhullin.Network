using System;
using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public class Configuration
	{
		public Type Serializer { get; set; }
		public Type Compression { get; set; }
		public Type Encryption { get; set; }
		public Type Communicator { get; set; }
		public Type Container { get; set; }
	}

	public class EventHandler
	{
		public Type Event { get; }
		public Type Handler { get; set; }

		public EventHandler(Type @event)
		{
			Event = @event;
		}
	}

	public abstract class NodeConfig : INodeConfig
	{
		protected readonly IList<Dependency> dependencies = new List<Dependency>();
		protected readonly Configuration configuration = new Configuration();
		protected readonly IList<EventHandler> eventHandlers = new List<EventHandler>();

		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>
		{
			var eventHandler = new EventHandler(typeof(TEvent));
			eventHandlers.Add(eventHandler);

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
