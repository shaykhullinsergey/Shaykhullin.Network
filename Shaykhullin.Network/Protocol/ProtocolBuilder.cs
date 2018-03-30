namespace Shaykhullin.Network.Core
{
	internal class ProtocolBuilder : IProtocolBuilder
	{
		public IDependencyContainerBuilder UseProtocol<TProtocol>()
			where TProtocol : IProtocol
		{
			return new DependencyContainerBuilder();
		}

		public void UseDependencyContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new DependencyContainerBuilder()
				.UseDependencyContainer<TContainer>();
		}
	}
}
