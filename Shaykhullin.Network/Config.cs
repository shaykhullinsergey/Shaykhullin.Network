using System;
using Network.Core;
using DependencyInjection;
using DependencyInjection.Core;

namespace Network
{
	public abstract class Config<TNode> : IConfig<TNode>
		where TNode : INode
	{
		private readonly IContainerConfig rootConfig = new ContainerConfig();
		protected readonly IContainerConfig config;

		protected Config()
		{
			rootConfig.Register<ISerializer>()
				.ImplementedBy<Serializer>()
				.As<Singleton>();
			
			rootConfig.Register<ICompression>()
				.ImplementedBy<Compression>()
				.As<Singleton>();
			
			rootConfig.Register<IEncryption>()
				.ImplementedBy<Encryption>()
				.As<Singleton>();

			config = rootConfig.Scope();
		}
		
		public ICompressionBuilder UseSerializer<TSerializer>() 
			where TSerializer : ISerializer
		{
			return new SerializerBuilder(config)
				.UseSerializer<TSerializer>();
		}
		public IEncryptionBuilder UseCompression<TCompression>()
			where TCompression : ICompression
		{
			return new SerializerBuilder(config)
				.UseCompression<TCompression>();
		}
		public void UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			new SerializerBuilder(config)
				.UseEncryption<TEncryption>();
		}

		public IImplementedByBuilder<TRegister> Register<TRegister>() 
			where TRegister : class
		{
			return config.Register<TRegister>();
		}

		public IImplementedByBuilder<object> Register(Type register)
		{
			return config.Register(register);
		}

		public IHandlerBuilder<TEvent> When<TEvent>() 
			where TEvent : class, IEvent<object>
		{
			return new EventBuilder(config)
				.When<TEvent>();
		}

		public virtual TNode Create(string host, int port)
		{
			config.Register<IConfiguration>()
				.ImplementedBy(c => new Configuration(host, port))
				.As<Singleton>();

			config.Register<IConnection>()
				.ImplementedBy<Connection>()
				.As<Singleton>();
			
			config.Register<IContainerConfig>()
				.ImplementedBy(c => config)
				.As<Singleton>();
			
			return default;
		}
	}
}