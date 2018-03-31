using System;

namespace Shaykhullin.Network.Core
{
	/// <summary>
	/// Just BinaryFormatter??
	/// </summary>
	public class DefaultSerializer : ISerializer
	{
		public byte[] Serialize(object data)
		{
			throw new NotImplementedException();
		}

		public object Deserialize(byte[] data, Type type)
		{
			throw new NotImplementedException();
		}
	}
}