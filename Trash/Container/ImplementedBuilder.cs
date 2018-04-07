using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class ImplementedBuilder<TRegister> : IImplementedBuilder<TRegister>
		where TRegister : class
	{
		private DependencyDto dto;

		public ImplementedBuilder(DependencyDto dto)
		{
			this.dto = dto;
		}

		public void ImplementedBy<TImplemented>(Func<TImplemented> factory = null) 
			where TImplemented : TRegister
		{
			if(factory != null)
			{
				dto.Factory = () => factory();
			}

			dto.Implemented = typeof(TImplemented);
		}
	}
}
