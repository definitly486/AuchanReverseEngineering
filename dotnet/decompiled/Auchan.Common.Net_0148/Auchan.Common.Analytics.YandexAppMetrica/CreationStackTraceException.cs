using System;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public class CreationStackTraceException : Exception
{
	private readonly string? _stackTrace = Environment.StackTrace;

	public override string StackTrace => _stackTrace ?? base.StackTrace ?? "stack trace is not available";

	public CreationStackTraceException()
	{
	}

	public CreationStackTraceException(string message)
		: base(message)
	{
	}

	public CreationStackTraceException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
