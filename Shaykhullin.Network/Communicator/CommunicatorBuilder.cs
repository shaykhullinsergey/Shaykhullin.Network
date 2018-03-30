namespace Shaykhullin.Network.Core
{
	internal class CommunicatorBuilder : ICommunicatorBuilder
	{
		public IDependencyContainerBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator
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
