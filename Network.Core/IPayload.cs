using System;

namespace Network.Core
{
	public interface IPayload
	{
		object Object { get; }
		Type Event { get; }
	}
}
