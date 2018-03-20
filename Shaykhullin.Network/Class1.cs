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

			config.When<Connection>()
				.Call<ConnectionHandler>();
			
			config.When<Start>()
				.Call<StartHandler>();
			
			config.Create("127.0.0.1", 4000)
				.Run();
		}
	}
	
	public interface IConnectionConfig
	{
	}
}