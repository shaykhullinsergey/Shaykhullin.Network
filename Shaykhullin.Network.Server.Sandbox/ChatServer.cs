using System.Threading.Tasks;
using Network;

namespace Server.Sandbox
{
	public class ChatServer
	{
		static void Run()
		{
			var config = new ServerConfig();
			
			config.When<Start>()
				.Call<StartConfig>();
			
			config.When<Connect>()
				.Call<ConnectionConfig>();
			
			config.When<Stop>()
				.Call<StopConfig>();
			
			config.Register<MessageLogger>()
				.As<Singleton>();
			
			config.Channel<DefaultChannel>()
				.Register<MessageLogger>()
				.As<Transient>();
			
			config.Create("127.0.0.1", 4000)
				.Run();
		}
	}
	
	public class ConnectionConfig : IConfig<Connect>
	{
		public void Configure(Connect @event)
		{
			var config = @event.Context;
			
			config.When<NewMessage>()
				.Call<NewMessageHandler>();
		}
	}

	public class Message
	{
		public string Author { get; set; }
		public string Text { get; set; }
	}
	
	public class NewMessage : IEvent<Message>
	{
		public NewMessage(IConnection connection, Message data)
		{
			Connection = connection;
			Data = data;
		}
		
		public IConnection Connection { get; }
		public Message Data { get; }
	}
	
	public class NewMessageHandler : IHandler<NewMessage>
	{
		private readonly MessageLogger messageLogger;

		public NewMessageHandler(MessageLogger messageLogger)
		{
			this.messageLogger = messageLogger;
		}
		
		public async Task Handle(NewMessage @event)
		{
			await messageLogger.LogMessage(@event.Data);
			
			await @event.Connection
				.Send(new Message())
				.To<NewMessage>();
		}
	}
	
	public class StartConfig : IConfig<Start>
	{
		public void Configure(Start @event)
		{
			throw new System.NotImplementedException();
		}
	}
	
	public class StopConfig : IConfig<Stop>
	{
		public void Configure(Stop @event)
		{
			throw new System.NotImplementedException();
		}
	}

	public class MessageLogger
	{
		public Task LogMessage(Message msg)
		{
			return Task.CompletedTask;
		}
	}
}