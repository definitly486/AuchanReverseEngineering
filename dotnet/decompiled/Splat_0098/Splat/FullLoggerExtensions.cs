using System;

namespace Splat;

public static class FullLoggerExtensions
{
	public static void Debug(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsDebugEnabled)
		{
			logger.Debug(function());
		}
	}

	public static void Debug<T>(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsDebugEnabled)
		{
			logger.Debug<T>(function());
		}
	}

	public static void DebugException(this IFullLogger logger, Func<string> function, Exception exception)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsDebugEnabled)
		{
			logger.DebugException(function(), exception);
		}
	}

	public static void Info(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsInfoEnabled)
		{
			logger.Info(function());
		}
	}

	public static void Info<T>(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsInfoEnabled)
		{
			logger.Info<T>(function());
		}
	}

	public static void InfoException(this IFullLogger logger, Func<string> function, Exception exception)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsInfoEnabled)
		{
			logger.InfoException(function(), exception);
		}
	}

	public static void Warn(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsWarnEnabled)
		{
			logger.Warn(function());
		}
	}

	public static void Warn<T>(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsWarnEnabled)
		{
			logger.Warn<T>(function());
		}
	}

	public static void WarnException(this IFullLogger logger, Func<string> function, Exception exception)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsWarnEnabled)
		{
			logger.WarnException(function(), exception);
		}
	}

	public static void Error(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsErrorEnabled)
		{
			logger.Error(function());
		}
	}

	public static void Error<T>(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsErrorEnabled)
		{
			logger.Error<T>(function());
		}
	}

	public static void ErrorException(this IFullLogger logger, Func<string> function, Exception exception)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsErrorEnabled)
		{
			logger.ErrorException(function(), exception);
		}
	}

	public static void Fatal(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsFatalEnabled)
		{
			logger.Fatal(function());
		}
	}

	public static void Fatal<T>(this IFullLogger logger, Func<string> function)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsFatalEnabled)
		{
			logger.Fatal<T>(function());
		}
	}

	public static void FatalException(this IFullLogger logger, Func<string> function, Exception exception)
	{
		logger.ThrowArgumentNullExceptionIfNull("logger");
		function.ThrowArgumentNullExceptionIfNull("function");
		if (logger.IsFatalEnabled)
		{
			logger.ErrorException(function(), exception);
		}
	}
}
