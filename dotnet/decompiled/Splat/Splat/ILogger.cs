using System;
using System.ComponentModel;

namespace Splat;

public interface ILogger
{
	LogLevel Level { get; }

	void Write([Localizable(false)] string message, LogLevel logLevel);

	void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel);

	void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel);

	void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel);
}
