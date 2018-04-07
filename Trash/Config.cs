namespace Network.Core
{
	public abstract class Config<TNode> : IConfig<TNode>
	{
		private readonly ConfigurationBuilder configuration = new ConfigurationBuilder();
		private readonly EventConfainerBuilder eventsContainer = new EventConfainerBuilder();
		private readonly ContainerBuilder container = new ContainerBuilder();

		public IImplementedBuilder<TRegister> Register<TRegister>() 
			where TRegister : class
		{
			return container.Register<TRegister>();
		}

		public IUseBuilder<TEvent> When<TEvent>() 
			where TEvent : IEvent<object>
		{
			return eventsContainer.When<TEvent>();
		}

		public ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer
		{
			return configuration.UseSerializer<TSerializer>();
		}

		public IEncryptionBuilder UseCompression<TCompression>() 
			where TCompression : ICompression
		{
			return configuration.UseCompression<TCompression>();
		}

		public void UseEncryption<TEncryption>() 
			where TEncryption : IEncryption
		{
			configuration.UseEncryption<TEncryption>();
		}

		public abstract TNode Create(string host, int port);

		protected ISetup Build(string host, int port)
		{
			var configuration = this.configuration.Build(host, port);
			var eventsContainer = this.eventsContainer.Build();
			var container = this.container.Build();

			return new Setup(configuration, eventsContainer, container);
		}
	}
}
