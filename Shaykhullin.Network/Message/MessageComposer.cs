using System.Threading.Tasks;
using DependencyInjection;

namespace Network.Core
{
	internal class MessageComposer : IMessageComposer
	{
		private readonly IContainer container;

		public MessageComposer(IContainer container)
		{
			this.container = container;
		}

		public Task<IMessage> GetMessage(IPayload payload)
		{
			var data = container.Resolve<ISerializer>().Serialize(payload.Data);
			data = container.Resolve<ICompression>().Compress(data);
			data = container.Resolve<IEncryption>().Encrypt(data);

			var eventId = container.Resolve<IEventHolder>().GetEvent(payload.Event);

			return Task.FromResult((IMessage)new Message { EventId = eventId, Data = data });
		}

		public Task<IPayload> GetPayload(IMessage message)
		{
			var data = container.Resolve<IEncryption>().Decrypt(message.Data);
			data = container.Resolve<ICompression>().Decompress(data);

			var @event = container.Resolve<IEventHolder>().GetEvent(message.EventId);
			var dataType = @event.GetInterfaces()[0].GetGenericArguments()[0];

			var @object = container.Resolve<ISerializer>().Deserialize(data, dataType);

			return Task.FromResult((IPayload)new Payload { Event = @event, Data = @object });
		}
	}
}