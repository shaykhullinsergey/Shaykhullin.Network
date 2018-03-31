using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public abstract class NodeConfig : IConfigurable, IInjectable, IHandlerable
	{
		private readonly Injectable injectable  = new Injectable();
		private readonly Configurable configurable  = new Configurable();
		private readonly Handlerable handlerable  = new Handlerable();

		protected IList<Dependency> Dependencies => injectable.Dependencies;
		protected Configuration Configuration => configurable.Configuration;
		protected IList<EventHandler> Handlers => handlerable.Handlers;

		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object> =>
				handlerable.When<TEvent>();

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class =>
				injectable.Register<TRegister>();

		public ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer =>
				configurable.UseSerializer<TSerializer>();

		public IEncryptionBuilder UseCompression<TCompression>()
			where TCompression : ICompression =>
				configurable.UseCompression<TCompression>();

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption =>
				configurable.UseEncryption<TEncryption>();

		public IContainerBuilderBuilder UseCommunicator<TCommunicator>()
			where TCommunicator : ICommunicator =>
				configurable.UseCommunicator<TCommunicator>();

		public void UseContainer<TContainer>()
			where TContainer : IContainerBuilder =>
				configurable.UseContainer<TContainer>();
	}
}
