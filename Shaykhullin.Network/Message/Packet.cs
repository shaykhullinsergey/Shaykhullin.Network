using System;

namespace Shaykhullin.Network.Core
{
	internal class Packet : IPacket
	{
		public int Id => throw new NotImplementedException();

		public int Order => throw new NotImplementedException();

		public int Length => throw new NotImplementedException();

		public bool IsTail => throw new NotImplementedException();

		public byte[] GetBytes()
		{
			throw new NotImplementedException();
		}
	}
}
