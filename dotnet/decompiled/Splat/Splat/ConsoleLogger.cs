using System;
using System.ComponentModel;
using System.Globalization;

namespace Splat;

public class ConsoleLogger : ILogger
{
	public string ExceptionMessageFormat { get; set; } = "{0} - {1}";

	public LogLevel Level { get; set; }

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Console.WriteLine(message);
		}
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Console.WriteLine(string.Format(CultureInfo.InvariantCulture, ExceptionMessageFormat, message, exception));
		}
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Console.WriteLine(message);
		}
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		if (logLevel >= Level)
		{
			Console.WriteLine(string.Format(CultureInfo.InvariantCulture, ExceptionMessageFormat, message, exception));
		}
	}
}
