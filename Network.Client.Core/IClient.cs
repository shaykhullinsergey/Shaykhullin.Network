using System;
using System.Threading.Tasks;

namespace Network.Core
{
	public interface IClient
	{
		Task<IConnection> Connect();
	}
}
