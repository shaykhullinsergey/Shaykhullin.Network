namespace Shaykhullin.Network.Core
{
	public interface IContainerBuilderBuilder
	{
		void UseContainer<TContainer>()
			where TContainer : IContainerBuilder;
	}
}