using Shaykhullin.Network;
using System.Threading.Tasks;

namespace Server.Sandbox
{
	class Program
	{
		static void Main()
		{
			var config = new ServerConfig();
			
			config.UseSerializer<JsonSerializer>()
				.UseCompression<GZipCompression>()
				.UseEncryption<AesEncryption>()
				.UseProtocol<TcpProtocol>()
				.UseDependencyContainer<AutofacContainer>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			var channel = config.Channel<DefaultChannel>();
			
			channel.UseSerializer<JsonSerializer>()
				.UseCompression<GZipCompression>()
				.UseEncryption<AesEncryption>()
				.UseProtocol<TcpProtocol>()
				.UseDependencyContainer<AutofacContainer>();

			channel.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.When<Connection>()
				.Call<ConnectionHandler>();

			config.Create("127.0.0.1", 4000)
				.Run();
		}
	}
	
	public class ConnectionHandler : IHandler<Connection>
	{
		public void Execute(Connection @event)
		{
			@event.Context
				.When<MessageEvent>()
				.Call<MessageHandler>();
		}
	}
	
	public class MessageEvent : IConnectionEvent<string>
	{
		public MessageEvent(IConnection connection, string data)
		{
			Connection = connection;
			Data = data;
		}

		public IConnection Connection { get; }
		public string Data { get; }
	}
	
	public class MessageHandler : IConnectionHandler<MessageEvent>
	{
		private readonly BaseService service;

		public MessageHandler(BaseService service)
		{
			this.service = service;
		}
		
		public async Task Execute(MessageEvent @event)
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