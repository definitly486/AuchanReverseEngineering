using System;
using System.ComponentModel;

namespace Splat;

public class ActionLogger : ILogger
{
	private readonly Action<string, LogLevel> _writeNoType;

	private readonly Action<Exception, string, LogLevel> _writeNoTypeWithException;

	private readonly Action<string, Type, LogLevel> _writeWithType;

	private readonly Action<Exception, string, Type, LogLevel> _writeWithTypeAndException;

	public LogLevel Level { get; set; }

	public ActionLogger(Action<string, LogLevel> writeNoType, Action<string, Type, LogLevel> writeWithType, Action<Exception, string, LogLevel> writeNoTypeWithException, Action<Exception, string, Type, LogLevel> writeWithTypeAndException)
	{
		_writeNoType = writeNoType;
		_writeNoTypeWithException = writeNoTypeWithException;
		_writeWithType = writeWithType;
		_writeWithTypeAndException = writeWithTypeAndException;
		base._002Ector();
	}

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
		_writeNoType?.Invoke(message, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
		_writeNoTypeWithException?.Invoke(exception, message, logLevel);
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		_writeWithType?.Invoke(message, type, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		_writeWithTypeAndException?.Invoke(exception, message, type, logLevel);
	}
}
