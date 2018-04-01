namespace Network.Core
{
	internal class Client : IClient
	{
		public IConnection Connect()
		{
			return new Connection();
		}
	}
}
