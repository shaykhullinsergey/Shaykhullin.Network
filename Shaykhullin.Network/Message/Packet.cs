using System;

namespace Network.Core
{
	internal class Packet : IPacket
	{
		public int Id { get; }

		public int Order { get; }

		public int Length { get; }

		public bool Last { get; }

		public byte[] GetBytes()
		{
			throw new NotImplementedException();
		}
	}
}
