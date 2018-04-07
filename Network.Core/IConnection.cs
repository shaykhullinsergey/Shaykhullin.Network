using Network.Core;
using System;

namespace Network
{
	public interface IConnection
	{
		ISendBuilder Send<TData>(TData data);
	}
}
