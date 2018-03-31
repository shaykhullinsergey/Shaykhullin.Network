namespace Shaykhullin.Network.Core
{
	public interface IClientConfig 
		: IConfigurable, 
			IInjectable
	{
		IClient Create(string host, int port);
	}
}