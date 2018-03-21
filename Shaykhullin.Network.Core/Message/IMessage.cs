namespace Shaykhullin.Network.Core
{
	public interface IMessage
	{
		int Type { get; }
		int Serializer { get; }
		int Compression { get; }
		int Encryption { get; }
		
		IPacket[] GetPackets();
	}
}