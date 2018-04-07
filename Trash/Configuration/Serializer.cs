using Newtonsoft.Json;
using System;
using System.Text;

namespace Network.Core
{
  internal class Serializer : ISerializer
  {
    public byte[] Serialize(object @object)
    {
      return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@object));
    }

    public object Deserialize(byte[] data, Type type)
    {
      return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), type);
    }
  }
}
