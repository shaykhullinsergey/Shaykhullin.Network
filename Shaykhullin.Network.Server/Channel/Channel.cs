using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Channel : IChannel
	{
		public ISendBuilder<TData> Send<TData>(TData data)
		{
			throw new System.NotImplementedException();
		}
	}
}