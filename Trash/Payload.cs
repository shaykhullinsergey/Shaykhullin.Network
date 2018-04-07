using System;

namespace Network.Core
{
  internal class Payload : IPayload
	{
    public object Object { get; set; }
    public Type Event { get; set; }
  }
}
