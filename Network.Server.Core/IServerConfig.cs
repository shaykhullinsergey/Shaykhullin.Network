namespace Network.Core
{
	public interface IServerConfig
	{
		IServer Create(string host, int port);
	}
}