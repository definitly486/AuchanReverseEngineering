using System;
using System.Threading;
using NLog.Common;

namespace NLog.Internal;

internal static class ExceptionHelper
{
	private const string LoggedKey = "NLog.ExceptionLoggedToInternalLogger";

	public static void MarkAsLoggedToInternalLogger(this Exception exception)
	{
		if (exception != null)
		{
			exception.Data["NLog.ExceptionLoggedToInternalLogger"] = true;
		}
	}

	public static bool IsLoggedToInternalLogger(this Exception exception)
	{
		if (exception != null && exception.Data?.Count > 0)
		{
			return exception.Data["NLog.ExceptionLoggedToInternalLogger"] as bool? == true;
		}
		return false;
	}

	public static bool MustBeRethrown(this Exception exception, IInternalLoggerContext? loggerContext = null, string? callerMemberName = null)
	{
		if (exception.MustBeRethrownImmediately())
		{
			return true;
		}
		bool num = exception is NLogConfigurationException;
		LogFactory logFactory = loggerContext?.LogFactory;
		bool flag = (logFactory != null && logFactory.ThrowExceptions) || LogManager.ThrowExceptions;
		bool flag2 = ((!num) ? flag : (logFactory?.ThrowConfigExceptions ?? LogManager.ThrowConfigExceptions ?? flag));
		if (!exception.IsLoggedToInternalLogger())
		{
			LogLevel level = (flag2 ? LogLevel.Error : LogLevel.Warn);
			if (loggerContext != null)
			{
				if (string.IsNullOrEmpty(callerMemberName))
				{
					InternalLogger.Log(exception, level, "{0}: Error has been raised.", new ReadOnlySpan<object>(new object[1] { loggerContext }));
				}
				else
				{
					InternalLogger.Log(exception, level, "{0}: Exception in {1}", new ReadOnlySpan<object>(new object[2] { loggerContext, callerMemberName }));
				}
			}
			else
			{
				InternalLogger.Log(exception, level, "Error has been raised.");
			}
		}
		return flag2;
	}

	public static bool MustBeRethrownImmediately(this Exception exception)
	{
		if (exception is StackOverflowException)
		{
			return true;
		}
		if (exception is ThreadAbortException)
		{
			return true;
		}
		if (exception is OutOfMemoryException)
		{
			return true;
		}
		return false;
	}
}
