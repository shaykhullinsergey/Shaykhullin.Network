namespace Shaykhullin.Network.Core
{
	public interface IClientConfig : IConfigurable, IInjectable, IHandlerable
	{
		IClient Create(string host, int port);
	}
}