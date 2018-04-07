namespace Network.Core
{
	public interface IConfig<TNode> : IConfigurationBuilder, IEventContainerBuilder, IContainerBuilder
	{
		TNode Create(string host, int port);
	}
}
