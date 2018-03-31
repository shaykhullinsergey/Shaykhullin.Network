using System.Threading.Tasks;
using Shaykhullin.Network;

namespace Server.Sandbox
{
	public class SimpleServer
	{
		static void Run()
		{
			var config = new ServerConfig();

			config.When<Connect>()
				.Call<ConnectConfig>();

			config.Register<MessageLogger>()
				.As<Singleton>();

			config.Create("127.0.0.1", 4000)
				.Run();
		}

		class ConnectConfig : IConfig<Connect>
		{
			public void Configure(Connect @event)
			{
				@event.Context.When<Disconnect>()
					.Call<DisconnectHandler>();

				@event.Context.When<NewMessage>()
					.Call<NewMessageHandler>();
			}
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

		class DisconnectHandler : IHandler<Disconnect>
		{
			public Task Handle(Disconnect @event)
			{
				return Task.CompletedTask;
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
