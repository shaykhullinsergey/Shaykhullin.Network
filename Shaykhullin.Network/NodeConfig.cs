using System;
using Network.Core;
using DependencyInjection;
using DependencyInjection.Core;

namespace Network
{
	public abstract class NodeConfig<TNode> : IConfig<TNode>
		where TNode : INode
	{
		private readonly IContainerConfig rootConfig = new ContainerConfig();
		protected readonly IContainerConfig Config;

		protected NodeConfig()
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

			Config = rootConfig.Scope();
		}
		
		public ICompressionBuilder UseSerializer<TSerializer>() 
			where TSerializer : ISerializer
		{
			return new SerializerBuilder(Config)
				.UseSerializer<TSerializer>();
		}
		public IEncryptionBuilder UseCompression<TCompression>()
			where TCompression : ICompression
		{
			return new SerializerBuilder(Config)
				.UseCompression<TCompression>();
		}
		public void UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			new SerializerBuilder(Config)
				.UseEncryption<TEncryption>();
		}

		public IImplementedByBuilder<TRegister> Register<TRegister>() 
			where TRegister : class
		{
			return Config.Register<TRegister>();
		}

		public IImplementedByBuilder<object> Register(Type register)
		{
			return Config.Register(register);
		}

		public IHandlerBuilder<TEvent> When<TEvent>() 
			where TEvent : class, IEvent<object>
		{
			return new EventBuilder(Config)
				.When<TEvent>();
		}

		public virtual TNode Create(string host, int port)
		{
			Config.Register<IConfiguration>()
				.ImplementedBy(c => new Configuration(host, port))
				.As<Singleton>();

			Config.Register<IConnection>()
				.ImplementedBy<Connection>()
				.As<Singleton>();
			
			Config.Register<IContainerConfig>()
				.ImplementedBy(c => Config)
				.As<Singleton>();
			
			return default;
		}
	}
}