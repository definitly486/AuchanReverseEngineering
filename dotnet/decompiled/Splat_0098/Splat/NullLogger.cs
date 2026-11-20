using System;
using System.ComponentModel;

namespace Splat;

public class NullLogger : ILogger
{
	public LogLevel Level { get; set; }

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
	}
}
