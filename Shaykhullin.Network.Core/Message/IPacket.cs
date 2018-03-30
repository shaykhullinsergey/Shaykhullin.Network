namespace Shaykhullin.Network.Core
{
	public interface IPacket
	{
		int Id { get; }
		int Order { get; }
		int Length { get; }
		bool Last { get; }

		byte[] GetBytes();
	}
}