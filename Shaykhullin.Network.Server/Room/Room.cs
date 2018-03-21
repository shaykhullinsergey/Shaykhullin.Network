using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network.Server.Room
{
	public class Room : IRoom
	{
		public Room()
		{
			Connections = new Collection<IConnection>();
		}

		public ISendBuilder<TData> Send<TData>(TData data)
		{
			throw new System.NotImplementedException();
		}

		public ICollection<IConnection> Connections { get; }
	}
}