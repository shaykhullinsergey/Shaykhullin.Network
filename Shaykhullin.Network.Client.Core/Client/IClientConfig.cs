namespace Shaykhullin.Network.Core
{
	public interface IClientConfig : INodeConfig
	{
		IClient Create(string host, int port);
	}
}