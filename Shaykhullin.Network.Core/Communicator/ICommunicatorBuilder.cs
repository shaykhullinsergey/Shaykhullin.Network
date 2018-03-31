namespace Shaykhullin.Network.Core
{
	public interface ICommunicatorBuilder : IContainerBuilderBuilder
	{
		IContainerBuilderBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator;
	}
}