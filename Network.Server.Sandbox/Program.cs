using System;
using System.Threading.Tasks;

namespace Network.Server.Sandbox
{
	class Program
	{
		static void Main()
		{
			Test().Wait();
		}

		static async Task Test()
		{
			var config = new ServerConfig();

			config.When<Event>()
				.Use<Handler>();

			config.Register<Logger>();
			config.Register<Writer>()
				.ImplementedBy<Writer2>();

			var server = config.Create("127.0.0.1", 4000);
			await server.Run();
		}

		public class Works
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}

		public class Event : IEvent<Works>
		{
			public Event(IConnection connection, Works message)
			{
				Connection = connection;
				Message = message;
			}

			public IConnection Connection { get; }
			public Works Message { get; }
		}

		public class Handler : IHandler<Event>
		{
			private readonly Logger logger;

			public Handler(Logger logger)
			{
				this.logger = logger;
			}

			public Task Execute(Event @event)
			{
				logger.Log(@event.Message);
				return Task.CompletedTask;
			}
		}

		public class Logger
		{
			private Writer writer;

			public Logger(Writer writer)
			{
				this.writer = writer;
			}

			public void Log(Works msg) => Console.WriteLine(writer.Write() + msg.Name + " " + msg.Age);
		}

		public class Writer
		{
			public virtual string Write() => "Server222: ";
		}

		public class Writer2 : Writer
		{
			public override string Write()
			{
				return "NULLLL: ";
			}
		}
	}
}