using System;
using System.ComponentModel;
using System.Diagnostics;
using JetBrains.Annotations;
using NLog.Internal;

namespace NLog;

[CLSCompliant(false)]
public static class ILoggerExtensions
{
	public static LogEventBuilder ForLogEvent(this ILogger logger, LogLevel? logLevel = null)
	{
		if ((object)logLevel != null)
		{
			return new LogEventBuilder(logger, logLevel);
		}
		return new LogEventBuilder(logger);
	}

	public static LogEventBuilder ForTraceEvent(this ILogger logger)
	{
		return new LogEventBuilder(logger, LogLevel.Trace);
	}

	public static LogEventBuilder ForDebugEvent(this ILogger logger)
	{
		return new LogEventBuilder(logger, LogLevel.Debug);
	}

	public static LogEventBuilder ForInfoEvent(this ILogger logger)
	{
		return new LogEventBuilder(logger, LogLevel.Info);
	}

	public static LogEventBuilder ForWarnEvent(this ILogger logger)
	{
		return new LogEventBuilder(logger, LogLevel.Warn);
	}

	public static LogEventBuilder ForErrorEvent(this ILogger logger)
	{
		return new LogEventBuilder(logger, LogLevel.Error);
	}

	public static LogEventBuilder ForFatalEvent(this ILogger logger)
	{
		return new LogEventBuilder(logger, LogLevel.Fatal);
	}

	public static LogEventBuilder ForExceptionEvent(this ILogger logger, Exception? exception, LogLevel? logLevel = null)
	{
		return logger.ForLogEvent(logLevel ?? LogLevel.Error).Exception(exception);
	}

	[Conditional("DEBUG")]
	public static void ConditionalDebug<T>(this ILogger logger, T? value)
	{
		logger.Debug(value);
	}

	[Conditional("DEBUG")]
	public static void ConditionalDebug<T>(this ILogger logger, IFormatProvider? formatProvider, T? value)
	{
		logger.Debug(formatProvider, value);
	}

	[Conditional("DEBUG")]
	public static void ConditionalDebug(this ILogger logger, LogMessageGenerator messageFunc)
	{
		logger.Debug(messageFunc);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug(this ILogger logger, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Debug(exception, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug(this ILogger logger, Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Debug(exception, formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	public static void ConditionalDebug(this ILogger logger, [Localizable(false)] string message)
	{
		logger.Debug(message);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Debug(message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug(this ILogger logger, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Debug(formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug<TArgument>(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (logger.IsDebugEnabled)
		{
			logger.Debug<object>(message, (object?)argument);
		}
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug<TArgument1, TArgument2>(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (logger.IsDebugEnabled)
		{
			logger.Debug<object, object>(message, (object?)argument1, (object?)argument2);
		}
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalDebug<TArgument1, TArgument2, TArgument3>(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (logger.IsDebugEnabled)
		{
			logger.Debug<object, object, object>(message, (object?)argument1, (object?)argument2, (object?)argument3);
		}
	}

	[Conditional("DEBUG")]
	public static void ConditionalTrace<T>(this ILogger logger, T? value)
	{
		logger.Trace(value);
	}

	[Conditional("DEBUG")]
	public static void ConditionalTrace<T>(this ILogger logger, IFormatProvider? formatProvider, T? value)
	{
		logger.Trace(formatProvider, value);
	}

	[Conditional("DEBUG")]
	public static void ConditionalTrace(this ILogger logger, LogMessageGenerator messageFunc)
	{
		logger.Trace(messageFunc);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace(this ILogger logger, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Trace(exception, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace(this ILogger logger, Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Trace(exception, formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	public static void ConditionalTrace(this ILogger logger, [Localizable(false)] string message)
	{
		logger.Trace(message);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Trace(message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace(this ILogger logger, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		logger.Trace(formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace<TArgument>(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (logger.IsTraceEnabled)
		{
			logger.Trace<object>(message, (object?)argument);
		}
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace<TArgument1, TArgument2>(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (logger.IsTraceEnabled)
		{
			logger.Trace<object, object>(message, (object?)argument1, (object?)argument2);
		}
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public static void ConditionalTrace<TArgument1, TArgument2, TArgument3>(this ILogger logger, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (logger.IsTraceEnabled)
		{
			logger.Trace<object, object, object>(message, (object?)argument1, (object?)argument2, (object?)argument3);
		}
	}

	public static void Log(this ILogger logger, LogLevel level, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsEnabled(level))
		{
			logger.Log(level, exception, messageFunc(), ArrayHelper.Empty<object>());
		}
	}

	public static void Trace(this ILogger logger, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsTraceEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			logger.Trace(exception, messageFunc());
		}
	}

	public static void Debug(this ILogger logger, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsDebugEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			logger.Debug(exception, messageFunc());
		}
	}

	public static void Info(this ILogger logger, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsInfoEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			logger.Info(exception, messageFunc());
		}
	}

	public static void Warn(this ILogger logger, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsWarnEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			logger.Warn(exception, messageFunc());
		}
	}

	public static void Error(this ILogger logger, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsErrorEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			logger.Error(exception, messageFunc());
		}
	}

	public static void Fatal(this ILogger logger, Exception? exception, LogMessageGenerator messageFunc)
	{
		if (logger.IsFatalEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			logger.Fatal(exception, messageFunc());
		}
	}
}
