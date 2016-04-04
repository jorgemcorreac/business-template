using System;
using System.Diagnostics;
using System.Globalization;
using System.Security;
using Infrastructure.Crosscutting.Core.Logging;
using static System.String;

namespace Infrastructure.Crosscutting.NetFramework.Logging
{
	public sealed class TraceSourceLogger
		: ILogger
	{
		private readonly TraceSource _source;

		private readonly SourceSwitch _sourceSwitch = new SourceSwitch("SourceSwitch")
		{
			Level = SourceLevels.All
		};

		private readonly TraceListener _textWriterTraceListener = new TextWriterTraceListener(Console.Out);


		public TraceSourceLogger()
		{
			_source = new TraceSource($"{nameof(TraceSourceLogger)}:")
			{
				Switch = _sourceSwitch
			};

			_source.Listeners.Add(_textWriterTraceListener);
		}

		public TraceSourceLogger(Type loggerType)
		{
			_source = new TraceSource($"{nameof(TraceSourceLogger)}: {loggerType.FullName}:")
			{
				Switch = _sourceSwitch
			};

			_source.Listeners.Add(_textWriterTraceListener);
		}

		public void Info(string message, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message))
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				TraceInternal(TraceEventType.Information, messageToTrace);
			}
		}

		public void Warning(string message, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message))
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				TraceInternal(TraceEventType.Warning, messageToTrace);
			}
		}

		public void Error(string message, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message))
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				TraceInternal(TraceEventType.Error, messageToTrace);
			}
		}

		public void Error(string message, Exception exception, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message)
			    && exception != null)
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				var exceptionData = exception.ToString();

				TraceInternal(TraceEventType.Error,
					Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
			}
		}

		public void Error(string message, Exception exception)
		{
			if (!IsNullOrWhiteSpace(message)
			    && exception != null)
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message);

				var exceptionData = exception.ToString();

				TraceInternal(TraceEventType.Error,
					Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
			}
		}

		public void Debug(string message, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message))
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				TraceInternal(TraceEventType.Verbose, messageToTrace);
			}
		}

		public void Debug(string message, Exception exception, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message)
			    && exception != null)
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				var exceptionData = exception.ToString();

				TraceInternal(TraceEventType.Error,
					Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
			}
		}

		public void Debug(string message, Exception exception)
		{
			if (!IsNullOrWhiteSpace(message)
			    && exception != null)
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message);

				var exceptionData = exception.ToString();

				TraceInternal(TraceEventType.Error,
					Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
			}
		}

		public void Debug(object item)
		{
			if (item != null)
				TraceInternal(TraceEventType.Verbose, item.ToString());
		}

		public void Fatal(string message, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message))
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				TraceInternal(TraceEventType.Critical, messageToTrace);
			}
		}

		public void Fatal(string message, Exception exception, params object[] args)
		{
			if (!IsNullOrWhiteSpace(message)
			    && exception != null)
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message, args);

				var exceptionData = exception.ToString();

				TraceInternal(TraceEventType.Critical,
					Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
			}
		}


		public void Fatal(string message, Exception exception)
		{
			if (!IsNullOrWhiteSpace(message)
			    && exception != null)
			{
				var messageToTrace = Format(CultureInfo.InvariantCulture, message);

				var exceptionData = exception.ToString();

				TraceInternal(TraceEventType.Critical,
					Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
			}
		}

		private void TraceInternal(TraceEventType eventType, string message)
		{
			if (_source != null)
				try
				{
					_source.TraceEvent(eventType, (int) eventType, message);
				}
				catch (SecurityException)
				{
					//Cannot access to file listener or cannot have
					//privileges to write in event log etc...
				}
		}
	}
}