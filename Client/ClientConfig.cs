using Network.Core;

namespace Network
{
	public class ClientConfig : Config<IClient>
	{
		public override IClient Create(string host, int port)
		{
			var setup = Build(host, port);

			return new Client(setup);
		}
	}
}
