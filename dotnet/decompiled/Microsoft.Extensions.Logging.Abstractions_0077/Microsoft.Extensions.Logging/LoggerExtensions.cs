using System;

namespace Microsoft.Extensions.Logging;

public static class LoggerExtensions
{
	private static readonly Func<FormattedLogValues, Exception, string> _messageFormatter = MessageFormatter;

	public static void LogDebug(this ILogger logger, string? message, params object?[] args)
	{
		logger.Log(LogLevel.Debug, message, args);
	}

	public static void LogTrace(this ILogger logger, string? message, params object?[] args)
	{
		logger.Log(LogLevel.Trace, message, args);
	}

	public static void LogInformation(this ILogger logger, string? message, params object?[] args)
	{
		logger.Log(LogLevel.Information, message, args);
	}

	public static void LogWarning(this ILogger logger, string? message, params object?[] args)
	{
		logger.Log(LogLevel.Warning, message, args);
	}

	public static void LogError(this ILogger logger, Exception? exception, string? message, params object?[] args)
	{
		logger.Log(LogLevel.Error, exception, message, args);
	}

	public static void Log(this ILogger logger, LogLevel logLevel, string? message, params object?[] args)
	{
		logger.Log(logLevel, 0, null, message, args);
	}

	public static void Log(this ILogger logger, LogLevel logLevel, Exception? exception, string? message, params object?[] args)
	{
		logger.Log(logLevel, 0, exception, message, args);
	}

	public static void Log(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string? message, params object?[] args)
	{
		System.ThrowHelper.ThrowIfNull(logger, "logger");
		logger.Log(logLevel, eventId, new FormattedLogValues(message, args), exception, _messageFormatter);
	}

	private static string MessageFormatter(FormattedLogValues state, Exception error)
	{
		return state.ToString();
	}
}
