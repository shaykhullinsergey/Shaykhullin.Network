using System;
using System.Threading.Tasks;

namespace Shaykhullin.Network.Server.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		private static void Test(IServerConfig config)
		{
			config.UseSerializer<ISerializer>()
				.UseCompression<ICompression>()
				.UseEncryption<IEncryption>()
				.UseDependencyContainer<IContainer>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			var channel = config.Channel<IChannel>();
			
			channel.UseSerializer<ISerializer>()
				.UseCompression<ICompression>()
				.UseEncryption<IEncryption>()
				.UseDependencyContainer<IContainer>();

			channel.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.When<Connection>()
				.Call<ConnectionHandler>();

			config.Create("127.0.0.1", 4000)
				.Run();
		}
	}
	
	public class ConnectionHandler : IServerHandler<Connection>
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
		public Task Execute(MessageEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}