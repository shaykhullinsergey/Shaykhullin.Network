namespace Network.Core
{
	public interface IPacket
	{
		int Id { get; }
		int Order { get; }
		int Length { get; }
		bool End { get; }
		byte[] Chunk { get; }
	}
}