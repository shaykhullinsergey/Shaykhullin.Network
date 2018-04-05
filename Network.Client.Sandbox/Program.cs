using System;
using Network.Core;

namespace Network.Client.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new ClientConfig();

			var connection = config.Create("127.0.0.1", 4000)
				.Connect();

			connection.Send(new Payload
			{
				Event = typeof(int),
				Object = "ASDASD"
			})
			.Wait();
		}
	}
}