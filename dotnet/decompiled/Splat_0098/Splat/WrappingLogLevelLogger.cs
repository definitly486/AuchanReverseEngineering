using System;
using System.ComponentModel;

namespace Splat;

public class WrappingLogLevelLogger(ILogger inner) : ILogger
{
	private readonly ILogger _inner = inner;

	public LogLevel Level => inner.Level;

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
		inner.Write($"{logLevel}: {message}", logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
		inner.Write(exception, $"{logLevel}: {message}", logLevel);
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		inner.Write($"{logLevel}: {message}", type, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		inner.Write(exception, $"{logLevel}: {message}", type, logLevel);
	}
}
