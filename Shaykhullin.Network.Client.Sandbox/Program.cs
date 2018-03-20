using Shaykhullin.Network;
using System.Threading.Tasks;

namespace Client.Sandbox
{
	class Program
	{
		static void Main()
		{
			var config = new ClientConfig();
			
			config.UseSerializer<JsonSerializer>()
				.UseCompression<GZipCompression>()
				.UseEncryption<AesEncryption>()
				.UseDependencyContainer<AutofacContainer>();
			
			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();
			
			config.When<Connect>()
				.Call<ConnectHandler>();

			var connection = config
				.Create("127.0.0.1", 4000)
				.Connect();
		}
	}

	class ConnectHandler : IHandler<Connect>
	{
		public void Execute(Connect @event)
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
		public Task Execute(MessageEvent @event)
		{
			return Task.CompletedTask;
		}
	}
	
	public class BaseService
	{
	}

	public class DerivedService : BaseService
	{
	}
}