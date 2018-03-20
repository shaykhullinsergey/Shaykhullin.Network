using System;
using System.Threading.Tasks;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network.Client.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		static void Test(IClientConfig config)
		{
			config.UseSerializer<ISerializer>()
				.UseCompression<ICompression>()
				.UseEncryption<IEncryption>()
				.UseDependencyContainer<IContainerBuilder>();
			
			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();
			
			config.When<Connect>()
				.Call<ConnectHandler>();
		}
	}

	class ConnectHandler : IHandler<Connect>
	{
		public void Execute(Connect @event)
		{
			@event.Context.When<MessageEvent>()
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