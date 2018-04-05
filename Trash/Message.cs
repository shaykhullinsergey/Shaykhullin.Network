namespace Network.Core
{
  public class Message : IMessage
  {
    public int EventId { get; set; }
    public byte[] Data { get; set; }
	}
}
