using System;
using System.Threading.Tasks;
using Network;

namespace ConsoleApp1
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var config = new ServerConfig();
			
			config.When<Event>()
				.Use<Handler>();

			await config.Create("127.0.0.1", 4003)
				.Run();
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