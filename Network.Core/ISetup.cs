using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	public interface ISetup
	{
		IConfiguration Configuration { get; }
		IEventContainer EventContainer { get; }
		IContainer Container { get; }

		Task<IConnection> CreateConnection(Socket socket, Func<ICommunicator, Task> action = null);
	}
}
