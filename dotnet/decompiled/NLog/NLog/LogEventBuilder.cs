using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NLog.Internal;

namespace NLog;

[CLSCompliant(false)]
public struct LogEventBuilder
{
	private readonly ILogger _logger;

	private readonly LogEventInfo? _logEvent;

	public ILogger Logger => _logger;

	public LogEventInfo? LogEvent
	{
		get
		{
			if (_logEvent != null)
			{
				return ResolveLogEvent(_logEvent);
			}
			return null;
		}
	}

	public LogEventBuilder(ILogger logger)
	{
		_logger = Guard.ThrowIfNull(logger, "logger");
		_logEvent = new LogEventInfo
		{
			LoggerName = _logger.Name
		};
	}

	public LogEventBuilder(ILogger logger, LogLevel logLevel)
	{
		_logger = Guard.ThrowIfNull(logger, "logger");
		Guard.ThrowIfNull(logLevel, "logLevel");
		if (logger.IsEnabled(logLevel))
		{
			_logEvent = new LogEventInfo
			{
				LoggerName = _logger.Name,
				Level = logLevel
			};
		}
		else
		{
			_logEvent = null;
		}
	}

	public LogEventBuilder Property<T>(string propertyName, T? propertyValue)
	{
		Guard.ThrowIfNull(propertyName, "propertyName");
		if (_logEvent != null)
		{
			_logEvent.Properties[propertyName] = propertyValue;
		}
		return this;
	}

	public LogEventBuilder Properties(IEnumerable<KeyValuePair<string, object?>> properties)
	{
		Guard.ThrowIfNull(properties, "properties");
		if (_logEvent != null)
		{
			foreach (KeyValuePair<string, object> property in properties)
			{
				_logEvent.Properties[property.Key] = property.Value;
			}
		}
		return this;
	}

	public LogEventBuilder Properties(ReadOnlySpan<(string, object?)> properties)
	{
		if (_logEvent != null)
		{
			PropertiesDictionary propertiesDictionary = _logEvent.CreatePropertiesInternal(null, properties.Length);
			ReadOnlySpan<(string, object)> readOnlySpan = properties;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				(string, object) tuple = readOnlySpan[i];
				propertiesDictionary[tuple.Item1] = tuple.Item2;
			}
		}
		return this;
	}

	public LogEventBuilder Exception(Exception? exception)
	{
		if (_logEvent != null)
		{
			_logEvent.Exception = exception;
		}
		return this;
	}

	public LogEventBuilder TimeStamp(DateTime timeStamp)
	{
		if (_logEvent != null)
		{
			_logEvent.TimeStamp = timeStamp;
		}
		return this;
	}

	public LogEventBuilder Message([Localizable(false)] string message)
	{
		if (_logEvent != null)
		{
			_logEvent.Parameters = null;
			_logEvent.Message = message;
		}
		return this;
	}

	[MessageTemplateFormatMethod("message")]
	public LogEventBuilder Message<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (_logEvent != null)
		{
			_logEvent.Message = message;
			_logEvent.Parameters = new object[1] { argument };
		}
		return this;
	}

	[MessageTemplateFormatMethod("message")]
	public LogEventBuilder Message<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (_logEvent != null)
		{
			_logEvent.Message = message;
			_logEvent.Parameters = new object[2] { argument1, argument2 };
		}
		return this;
	}

	[MessageTemplateFormatMethod("message")]
	public LogEventBuilder Message<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (_logEvent != null)
		{
			_logEvent.Message = message;
			_logEvent.Parameters = new object[3] { argument1, argument2, argument3 };
		}
		return this;
	}

	[MessageTemplateFormatMethod("message")]
	public LogEventBuilder Message([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (_logEvent != null)
		{
			_logEvent.Message = message;
			_logEvent.Parameters = args;
		}
		return this;
	}

	[MessageTemplateFormatMethod("message")]
	public LogEventBuilder Message([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (_logEvent != null)
		{
			_logEvent.Message = message;
			_logEvent.Parameters = (args.IsEmpty ? null : args.ToArray());
		}
		return this;
	}

	[MessageTemplateFormatMethod("message")]
	public LogEventBuilder Message(IFormatProvider formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (_logEvent != null)
		{
			_logEvent.FormatProvider = formatProvider;
			_logEvent.Message = message;
			_logEvent.Parameters = args;
		}
		return this;
	}

	public LogEventBuilder Callsite(string? callerClassName = null, [CallerMemberName] string? callerMemberName = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
	{
		if (_logEvent != null)
		{
			_logEvent.SetCallerInfo(callerClassName, callerMemberName, callerFilePath, callerLineNumber);
		}
		return this;
	}

	public void Log(LogLevel? logLevel = null, [CallerMemberName] string? callerMemberName = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
	{
		if (_logEvent != null)
		{
			LogEventInfo logEventInfo = ResolveLogEvent(_logEvent, logLevel);
			if (logEventInfo.CallSiteInformation == null && _logger.IsEnabled(logEventInfo.Level))
			{
				_logEvent.SetCallerInfo(null, callerMemberName, callerFilePath, callerLineNumber);
			}
			_logger.Log(logEventInfo);
		}
	}

	public void Log(Type wrapperType)
	{
		if (_logEvent != null)
		{
			LogEventInfo logEvent = ResolveLogEvent(_logEvent);
			_logger.Log(wrapperType, logEvent);
		}
	}

	private LogEventInfo ResolveLogEvent(LogEventInfo logEvent, LogLevel? logLevel = null)
	{
		if ((object)logLevel == null)
		{
			if ((object)logEvent.Level == null)
			{
				logEvent.Level = ((logEvent.Exception != null) ? LogLevel.Error : LogLevel.Info);
			}
		}
		else
		{
			logEvent.Level = logLevel;
		}
		if ((logEvent.Message == null || (object)logEvent.Message == string.Empty) && logEvent.Exception != null && _logger.IsEnabled(logEvent.Level))
		{
			logEvent.FormatProvider = ExceptionMessageFormatProvider.Instance;
			logEvent.Message = "{0}";
			logEvent.Parameters = new object[1] { logEvent.Exception };
		}
		return logEvent;
	}
}
