using Network.Core;

namespace Network
{
	public class ClientConfig : Config<IClient>
	{
		public override IClient Create(string host, int port)
		{
			base.Create(host, port);
			return new Client(config);
		}
	}
}