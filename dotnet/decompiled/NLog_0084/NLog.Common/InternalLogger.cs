using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NLog.Internal;
using NLog.Internal.Fakeables;
using NLog.LayoutRenderers;
using NLog.Targets;
using NLog.Time;

namespace NLog.Common;

public static class InternalLogger
{
	private static readonly object LockObject = new object();

	private static LogLevel _logLevel = NLog.LogLevel.Off;

	private static bool _logToConsole;

	private static bool _logToConsoleError;

	private static string? _logFile;

	public static bool IsTraceEnabled => IsLogLevelEnabled(NLog.LogLevel.Trace);

	public static bool IsDebugEnabled => IsLogLevelEnabled(NLog.LogLevel.Debug);

	public static bool IsInfoEnabled => IsLogLevelEnabled(NLog.LogLevel.Info);

	public static bool IsWarnEnabled => IsLogLevelEnabled(NLog.LogLevel.Warn);

	public static bool IsErrorEnabled => IsLogLevelEnabled(NLog.LogLevel.Error);

	public static bool IsFatalEnabled => IsLogLevelEnabled(NLog.LogLevel.Fatal);

	public static LogLevel LogLevel
	{
		get
		{
			return _logLevel;
		}
		set
		{
			_logLevel = value ?? NLog.LogLevel.Off;
		}
	}

	public static bool LogToConsole
	{
		get
		{
			return _logToConsole;
		}
		set
		{
			if (_logToConsole != value)
			{
				InternalEventOccurred -= LogToConsoleSubscription;
				if (value)
				{
					InternalEventOccurred += LogToConsoleSubscription;
				}
				_logToConsole = value;
			}
		}
	}

	public static bool LogToConsoleError
	{
		get
		{
			return _logToConsoleError;
		}
		set
		{
			if (_logToConsoleError != value)
			{
				InternalEventOccurred -= LogToConsoleErrorSubscription;
				if (value)
				{
					InternalEventOccurred += LogToConsoleErrorSubscription;
				}
				_logToConsoleError = value;
			}
		}
	}

	public static string? LogFile
	{
		get
		{
			return _logFile;
		}
		set
		{
			if (!string.Equals(_logFile, value))
			{
				InternalEventOccurred -= LogToFileSubscription;
				if (!string.IsNullOrEmpty(value))
				{
					InternalEventOccurred += LogToFileSubscription;
				}
				_logFile = value;
			}
			string text = (_logFile = ((value != null && !string.IsNullOrEmpty(value)) ? ExpandFilePathVariables(value) : null));
			if (text != null)
			{
				CreateDirectoriesIfNeeded(text);
			}
		}
	}

	public static TextWriter? LogWriter { get; set; }

	public static bool IncludeTimestamp { get; set; } = true;

	internal static bool ExceptionThrowWhenWriting { get; private set; }

	public static event InternalEventOccurredHandler? InternalEventOccurred;

	[StringFormatMethod("message")]
	public static void Trace([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsTraceEnabled)
		{
			Write(null, NLog.LogLevel.Trace, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Trace(Exception? ex, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsTraceEnabled)
		{
			Write(ex, NLog.LogLevel.Trace, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Trace([Localizable(false)] string message, params object?[] args)
	{
		Write(null, NLog.LogLevel.Trace, message, args);
	}

	public static void Trace([Localizable(false)] string message)
	{
		Write(null, NLog.LogLevel.Trace, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Trace(Func<string> messageFunc)
	{
		if (IsTraceEnabled)
		{
			Write(null, NLog.LogLevel.Trace, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Trace(Exception? ex, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, NLog.LogLevel.Trace, message, args);
	}

	[StringFormatMethod("message")]
	public static void Trace<TArgument1>([Localizable(false)] string message, TArgument1? arg0)
	{
		if (IsTraceEnabled)
		{
			Log(null, NLog.LogLevel.Trace, message, new ReadOnlySpan<object>(new object[1] { arg0 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Trace<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1)
	{
		if (IsTraceEnabled)
		{
			Log(null, NLog.LogLevel.Trace, message, new ReadOnlySpan<object>(new object[2] { arg0, arg1 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Trace<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1, TArgument3? arg2)
	{
		if (IsTraceEnabled)
		{
			Log(null, NLog.LogLevel.Trace, message, new ReadOnlySpan<object>(new object[3] { arg0, arg1, arg2 }));
		}
	}

	public static void Trace(Exception? ex, [Localizable(false)] string message)
	{
		Write(ex, NLog.LogLevel.Trace, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Trace(Exception? ex, Func<string> messageFunc)
	{
		if (IsTraceEnabled)
		{
			Write(ex, NLog.LogLevel.Trace, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Debug([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsDebugEnabled)
		{
			Write(null, NLog.LogLevel.Debug, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Debug(Exception? ex, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsDebugEnabled)
		{
			Write(ex, NLog.LogLevel.Debug, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Debug([Localizable(false)] string message, params object?[] args)
	{
		Write(null, NLog.LogLevel.Debug, message, args);
	}

	public static void Debug([Localizable(false)] string message)
	{
		Write(null, NLog.LogLevel.Debug, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Debug(Func<string> messageFunc)
	{
		if (IsDebugEnabled)
		{
			Write(null, NLog.LogLevel.Debug, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Debug(Exception? ex, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, NLog.LogLevel.Debug, message, args);
	}

	[StringFormatMethod("message")]
	public static void Debug<TArgument1>([Localizable(false)] string message, TArgument1? arg0)
	{
		if (IsDebugEnabled)
		{
			Log(null, NLog.LogLevel.Debug, message, new ReadOnlySpan<object>(new object[1] { arg0 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Debug<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1)
	{
		if (IsDebugEnabled)
		{
			Log(null, NLog.LogLevel.Debug, message, new ReadOnlySpan<object>(new object[2] { arg0, arg1 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1, TArgument3? arg2)
	{
		if (IsDebugEnabled)
		{
			Log(null, NLog.LogLevel.Debug, message, new ReadOnlySpan<object>(new object[3] { arg0, arg1, arg2 }));
		}
	}

	public static void Debug(Exception? ex, [Localizable(false)] string message)
	{
		Write(ex, NLog.LogLevel.Debug, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Debug(Exception? ex, Func<string> messageFunc)
	{
		if (IsDebugEnabled)
		{
			Write(ex, NLog.LogLevel.Debug, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Info([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsInfoEnabled)
		{
			Write(null, NLog.LogLevel.Info, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Info(Exception? ex, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsInfoEnabled)
		{
			Write(ex, NLog.LogLevel.Info, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Info([Localizable(false)] string message, params object?[] args)
	{
		Write(null, NLog.LogLevel.Info, message, args);
	}

	public static void Info([Localizable(false)] string message)
	{
		Write(null, NLog.LogLevel.Info, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Info(Func<string> messageFunc)
	{
		if (IsInfoEnabled)
		{
			Write(null, NLog.LogLevel.Info, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Info(Exception? ex, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, NLog.LogLevel.Info, message, args);
	}

	[StringFormatMethod("message")]
	public static void Info<TArgument1>([Localizable(false)] string message, TArgument1? arg0)
	{
		if (IsInfoEnabled)
		{
			Log(null, NLog.LogLevel.Info, message, new ReadOnlySpan<object>(new object[1] { arg0 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Info<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1)
	{
		if (IsInfoEnabled)
		{
			Log(null, NLog.LogLevel.Info, message, new ReadOnlySpan<object>(new object[2] { arg0, arg1 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1, TArgument3? arg2)
	{
		if (IsInfoEnabled)
		{
			Log(null, NLog.LogLevel.Info, message, new ReadOnlySpan<object>(new object[3] { arg0, arg1, arg2 }));
		}
	}

	public static void Info(Exception? ex, [Localizable(false)] string message)
	{
		Write(ex, NLog.LogLevel.Info, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Info(Exception? ex, Func<string> messageFunc)
	{
		if (IsInfoEnabled)
		{
			Write(ex, NLog.LogLevel.Info, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Warn([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsWarnEnabled)
		{
			Write(null, NLog.LogLevel.Warn, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Warn(Exception? ex, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsWarnEnabled)
		{
			Write(ex, NLog.LogLevel.Warn, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Warn([Localizable(false)] string message, params object?[] args)
	{
		Write(null, NLog.LogLevel.Warn, message, args);
	}

	public static void Warn([Localizable(false)] string message)
	{
		Write(null, NLog.LogLevel.Warn, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Warn(Func<string> messageFunc)
	{
		if (IsWarnEnabled)
		{
			Write(null, NLog.LogLevel.Warn, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Warn(Exception? ex, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, NLog.LogLevel.Warn, message, args);
	}

	[StringFormatMethod("message")]
	public static void Warn<TArgument1>([Localizable(false)] string message, TArgument1? arg0)
	{
		if (IsWarnEnabled)
		{
			Log(null, NLog.LogLevel.Warn, message, new ReadOnlySpan<object>(new object[1] { arg0 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Warn<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1)
	{
		if (IsWarnEnabled)
		{
			Log(null, NLog.LogLevel.Warn, message, new ReadOnlySpan<object>(new object[2] { arg0, arg1 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1, TArgument3? arg2)
	{
		if (IsWarnEnabled)
		{
			Log(null, NLog.LogLevel.Warn, message, new ReadOnlySpan<object>(new object[3] { arg0, arg1, arg2 }));
		}
	}

	public static void Warn(Exception? ex, [Localizable(false)] string message)
	{
		Write(ex, NLog.LogLevel.Warn, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Warn(Exception? ex, Func<string> messageFunc)
	{
		if (IsWarnEnabled)
		{
			Write(ex, NLog.LogLevel.Warn, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Error([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsErrorEnabled)
		{
			Write(null, NLog.LogLevel.Error, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Error(Exception? ex, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsErrorEnabled)
		{
			Write(ex, NLog.LogLevel.Error, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Error([Localizable(false)] string message, params object?[] args)
	{
		Write(null, NLog.LogLevel.Error, message, args);
	}

	public static void Error([Localizable(false)] string message)
	{
		Write(null, NLog.LogLevel.Error, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Error(Func<string> messageFunc)
	{
		if (IsErrorEnabled)
		{
			Write(null, NLog.LogLevel.Error, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Error(Exception? ex, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, NLog.LogLevel.Error, message, args);
	}

	[StringFormatMethod("message")]
	public static void Error<TArgument1>([Localizable(false)] string message, TArgument1? arg0)
	{
		if (IsErrorEnabled)
		{
			Log(null, NLog.LogLevel.Error, message, new ReadOnlySpan<object>(new object[1] { arg0 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Error<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1)
	{
		if (IsErrorEnabled)
		{
			Log(null, NLog.LogLevel.Error, message, new ReadOnlySpan<object>(new object[2] { arg0, arg1 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1, TArgument3? arg2)
	{
		if (IsErrorEnabled)
		{
			Log(null, NLog.LogLevel.Error, message, new ReadOnlySpan<object>(new object[3] { arg0, arg1, arg2 }));
		}
	}

	public static void Error(Exception? ex, [Localizable(false)] string message)
	{
		Write(ex, NLog.LogLevel.Error, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Error(Exception? ex, Func<string> messageFunc)
	{
		if (IsErrorEnabled)
		{
			Write(ex, NLog.LogLevel.Error, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Fatal([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsFatalEnabled)
		{
			Write(null, NLog.LogLevel.Fatal, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Fatal(Exception? ex, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsFatalEnabled)
		{
			Write(ex, NLog.LogLevel.Fatal, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Fatal([Localizable(false)] string message, params object?[] args)
	{
		Write(null, NLog.LogLevel.Fatal, message, args);
	}

	public static void Fatal([Localizable(false)] string message)
	{
		Write(null, NLog.LogLevel.Fatal, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Fatal(Func<string> messageFunc)
	{
		if (IsFatalEnabled)
		{
			Write(null, NLog.LogLevel.Fatal, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Fatal(Exception? ex, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, NLog.LogLevel.Fatal, message, args);
	}

	[StringFormatMethod("message")]
	public static void Fatal<TArgument1>([Localizable(false)] string message, TArgument1? arg0)
	{
		if (IsFatalEnabled)
		{
			Log(null, NLog.LogLevel.Fatal, message, new ReadOnlySpan<object>(new object[1] { arg0 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Fatal<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1)
	{
		if (IsFatalEnabled)
		{
			Log(null, NLog.LogLevel.Fatal, message, new ReadOnlySpan<object>(new object[2] { arg0, arg1 }));
		}
	}

	[StringFormatMethod("message")]
	public static void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1? arg0, TArgument2? arg1, TArgument3? arg2)
	{
		if (IsFatalEnabled)
		{
			Log(null, NLog.LogLevel.Fatal, message, new ReadOnlySpan<object>(new object[3] { arg0, arg1, arg2 }));
		}
	}

	public static void Fatal(Exception? ex, [Localizable(false)] string message)
	{
		Write(ex, NLog.LogLevel.Fatal, message, null);
	}

	[Obsolete("Avoid delegate capture allocations. Marked obsolete with v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Fatal(Exception? ex, Func<string> messageFunc)
	{
		if (IsFatalEnabled)
		{
			Write(ex, NLog.LogLevel.Fatal, messageFunc(), null);
		}
	}

	public static void Reset()
	{
		ExceptionThrowWhenWriting = false;
		LogWriter = null;
		InternalLogger.InternalEventOccurred = null;
		LogLevel = NLog.LogLevel.Off;
		IncludeTimestamp = true;
		LogToConsole = false;
		LogToConsoleError = false;
		LogFile = null;
	}

	[StringFormatMethod("message")]
	public static void Log(LogLevel level, [Localizable(false)] string message, params object?[] args)
	{
		Write(null, level, message, args);
	}

	[StringFormatMethod("message")]
	public static void Log(LogLevel level, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsLogLevelEnabled(level))
		{
			Write(null, level, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	[StringFormatMethod("message")]
	public static void Log(Exception? ex, LogLevel level, [Localizable(false)] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsLogLevelEnabled(level))
		{
			Write(ex, level, message, args.IsEmpty ? null : args.ToArray());
		}
	}

	public static void Log(LogLevel level, [Localizable(false)] string message)
	{
		Write(null, level, message, null);
	}

	public static void Log(LogLevel level, [Localizable(false)] Func<string> messageFunc)
	{
		if (IsLogLevelEnabled(level))
		{
			Write(null, level, messageFunc(), null);
		}
	}

	public static void Log(Exception? ex, LogLevel level, [Localizable(false)] Func<string> messageFunc)
	{
		if (IsLogLevelEnabled(level))
		{
			Write(ex, level, messageFunc(), null);
		}
	}

	[StringFormatMethod("message")]
	public static void Log(Exception? ex, LogLevel level, [Localizable(false)] string message, params object?[] args)
	{
		Write(ex, level, message, args);
	}

	public static void Log(Exception? ex, LogLevel level, [Localizable(false)] string message)
	{
		Write(ex, level, message, null);
	}

	private static void Write(Exception? ex, LogLevel level, string message, object?[]? args)
	{
		if (!IsLogLevelEnabled(level) || IsSeriousException(ex) || (InternalLogger.InternalEventOccurred == null && LogWriter == null))
		{
			return;
		}
		string fullMessage = message;
		try
		{
			fullMessage = ((args != null && args.Length != 0) ? string.Format(CultureInfo.InvariantCulture, message, args) : message);
		}
		catch (Exception ex2)
		{
			if (ex == null)
			{
				ex = ex2;
			}
			if (NLog.LogLevel.Error > level)
			{
				level = NLog.LogLevel.Error;
			}
		}
		try
		{
			IInternalLoggerContext loggerContext = ((args != null && args.Length != 0) ? (args[0] as IInternalLoggerContext) : null);
			WriteToLog(level, ex, fullMessage, loggerContext);
			ex?.MarkAsLoggedToInternalLogger();
		}
		catch (Exception exception)
		{
			ExceptionThrowWhenWriting = true;
			if (exception.MustBeRethrownImmediately())
			{
				throw;
			}
		}
	}

	private static void WriteToLog(LogLevel level, Exception? ex, string fullMessage, IInternalLoggerContext? loggerContext)
	{
		if (LogWriter != null)
		{
			string value = CreateLogLine(ex, level, fullMessage);
			lock (LockObject)
			{
				LogWriter?.WriteLine(value);
			}
		}
		if (InternalLogger.InternalEventOccurred != null)
		{
			string senderName = ((loggerContext != null && !string.IsNullOrEmpty(loggerContext.Name)) ? loggerContext.Name : loggerContext?.ToString());
			InternalLogger.InternalEventOccurred?.Invoke(null, new InternalLogEventArgs(fullMessage, level, ex, loggerContext?.GetType(), senderName));
		}
	}

	private static string CreateLogLine(Exception? ex, LogLevel level, string fullMessage)
	{
		if (IncludeTimestamp)
		{
			return TimeSource.Current.Time.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture) + " " + level.ToString() + " " + fullMessage + ((ex != null) ? " Exception: " : string.Empty) + (ex?.ToString() ?? "");
		}
		return level.ToString() + " " + fullMessage + ((ex != null) ? " Exception: " : string.Empty) + (ex?.ToString() ?? string.Empty);
	}

	private static bool IsSeriousException(Exception? exception)
	{
		return exception?.MustBeRethrownImmediately() ?? false;
	}

	private static bool IsLogLevelEnabled(LogLevel logLevel)
	{
		if ((object)_logLevel != NLog.LogLevel.Off)
		{
			return _logLevel.CompareTo(logLevel) <= 0;
		}
		return false;
	}

	internal static bool HasActiveLoggers()
	{
		if (InternalLogger.InternalEventOccurred == null && LogWriter == null)
		{
			return false;
		}
		return true;
	}

	private static void CreateDirectoriesIfNeeded(string filename)
	{
		try
		{
			if (!(LogLevel == NLog.LogLevel.Off))
			{
				string directoryName = Path.GetDirectoryName(filename);
				if (!string.IsNullOrEmpty(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
			}
		}
		catch (Exception ex)
		{
			Error(ex, "Cannot create needed directories to '{0}'.", new ReadOnlySpan<object>(new object[1] { filename }));
			if (ex.MustBeRethrownImmediately())
			{
				throw;
			}
		}
	}

	private static string ExpandFilePathVariables(string internalLogFile)
	{
		try
		{
			if (ContainsSubStringIgnoreCase(internalLogFile, "${currentdir}", out string result))
			{
				internalLogFile = internalLogFile.Replace(result, Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar);
			}
			if (ContainsSubStringIgnoreCase(internalLogFile, "${basedir}", out string result2))
			{
				internalLogFile = internalLogFile.Replace(result2, LogManager.LogFactory.CurrentAppEnvironment.AppDomainBaseDirectory + Path.DirectorySeparatorChar);
			}
			if (ContainsSubStringIgnoreCase(internalLogFile, "${tempdir}", out string result3))
			{
				internalLogFile = internalLogFile.Replace(result3, LogManager.LogFactory.CurrentAppEnvironment.UserTempFilePath + Path.DirectorySeparatorChar);
			}
			if (ContainsSubStringIgnoreCase(internalLogFile, "${processdir}", out string result4))
			{
				internalLogFile = internalLogFile.Replace(result4, Path.GetDirectoryName(LogManager.LogFactory.CurrentAppEnvironment.CurrentProcessFilePath) + Path.DirectorySeparatorChar);
			}
			if (ContainsSubStringIgnoreCase(internalLogFile, "${commonApplicationDataDir}", out string result5))
			{
				internalLogFile = internalLogFile.Replace(result5, SpecialFolderLayoutRenderer.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + Path.DirectorySeparatorChar);
			}
			if (ContainsSubStringIgnoreCase(internalLogFile, "${userApplicationDataDir}", out string result6))
			{
				internalLogFile = internalLogFile.Replace(result6, SpecialFolderLayoutRenderer.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar);
			}
			if (ContainsSubStringIgnoreCase(internalLogFile, "${userLocalApplicationDataDir}", out string result7))
			{
				internalLogFile = internalLogFile.Replace(result7, SpecialFolderLayoutRenderer.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar);
			}
			if (internalLogFile.IndexOf('%') >= 0)
			{
				internalLogFile = Environment.ExpandEnvironmentVariables(internalLogFile);
			}
			if (!string.IsNullOrEmpty(internalLogFile) && internalLogFile.IndexOf('.') >= 0)
			{
				internalLogFile = AppEnvironmentWrapper.FixFilePathWithLongUNC(internalLogFile);
			}
			return internalLogFile;
		}
		catch
		{
			return internalLogFile;
		}
	}

	private static bool ContainsSubStringIgnoreCase(string haystack, string needle, out string? result)
	{
		int num = haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
		result = ((num >= 0) ? haystack.Substring(num, needle.Length) : null);
		return result != null;
	}

	private static void LogToConsoleSubscription(object? sender, InternalLogEventArgs eventArgs)
	{
		string message = CreateLogLine(eventArgs.Exception, eventArgs.Level, eventArgs.Message);
		ConsoleTargetHelper.WriteLineThreadSafe(Console.Out, message);
	}

	private static void LogToConsoleErrorSubscription(object? sender, InternalLogEventArgs eventArgs)
	{
		string message = CreateLogLine(eventArgs.Exception, eventArgs.Level, eventArgs.Message);
		ConsoleTargetHelper.WriteLineThreadSafe(Console.Error, message);
	}

	private static void LogToFileSubscription(object? sender, InternalLogEventArgs eventArgs)
	{
		string value = CreateLogLine(eventArgs.Exception, eventArgs.Level, eventArgs.Message);
		lock (LockObject)
		{
			try
			{
				using StreamWriter streamWriter = File.AppendText(_logFile);
				streamWriter.WriteLine(value);
			}
			catch (IOException)
			{
			}
		}
	}
}
