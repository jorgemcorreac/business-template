using System;

namespace Infrastructure.Crosscutting.Core.Logging
{
	public static class LoggerFactory
	{
		static ILoggerFactory _currentLogFactory;

		public static void SetCurrent(ILoggerFactory logFactory)
		{
			_currentLogFactory = logFactory;
		}

		public static ILogger CreateLog()
		{
			return _currentLogFactory?.Create();
		}

		public static ILogger CreateLog(Type loggerType)
		{
			return _currentLogFactory?.Create(loggerType);
		}
	}
}
