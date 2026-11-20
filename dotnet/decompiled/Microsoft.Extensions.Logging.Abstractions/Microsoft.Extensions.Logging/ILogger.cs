using System;

namespace Microsoft.Extensions.Logging;

public interface ILogger
{
	void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter);
}
public interface ILogger<out TCategoryName> : ILogger
{
}
