using System.Reflection;
using System.Threading.Tasks;

namespace Network.Core
{
	internal class EventRaiser : IEventRaiser
	{
		private readonly IEventContainer eventContainer;
		private readonly IContainer container;

		public EventRaiser(IEventContainer eventContainer, IContainer container)
		{
			this.eventContainer = eventContainer;
			this.container = container;
		}

		public async Task Raise(IPayload payload)
		{
			var handlers = eventContainer.GetHandlers(payload.Event);

			foreach (var handlerType in handlers)
			{
				var handler = container.Resolve(handlerType);
				var @event = container.ResolveEvent(payload.Event, payload.Object);

				await (Task)handlerType.InvokeMember(
					"Execute",
					BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
					null, 
					handler, 
					new[] { @event });
			}
		}
	}
}
