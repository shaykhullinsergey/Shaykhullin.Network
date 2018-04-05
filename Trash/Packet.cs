using System;

namespace Network.Core
{
  public class Packet
  {
		public int Id { get; set; }
    public int Order { get; set; }
    public int Length { get; set; }
    public bool End { get; set; }
    public byte[] Chunk { get; set; }
	}
}
