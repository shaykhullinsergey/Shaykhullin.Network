using System;

namespace Network.Core
{
  public class Payload : IPayload
	{
    public object Object { get; set; }
    public Type Event { get; set; }
  }
}
