using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace NLog.Config;

public sealed class InstallationContext : IDisposable
{
	private static readonly Dictionary<LogLevel, ConsoleColor> LogLevel2ConsoleColor = new Dictionary<LogLevel, ConsoleColor>
	{
		{
			NLog.LogLevel.Trace,
			ConsoleColor.DarkGray
		},
		{
			NLog.LogLevel.Debug,
			ConsoleColor.Gray
		},
		{
			NLog.LogLevel.Info,
			ConsoleColor.White
		},
		{
			NLog.LogLevel.Warn,
			ConsoleColor.Yellow
		},
		{
			NLog.LogLevel.Error,
			ConsoleColor.Red
		},
		{
			NLog.LogLevel.Fatal,
			ConsoleColor.DarkRed
		}
	};

	public LogLevel LogLevel { get; set; }

	public bool IgnoreFailures { get; set; }

	public bool ThrowExceptions { get; set; }

	public IDictionary<string, string> Parameters { get; }

	public TextWriter? LogOutput { get; set; }

	public InstallationContext()
		: this(TextWriter.Null)
	{
	}

	public InstallationContext(TextWriter logOutput)
	{
		LogOutput = logOutput;
		Parameters = new Dictionary<string, string>();
		LogLevel = NLog.LogLevel.Info;
		ThrowExceptions = false;
	}

	public void Trace([Localizable(false)] string message, params object[] arguments)
	{
		Log(NLog.LogLevel.Trace, message, arguments);
	}

	public void Debug([Localizable(false)] string message, params object[] arguments)
	{
		Log(NLog.LogLevel.Debug, message, arguments);
	}

	public void Info([Localizable(false)] string message, params object[] arguments)
	{
		Log(NLog.LogLevel.Info, message, arguments);
	}

	public void Warning([Localizable(false)] string message, params object[] arguments)
	{
		Log(NLog.LogLevel.Warn, message, arguments);
	}

	public void Error([Localizable(false)] string message, params object[] arguments)
	{
		Log(NLog.LogLevel.Error, message, arguments);
	}

	public void Dispose()
	{
		LogOutput?.Close();
		LogOutput = null;
	}

	public LogEventInfo CreateLogEvent()
	{
		LogEventInfo logEventInfo = LogEventInfo.CreateNullEvent();
		foreach (KeyValuePair<string, string> parameter in Parameters)
		{
			logEventInfo.Properties.Add(parameter.Key, parameter.Value);
		}
		return logEventInfo;
	}

	private void Log(LogLevel logLevel, string message, object[] arguments)
	{
		if (logLevel >= LogLevel)
		{
			if (arguments != null && arguments.Length != 0)
			{
				message = string.Format(CultureInfo.InvariantCulture, message, arguments);
			}
			ConsoleColor foregroundColor = Console.ForegroundColor;
			Console.ForegroundColor = LogLevel2ConsoleColor[logLevel];
			try
			{
				LogOutput?.WriteLine(message);
			}
			finally
			{
				Console.ForegroundColor = foregroundColor;
			}
		}
	}
}
