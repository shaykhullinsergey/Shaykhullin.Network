namespace Network.Core
{
  public class MessageComposer
  {
    public IMessage GetMessage(IPayload payload)
    {
      var data = new Serializer().Serialize(payload.Object);
      data = new Compression().Compress(data);
      data = new Encryption().Encrypt(data);

      var eventId = new Container().GetEvent(payload.Event);

      return new Message
      {
        EventId = eventId,
        Data = data
      };
    }

    public IPayload GetPayload(IMessage message)
    {
      var data = new Encryption().Decrypt(message.Data);
      data = new Compression().Decompress(data);
      var @object = new Serializer().Deserialize(data);

      var @event = new Container().GetEvent(message.EventId);

      return new Payload 
      {
        Event = @event,
        Object = @object
      };
    }
  }
}
