namespace Network.Core
{
	internal class ContainerBuilder : IContainerBuilderBuilder
	{
		private Configuration configuration;

		public ContainerBuilder(Configuration configuration)
		{
			this.configuration = configuration;
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			configuration.Container = typeof(TContainer);
		}
	}
}
