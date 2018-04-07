namespace Network.Core
{
  internal class MessageComposer : IMessageComposer
	{
		private readonly IConfiguration configuration;
		private readonly IEventContainer eventContainer;

		public MessageComposer(IConfiguration configuration, IEventContainer eventContainer)
		{
			this.configuration = configuration;
			this.eventContainer = eventContainer;
		}

    public IMessage GetMessage(IPayload payload)
    {
      var data = configuration.Serializer.Serialize(payload.Object);
      data = configuration.Compression.Compress(data);
      data = configuration.Encryption.Encrypt(data);

      var eventId = eventContainer.GetEvent(payload.Event);

      return new Message
      {
        EventId = eventId,
        Data = data
      };
    }

    public IPayload GetPayload(IMessage message)
    {
			var @event = eventContainer.GetEvent(message.EventId);

      var data = configuration.Encryption.Decrypt(message.Data);
      data = configuration.Compression.Decompress(data);

			var dataType = @event.GetInterfaces()[0].GetGenericArguments()[0];

      var @object = configuration.Serializer.Deserialize(data, dataType);

      return new Payload 
      {
        Event = @event,
        Object = @object
      };
    }
  }
}
