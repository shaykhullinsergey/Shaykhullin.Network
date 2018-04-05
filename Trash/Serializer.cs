using System;
using System.Text;

namespace Network.Core
{
  public class Serializer
  {
    public byte[] Serialize(object @object)
    {
      return Encoding.UTF8.GetBytes(@object.ToString());
    }

    public object Deserialize(byte[] data)
    {
      return Encoding.UTF8.GetString(data);
    }
  }
}
