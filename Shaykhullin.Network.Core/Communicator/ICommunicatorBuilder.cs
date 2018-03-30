namespace Shaykhullin.Network.Core
{
	public interface ICommunicatorBuilder : IDependencyContainerBuilder
	{
		IDependencyContainerBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator;
	}
}