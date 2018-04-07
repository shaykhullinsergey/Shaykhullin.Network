using System.Collections.Generic;
using System.Threading.Tasks;

namespace Network.Core
{
	public interface IPacketsComposer
	{
		byte[] GetBuffer();
		Task<byte[]> GetBytes(IPacket packet);
		IMessage GetMessage(IEnumerable<IPacket> packets);
		IPacket GetPacket(byte[] data);
		Task<IPacket[]> GetPackets(IMessage message);
	}
}