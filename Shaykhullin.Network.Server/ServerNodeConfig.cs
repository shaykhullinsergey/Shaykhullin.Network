using Network.Core;

namespace Network
{
	public class ServerNodeConfig : NodeConfig<IServer>
	{
		public override IServer Create(string host, int port)
		{
			base.Create(host, port);
			return new Server(Config);
		}
	}
}