using Network.Core;

namespace Network
{
	public class ClientNodeConfig : NodeConfig<IClient>
	{
		public override IClient Create(string host, int port)
		{
			base.Create(host, port);
			return new Client(Config);
		}
	}
}