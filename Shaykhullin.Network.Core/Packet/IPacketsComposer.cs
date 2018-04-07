using System.Collections.Generic;
using System.Threading.Tasks;

namespace Network.Core
{
	public interface IPacketsComposer
	{
		ValueTask<byte[]> GetBuffer();
		ValueTask<byte[]> GetBytes(IPacket packet);
		ValueTask<IMessage> GetMessage(IEnumerable<IPacket> packets);
		ValueTask<IPacket> GetPacket(byte[] data);
		ValueTask<IPacket[]> GetPackets(IMessage message);
	}
}