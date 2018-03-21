using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public interface IRoom : ISender
	{
		ICollection<IConnection> Connections { get; }
	}
}