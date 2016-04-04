using System;

namespace Infrastructure.Crosscutting.Core.Logging
{
	public interface ILoggerFactory
	{
		ILogger Create();

		ILogger Create(Type loggerType);
	}
}
