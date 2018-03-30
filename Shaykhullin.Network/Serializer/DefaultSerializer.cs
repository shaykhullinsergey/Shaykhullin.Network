using System;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
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