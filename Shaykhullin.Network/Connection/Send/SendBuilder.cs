using System;
using System.Threading.Tasks;

namespace Shaykhullin.Network.Core
{
	internal class SendBuilder<TData> : ISendBuilder<TData>
	{
		public Task To<TEvent>() 
			where TEvent : IEvent<TData>
		{
			return Task.CompletedTask;
		}
	}
}
