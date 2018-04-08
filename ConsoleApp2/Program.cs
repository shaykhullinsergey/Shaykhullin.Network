using System;
using System.Threading;
using System.Threading.Tasks;
using Network;

namespace ConsoleApp2
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var config = new ClientConfig();

			config.When<Event>()
				.Use<Handler>();

			var connection = await config.Create("127.0.0.1", 4003).Connect();

			await connection.Send("A?")
				.In<Event>();
			
			Thread.Sleep(-1);
		}
	}

	public class Event : IEvent<string>
	{
		public Event(IConnection connection, string message)
		{
			Connection = connection;
			Message = message;
		}

		public IConnection Connection { get; }
		public string Message { get; }
	}

	public class Handler : IHandler<Event>
	{
		public Task Execute(Event @event)
		{
			Console.WriteLine(@event.Message);
			return @event.Connection
				.Send(@event.Message + "A?")
				.In<Event>();
		}
	}
}