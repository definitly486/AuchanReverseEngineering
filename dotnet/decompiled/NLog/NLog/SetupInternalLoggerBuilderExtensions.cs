using System;
using System.Globalization;
using System.IO;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog;

public static class SetupInternalLoggerBuilderExtensions
{
	public static ISetupInternalLoggerBuilder SetMinimumLogLevel(this ISetupInternalLoggerBuilder setupBuilder, LogLevel logLevel)
	{
		LogLevel logLevel2 = InternalLogger.LogLevel;
		InternalLogger.LogLevel = logLevel;
		if (InternalLogger.LogLevel != LogLevel.Off && logLevel2 == LogLevel.Off)
		{
			string logFile = InternalLogger.LogFile;
			if (!string.IsNullOrEmpty(logFile))
			{
				InternalLogger.LogFile = logFile;
			}
		}
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder LogToFile(this ISetupInternalLoggerBuilder setupBuilder, string fileName)
	{
		InternalLogger.LogFile = fileName;
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder LogToConsole(this ISetupInternalLoggerBuilder setupBuilder, bool enabled)
	{
		InternalLogger.LogToConsole = enabled;
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder LogToWriter(this ISetupInternalLoggerBuilder setupBuilder, TextWriter writer)
	{
		InternalLogger.LogWriter = writer;
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder AddEventSubscription(this ISetupInternalLoggerBuilder setupBuilder, InternalEventOccurredHandler eventSubscriber)
	{
		InternalLogger.InternalEventOccurred += eventSubscriber;
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder RemoveEventSubscription(this ISetupInternalLoggerBuilder setupBuilder, InternalEventOccurredHandler eventSubscriber)
	{
		InternalLogger.InternalEventOccurred -= eventSubscriber;
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder ResetConfig(this ISetupInternalLoggerBuilder setupBuilder)
	{
		InternalLogger.Reset();
		return setupBuilder;
	}

	public static ISetupInternalLoggerBuilder SetupFromEnvironmentVariables(this ISetupInternalLoggerBuilder setupBuilder)
	{
		InternalLogger.LogLevel = GetSetting("nlog.internalLogLevel", "NLOG_INTERNAL_LOG_LEVEL", LogLevel.Off);
		InternalLogger.IncludeTimestamp = GetSetting("nlog.internalLogIncludeTimestamp", "NLOG_INTERNAL_INCLUDE_TIMESTAMP", defaultValue: true);
		InternalLogger.LogToConsole = GetSetting("nlog.internalLogToConsole", "NLOG_INTERNAL_LOG_TO_CONSOLE", defaultValue: false);
		InternalLogger.LogToConsoleError = GetSetting("nlog.internalLogToConsoleError", "NLOG_INTERNAL_LOG_TO_CONSOLE_ERROR", defaultValue: false);
		InternalLogger.LogFile = GetSetting("nlog.internalLogFile", "NLOG_INTERNAL_LOG_FILE", string.Empty);
		return setupBuilder;
	}

	private static string? GetAppSettings(string configName)
	{
		return null;
	}

	private static string? GetSettingString(string configName, string envName)
	{
		try
		{
			string appSettings = GetAppSettings(configName);
			if (appSettings != null)
			{
				return appSettings;
			}
		}
		catch (Exception exception)
		{
			if (exception.MustBeRethrownImmediately())
			{
				throw;
			}
		}
		try
		{
			string safeEnvironmentVariable = EnvironmentHelper.GetSafeEnvironmentVariable(envName);
			if (!string.IsNullOrEmpty(safeEnvironmentVariable))
			{
				return safeEnvironmentVariable;
			}
		}
		catch (Exception exception2)
		{
			if (exception2.MustBeRethrownImmediately())
			{
				throw;
			}
		}
		return null;
	}

	private static LogLevel GetSetting(string configName, string envName, LogLevel defaultValue)
	{
		string settingString = GetSettingString(configName, envName);
		if (settingString == null)
		{
			return defaultValue;
		}
		try
		{
			return LogLevel.FromString(settingString);
		}
		catch (Exception exception)
		{
			if (exception.MustBeRethrownImmediately())
			{
				throw;
			}
			return defaultValue;
		}
	}

	private static T GetSetting<T>(string configName, string envName, T defaultValue)
	{
		string settingString = GetSettingString(configName, envName);
		if (settingString == null)
		{
			return defaultValue;
		}
		try
		{
			return (T)Convert.ChangeType(settingString, typeof(T), CultureInfo.InvariantCulture);
		}
		catch (Exception exception)
		{
			if (exception.MustBeRethrownImmediately())
			{
				throw;
			}
			return defaultValue;
		}
	}
}
