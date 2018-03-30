namespace Shaykhullin.Network.Core
{
	public interface IProtocolBuilder : IDependencyContainerBuilder
	{
		IDependencyContainerBuilder UseProtocol<TProtocol>()
			where TProtocol : IProtocol;
	}
}