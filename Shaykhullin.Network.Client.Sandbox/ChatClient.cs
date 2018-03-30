using System.Threading.Tasks;
using Shaykhullin.Network;
using Shaykhullin.Network.Core;

namespace Client.Sandbox
{
	public class App
	{
		static void Run()
		{
			var config = new ClientConfig();

			config.When<Connect>()
				.Call<ConnectConfig>();

			config.Register<MessageRepository>();
			config.Register<LogRepository>();
			
			config.UseSerializer<DefaultSerializer>()
				.UseCompression<DefaultCompression>()
				.UseEncryption<DefaultEncryption>()
				.UseProtocol<DefaultProtocol>()
				.UseDependencyContainer<DefaultContainer>();

			var c = config.Create("127.0.0.1", 4000)
				.Connect();

			c.Send(new Message())
				.To<NewMessage>()
				.Wait();
		}
	}

	public class ConnectConfig : IConfig<Connect>
	{
		public void Configure(Connect @event)
		{
			var config = @event.Context;
			
			config.When<NewMessage>()
				.Call<NewMessageHandler>();
			
			config.When<NewMessage>()
				.Call<NewMessageLogger>();
			
			config.When<Disconnect>()
				.Call<DisconnectHandler>();
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
		private readonly MessageRepository messageRepository;

		public NewMessageHandler(MessageRepository messageRepository)
		{
			this.messageRepository = messageRepository;
		}
		
		public async Task Handle(NewMessage @event)
		{
			var message = $"{@event.Data.Author}: {@event.Data.Text}";
			
			await messageRepository.Add(message);
		}
	}
	
	public class NewMessageLogger : IHandler<NewMessage>
	{
		private readonly LogRepository logRepository;

		public NewMessageLogger(LogRepository logRepository)
		{
			this.logRepository = logRepository;
		}
		
		public async Task Handle(NewMessage @event)
		{
			await logRepository.Add(@event.Data);
		}
	}
	
	internal class DisconnectHandler : IHandler<Disconnect>
	{
		private readonly LogRepository logRepository;

		public DisconnectHandler(LogRepository logRepository)
		{
			this.logRepository = logRepository;
		}
		
		public async Task Handle(Disconnect @event)
		{
			var connectionId = @event.Data.SocketError;

			await logRepository.Add(connectionId);
		}
	}
	
	public class MessageRepository
	{
		public Task Add(string msg)
		{
			return Task.CompletedTask;
		}
	}
	
	public class LogRepository
	{
		public Task Add(object msg)
		{
			return Task.CompletedTask;
		}
	}
}