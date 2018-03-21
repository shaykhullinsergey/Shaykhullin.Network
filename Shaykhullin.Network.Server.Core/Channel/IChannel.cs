using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public interface IChannel : ISender
	{
		ICollection<IRoom> Rooms { get; }
	}
}