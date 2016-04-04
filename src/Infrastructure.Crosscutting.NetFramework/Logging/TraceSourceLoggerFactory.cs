using System;
using Infrastructure.Crosscutting.Core.Logging;

namespace Infrastructure.Crosscutting.NetFramework.Logging
{
	public class TraceSourceLoggerFactory
		: ILoggerFactory
	{
		public ILogger Create()
		{
			return new TraceSourceLogger();
		}

		public ILogger Create(Type loggerType)
		{
			return new TraceSourceLogger(loggerType);
		}
	}
}