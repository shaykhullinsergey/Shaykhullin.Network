namespace Network.Core
{
	public interface IContainerBuilderBuilder
	{
		void UseContainer<TContainer>()
			where TContainer : IContainerBuilder;
	}
}