using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Core
{
	public class PacketsComposer
	{
		private static int UniqueId = 0;
		private const int PacketSize = 1024;
		private const int HeaderSize = 20;
		private const int PayloadSize = PacketSize - HeaderSize;

		public IPacket GetPacket(byte[] data)
		{
			var chunk = new byte[PayloadSize];
			Array.Copy(data, HeaderSize, chunk, 0, PayloadSize);

			return new Packet
			{
				Id = BitConverter.ToInt32(data, 0),
				Order = BitConverter.ToInt16(data, 4),
				Length = BitConverter.ToInt32(data, 8),
				End = BitConverter.ToBoolean(data, 12),
				Chunk = chunk
			};
		}

		public async Task<byte[]> GetBytes(IPacket packet)
		{
			var data = new byte[PacketSize];
			Array.Copy(BitConverter.GetBytes(packet.Id), 0, data, 0, 4);

			Array.Copy(BitConverter.GetBytes(packet.Order), 0, data, 4, 4);
			Array.Copy(BitConverter.GetBytes(packet.Length), 0, data, 8, 4);
			Array.Copy(BitConverter.GetBytes(packet.End), 0, data, 12, 1);
			Array.Copy(packet.Chunk, 0, data, HeaderSize, PayloadSize);
			return data;
		}

		public byte[] GetBuffer()
		{
			return new byte[PacketSize];
		}

		public async Task<IPacket[]> GetPackets(IMessage message)
		{
			var id = UniqueId++;

			var data = new byte[message.Data.Length + 4];
			Array.Copy(BitConverter.GetBytes(message.EventId), data, 4);
			Array.Copy(message.Data, 0, data, 4, message.Data.Length);

			var count = GetPacketCount(data.Length);

			var packets = new IPacket[count];

			for (var order = 0; order < count; order++)
			{
				var end = (order + 1) * PayloadSize >= data.Length;
				var length = !end ? PayloadSize : data.Length - order * PayloadSize;
				var chunk = new byte[PayloadSize];

				Array.Copy(data, order * PayloadSize, chunk, 0, length);

				packets[order] = new Packet
				{
					Id = id,
					Order = order + 1,
					End = end,
					Length = length,
					Chunk = chunk
				};
			}

			return packets;
		}

		public IMessage GetMessage(IEnumerable<IPacket> packets)
		{
			var data = packets
				.SelectMany(x => x.Chunk.Take(x.Length))
				.ToArray();

			return new Message
			{
				EventId = BitConverter.ToInt32(data, 0),
				Data = data.Skip(4).ToArray()
			};
		}

		public int GetPacketCount(int length) =>
			length / PayloadSize + (length % PayloadSize == 0 ? 0 : 1);
	}
}
