using Shaykhullin.Network;
using System.Threading.Tasks;

namespace Server.Sandbox
{
	class Program
	{
		static void Main()
		{
			var config = new ServerConfig();
			
			config.UseSerializer<DefaultSerializer>()
				.UseCompression<DefaultCompression>()
				.UseEncryption<DefaultEncryption>()
				.UseProtocol<DefaultProtocol>()
				.UseDependencyContainer<DefaultContainer>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			var channel = config.Channel<DefaultChannel>();
			
			channel.UseSerializer<DefaultSerializer>()
				.UseCompression<DefaultCompression>()
				.UseEncryption<DefaultEncryption>()
				.UseProtocol<DefaultProtocol>()
				.UseDependencyContainer<DefaultContainer>();

			channel.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.When<Connect>()
				.Call<ConnectionConfig>();

			config.Create("127.0.0.1", 4000)
				.Run();
		}
		
		public class ConnectionConfig : IConfig<Connect>
		{
			public void Configure(Connect @event)
			{
				@event.Context
					.When<MessageEvent>()
					.Call<MessageHandler>();
			}
		}
	
		public class MessageEvent : IEvent<string>
		{
			public MessageEvent(IConnection connection, string data)
			{
				Connection = connection;
				Data = data;
			}

			public IConnection Connection { get; }
			public string Data { get; }
		}
	
		public class MessageHandler : IHandler<MessageEvent>
		{
			private readonly BaseService service;

			public MessageHandler(BaseService service)
			{
				this.service = service;
			}
		
			public async Task Handle(MessageEvent @event)
			{
				await @event.Connection
					.Send(service.GetSomeString())
					.To<MessageEvent>();
			}
		}
	
		public abstract class BaseService
		{
			public abstract string GetSomeString();
		}

		public class DerivedService : BaseService
		{
			public override string GetSomeString() => nameof(DerivedService);
		}
	}
	
}