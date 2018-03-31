namespace Shaykhullin.Network.Core
{
	internal class CommunicatorBuilder : ICommunicatorBuilder
	{
		private readonly Configuration configuration;

		public CommunicatorBuilder(Configuration configuration)
		{
			this.configuration = configuration;
		}

		public IContainerBuilderBuilder UseCommunicator<TCommunicator>()
			where TCommunicator : ICommunicator
		{
			configuration.Communicator = typeof(TCommunicator);
			return new ContainerBuilder(configuration);
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new ContainerBuilder(configuration)
				.UseContainer<TContainer>();
		}
	}
}
