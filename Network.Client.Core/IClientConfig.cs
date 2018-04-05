namespace Network.Core
{
	public interface IClientConfig
	{
		IClient Create(string host, int port);
	}
}
