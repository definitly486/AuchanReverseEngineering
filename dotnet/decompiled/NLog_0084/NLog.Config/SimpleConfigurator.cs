using System;
using System.ComponentModel;
using NLog.Internal;
using NLog.Targets;

namespace NLog.Config;

[Obsolete("Use LogManager.Setup().LoadConfiguration() instead. Marked obsolete on NLog 5.2")]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class SimpleConfigurator
{
	[Obsolete("Use LogManager.Setup().LoadConfiguration(c => c.ForLogger().WriteToConsole()) instead. Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ConfigureForConsoleLogging()
	{
		ConfigureForConsoleLogging(LogLevel.Info);
	}

	[Obsolete("Use LogManager.Setup().LoadConfiguration(c => c.ForLogger(minLevel).WriteToConsole()) instead. Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ConfigureForConsoleLogging(LogLevel minLevel)
	{
		ConsoleTarget target = new ConsoleTarget();
		LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
		loggingConfiguration.AddRule(minLevel, LogLevel.MaxLevel, target);
		LogManager.Configuration = loggingConfiguration;
	}

	[Obsolete("Use LogManager.Setup().LoadConfiguration(c => c.ForLogger().WriteTo(target)) instead. Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ConfigureForTargetLogging(Target target)
	{
		Guard.ThrowIfNull(target, "target");
		ConfigureForTargetLogging(target, LogLevel.Info);
	}

	[Obsolete("Use LogManager.Setup().LoadConfiguration(c => c.ForLogger(minLevel).WriteTo(target)) instead. Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ConfigureForTargetLogging(Target target, LogLevel minLevel)
	{
		Guard.ThrowIfNull(target, "target");
		LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
		loggingConfiguration.AddRule(minLevel, LogLevel.MaxLevel, target);
		LogManager.Configuration = loggingConfiguration;
	}

	[Obsolete("Use LogManager.Setup().LoadConfiguration(c => c.ForLogger().WriteToFile(fileName)) instead. Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ConfigureForFileLogging(string fileName)
	{
		ConfigureForFileLogging(fileName, LogLevel.Info);
	}

	[Obsolete("Use LogManager.Setup().LoadConfiguration(c => c.ForLogger(minLevel).WriteToFile(fileName)) instead. Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ConfigureForFileLogging(string fileName, LogLevel minLevel)
	{
		ConfigureForTargetLogging(new FileTarget
		{
			FileName = fileName
		}, minLevel);
	}
}
