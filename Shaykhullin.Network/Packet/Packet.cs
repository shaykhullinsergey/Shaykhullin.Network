namespace Network.Core
{
  internal class Packet : IPacket
  {
		public int Id { get; set; }
    public int Order { get; set; }
    public int Length { get; set; }
    public bool End { get; set; }
    public byte[] Chunk { get; set; }
	}
}
