using System;

namespace Shaykhullin.Network.Core
{
	public interface ISerializer
	{
		byte[] Serialize(object data);
		object Deserialize(byte[] data, Type type);
	}
}