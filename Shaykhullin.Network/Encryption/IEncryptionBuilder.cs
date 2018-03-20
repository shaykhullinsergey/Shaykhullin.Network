namespace Shaykhullin.Network
{
	public interface IEncryptionBuilder
	{
		void UseDependencyContainer<TContainer>()
			where TContainer : IContainer;
	}
}