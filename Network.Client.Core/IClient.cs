using System;

namespace Network.Core
{
	public interface IClient
	{
		IConnection Connect();
	}
}
