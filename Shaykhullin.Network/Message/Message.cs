using System;

namespace Shaykhullin.Network.Core
{
	internal class Message : IMessage
	{
		public int Type => throw new NotImplementedException();

		public int Serializer => throw new NotImplementedException();

		public int Compression => throw new NotImplementedException();

		public int Encryption => throw new NotImplementedException();

		public IPacket[] GetPackets()
		{
			throw new NotImplementedException();
		}
	}
}
