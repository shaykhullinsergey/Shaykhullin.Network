namespace Shaykhullin.Network.Core
{
	internal class ProtocolBuilder : IProtocolBuilder
	{
		public IDependencyContainerBuilder UseProtocol<TProtocol>()
			where TProtocol : IProtocol
		{
			return new ContainerBuilder();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new ContainerBuilder()
				.UseContainer<TContainer>();
		}
	}
}
