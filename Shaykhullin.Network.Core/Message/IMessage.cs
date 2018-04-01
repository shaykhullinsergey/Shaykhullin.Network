namespace Network.Core
{
	public interface IMessage
	{
		int Event { get; }
		int Serializer { get; }
		int Compression { get; }
		int Encryption { get; }
		
		IPacket[] GetPackets();
	}
}