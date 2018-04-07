using Network.Core;

namespace Network
{
	public class ServerConfig : Config<IServer>
	{
		public override IServer Create(string host, int port)
		{
			var setup = Build(host, port);

			return new Server(setup);
		}
	}
}