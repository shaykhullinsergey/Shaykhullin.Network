using System;
using System.Threading;
using System.Threading.Tasks;

namespace Network.Client.Sandbox
{
	class Program
	{
		static void Main()
		{
			Test().Wait();
		}

		static async Task Test()
		{
			var config = new ClientConfig();

			config.When<Event>()
				.Use<Handler>();

			config.Register<Logger>();

			var client = config.Create("127.0.0.1", 4000);
			var connection = await client.Connect();
			await connection.Send(new Works
			{
				Name = "It works!",
				Age = 122
			})
			.In<Event>();

			Thread.Sleep(-1);
		}

		public class Works
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}

		public class Event : IEvent<Works>
		{
			public Event(IConnection connection, Works message, Logger logger)
			{
				Logger = logger;
				Connection = connection;
				Message = message;
			}

			public Logger Logger { get; }
			public IConnection Connection { get; }
			public Works Message { get; }
		}

		public class Handler : IHandler<Event>
		{
			public Task Execute(Event @event)
			{
				@event.Logger.Log(@event.Message);
				return Task.CompletedTask;
			}
		}

		public class Logger
		{
			public void Log(Works msg) => Console.WriteLine("Client: " + msg.Name + " " + msg.Age);
		}
	}
}