namespace Network.Core
{
	public interface ICommunicatorBuilder : IContainerBuilderBuilder
	{
		IContainerBuilderBuilder UseCommunicator<TCommunicator>()
			where TCommunicator : ICommunicator;
	}
}