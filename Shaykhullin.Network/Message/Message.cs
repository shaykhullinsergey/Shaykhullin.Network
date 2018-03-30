using System;

namespace Shaykhullin.Network.Core
{
	internal class Message : IMessage
	{
		public int Type { get; }

		public int Serializer { get; }

		public int Compression { get; }

		public int Encryption { get; }

		public IPacket[] GetPackets()
		{
			throw new NotImplementedException();
		}
	}
}
