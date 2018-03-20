using System;
using System.IO;

namespace Shaykhullin.Network
{
	public class BaseService
	{
	}

	public class DerivedService : BaseService
	{
	}

	class MyClass
	{
		public MyClass(IServerConfig config)
		{
			config.UseSerializer<ISerializer>()
				.UseCompression<ICompression>()
				.UseEncryption<IEncryption>()
				.UseDependencyContainer<IDependencyContainer>();

			config.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			var channel = config.Channel<IChannel>();
			
			channel.UseSerializer<ISerializer>()
				.UseCompression<ICompression>()
				.UseEncryption<IEncryption>()
				.UseDependencyContainer<IDependencyContainer>();

			channel.Register<BaseService>()
				.ImplementedBy<DerivedService>()
				.As<Singleton>();

			config.When<Connection, IConnectionConfig>()
				.Call<ConnectionHandler>();
			
			config.When<Start, int>()
				.Call<StartHandler>();
			
			config.Create("127.0.0.1", 4000)
				.Run();
		}
	}

	public interface IEvent<TPayload>
	{
	}

	class Start : IEvent<int>
	{
	}

	class Connection : IEvent<IConnectionConfig>
	{
	}
	
	public interface IHandler<in TPayload>
	{
		void Execute(TPayload payload);
	}
	
	public class StartHandler : IHandler<int>
	{
		public void Execute(int payload)
		{
		}
	}
	
	public class ConnectionHandler : IHandler<IConnectionConfig>
	{
		public void Execute(IConnectionConfig payload)
		{
		}
	}
	
	public interface IConnectionConfig
	{
	}
}