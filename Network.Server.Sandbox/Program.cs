namespace Network.Server.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new ServerConfig();
			
			config.Create("127.0.0.1", 4000)
				.Run();
		}
	}
}