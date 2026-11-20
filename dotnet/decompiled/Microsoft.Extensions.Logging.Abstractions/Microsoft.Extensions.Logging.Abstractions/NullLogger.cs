using System;

namespace Microsoft.Extensions.Logging.Abstractions;

public class NullLogger<T> : ILogger<T>, ILogger
{
	public static readonly NullLogger<T> Instance = new NullLogger<T>();

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
	}
}
