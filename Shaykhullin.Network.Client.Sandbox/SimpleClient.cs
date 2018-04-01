using System.Threading.Tasks;
using Network;

namespace Client.Sandbox
{
	class SimpleClient
	{
		static void Run()
		{
			var config = new ClientConfig();

			config.When<Connect>()
				.Call<ConnectConfig>();

			config.Register<MessageLogger>()
				.As<Singleton>();

			var connection = config
				.Create("127.0.0.1", 4000)
				.Connect();

			connection.Send("HELLO")
				.To<NewMessage>()
				.Wait();
		}

		class NewMessage : IEvent<string>
		{
			public NewMessage(IConnection connection, string data)
			{
				Connection = connection;
				Data = data;
			}

			public IConnection Connection { get; }
			public string Data { get; }
		}

		class ConnectConfig : IConfig<Connect>
		{
			public void Configure(Connect @event)
			{
				@event.Context
					.When<NewMessage>()
					.Call<NewMessageHandler>();

				@event.Context
					.When<Disconnect>()
					.Call<DisconnectHandler>();
			}
		}

		class DisconnectHandler : IHandler<Disconnect>
		{
			public Task Handle(Disconnect @event)
			{
				return Task.CompletedTask;
			}
		}

		class NewMessageHandler : IHandler<NewMessage>
		{
			private readonly MessageLogger logger;

			public NewMessageHandler(MessageLogger logger)
			{
				this.logger = logger;
			}

			public async Task Handle(NewMessage @event)
			{
				logger.Log(@event.Data);

				await @event.Connection
					.Send(@event.Data)
					.To<NewMessage>();
			}
		}

		class MessageLogger
		{
			public void Log(string msg)
			{
			}
		}
	}
}
