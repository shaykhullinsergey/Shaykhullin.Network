using System;
using System.Collections.Generic;

namespace Network.Core
{
	public abstract class NodeConfig : IConfigurable, IInjectable, IHandlerable
	{
		protected readonly Configuration configuration = new Configuration();
		protected readonly IDictionary<Type, ConfigDto> configs = new Dictionary<Type, ConfigDto>();
		protected readonly IDictionary<Type, DependencyDto> dependencies = new Dictionary<Type, DependencyDto>();

		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>
		{
			if(!configs.TryGetValue(typeof(TEvent), out var dto))
			{
				dto = new ConfigDto(typeof(TEvent));
				configs.Add(typeof(TEvent), dto);
			}
			
			return new ConfigBuilder<TEvent>(dto);
		}

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			if(dependencies.TryGetValue(typeof(TRegister), out var dto))
			{
				throw new InvalidOperationException($"Type {typeof(TRegister)} already registered");
			}

			dto = new DependencyDto(typeof(TRegister));
			dependencies.Add(typeof(TRegister), dto);
			return new RegisterBuilder<TRegister>(dto);
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
