using System;

namespace Infrastructure.Crosscutting.Core.Logging
{
	public interface ILogger
	{
		void Debug(string message, params object[] args);

		void Debug(string message, Exception exception, params object[] args);

		void Debug(string message, Exception exception);

		void Debug(object item);

		void Fatal(string message, params object[] args);

		void Fatal(string message, Exception exception, params object[] args);

		void Fatal(string message, Exception exception);

		void Info(string message, params object[] args);

		void Warning(string message, params object[] args);

		void Error(string message, params object[] args);

		void Error(string message, Exception exception, params object[] args);

		void Error(string message, Exception exception);
	}
}