using Shaykhullin.Network.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shaykhullin.Network
{
	public sealed class ServerConfig : NodeConfig, IServerConfig
	{
		private readonly IDictionary<Type, ChannelDto> channels = new Dictionary<Type, ChannelDto>();

		public IChannelConfig Channel<TChannel>() 
			where TChannel : IChannel
		{
			if(channels.TryGetValue(typeof(TChannel), out var dto))
			{
				return new ChannelConfig(dto.Dependencies);
			}

			dto = new ChannelDto(typeof(TChannel));
			channels.Add(typeof(TChannel), dto);
			return new ChannelConfig(dto.Dependencies);
		}

		public IServer Create(string host, int port)
		{
			return new Server();
		}
	}

	public class ChannelDto
	{
		public Type Channel { get; }
		public IList<Dependency> Dependencies { get; }

		public ChannelDto(Type channel)
		{
			Channel = channel;
			Dependencies = new List<Dependency>();
		}
	}
}