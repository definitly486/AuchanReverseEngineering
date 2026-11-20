#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Splat;

public class DebugLogger : ILogger
{
	public LogLevel Level { get; set; }

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Debug.WriteLine(message);
		}
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Debug.WriteLine($"{message} - {exception}");
		}
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Debug.WriteLine(message, type?.Name);
		}
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Debug.WriteLine($"{message} - {exception}", type?.Name);
		}
	}
}
