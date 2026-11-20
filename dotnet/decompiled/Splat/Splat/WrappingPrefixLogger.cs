using System;
using System.ComponentModel;

namespace Splat;

public class WrappingPrefixLogger : ILogger
{
	private readonly ILogger _inner;

	private readonly string _prefix;

	public LogLevel Level => _inner.Level;

	public WrappingPrefixLogger(ILogger inner, Type callingType)
	{
		_inner = inner;
		_prefix = callingType?.Name + ": ";
		base._002Ector();
	}

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
		_inner.Write(_prefix + message, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
		_inner.Write(exception, _prefix + message, logLevel);
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		type.ThrowArgumentNullExceptionIfNull("type");
		_inner.Write(type.Name + ": " + message, type, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		type.ThrowArgumentNullExceptionIfNull("type");
		_inner.Write(exception, type.Name + ": " + message, type, logLevel);
	}
}
