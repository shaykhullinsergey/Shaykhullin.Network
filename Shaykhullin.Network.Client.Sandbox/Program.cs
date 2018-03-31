using Shaykhullin.Network;
using System.Threading.Tasks;

namespace Client.Sandbox
{
	class Program
	{
		static void Main()
		{
			var config = new ClientConfig();
			
			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

		}
		
		class ConnectConfig : IConfig<Connect>
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
				var message = service.GetSomeString();

				await @event.Connection 
					.Send(message)
					.To<MessageEvent>();
			}
		}
	
		public class BaseService
		{
			public string GetSomeString() => "";
		}

		public class DerivedService : BaseService
		{
		}
	}
}