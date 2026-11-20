using System;

namespace NLog.Common;

public readonly struct InternalLogEventArgs
{
	public string Message { get; }

	public LogLevel Level { get; }

	public Exception? Exception { get; }

	public Type? SenderType { get; }

	public string? SenderName { get; }

	internal InternalLogEventArgs(string message, LogLevel level, Exception? exception, Type? senderType, string? senderName)
	{
		Message = message;
		Level = level;
		Exception = exception;
		SenderType = senderType;
		SenderName = senderName;
	}
}
