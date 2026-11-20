using System;
using System.Globalization;
using System.Reflection;

namespace Splat;

public class WrappingFullLogger : AllocationFreeLoggerBase, IFullLogger, IAllocationFreeLogger, IAllocationFreeErrorLogger, ILogger
{
	private readonly ILogger _inner = inner ?? throw new ArgumentNullException("inner");

	private readonly MethodInfo _stringFormat = typeof(string).GetMethod("Format", new Type[3]
	{
		typeof(IFormatProvider),
		typeof(string),
		typeof(object[])
	}) ?? throw new InvalidOperationException("Cannot find the Format method which is required.");

	public WrappingFullLogger(ILogger inner)
		: base(inner)
	{
	}

	public void Debug<T>(T value)
	{
		if (value != null)
		{
			_inner.Write(value.ToString() ?? "(null)", LogLevel.Debug);
		}
	}

	public void Debug<T>(IFormatProvider formatProvider, T value)
	{
		_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Debug);
	}

	public void DebugException(string? message, Exception exception)
	{
		_inner.Write(exception, $"{message}: {exception}", LogLevel.Debug);
	}

	public void Debug(Exception exception, string? message)
	{
		_inner.Write(exception, message ?? "", LogLevel.Debug);
	}

	public void Debug(IFormatProvider formatProvider, string message, params object[] args)
	{
		string message2 = InvokeStringFormat(formatProvider, message, args);
		_inner.Write(message2, LogLevel.Debug);
	}

	public void Debug(string? message)
	{
		_inner.Write(message ?? "(null)", LogLevel.Debug);
	}

	public void Debug<T>(string? message)
	{
		_inner.Write(message ?? "(null)", typeof(T), LogLevel.Debug);
	}

	public void Debug(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, LogLevel.Debug);
	}

	public void Debug<T>(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, typeof(T), LogLevel.Debug);
	}

	public void Debug<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
	{
		_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Debug);
	}

	public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Debug);
	}

	public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Debug);
	}

	public void Info<T>(T value)
	{
		if (value != null)
		{
			_inner.Write(value.ToString() ?? "(null)", LogLevel.Info);
		}
	}

	public void Info<T>(IFormatProvider formatProvider, T value)
	{
		_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Info);
	}

	public void InfoException(string? message, Exception exception)
	{
		_inner.Write(exception, $"{message}: {exception}", LogLevel.Info);
	}

	public void Info(Exception exception, string? message)
	{
		_inner.Write(exception, message ?? "", LogLevel.Info);
	}

	public void Info(IFormatProvider formatProvider, string message, params object[] args)
	{
		string message2 = InvokeStringFormat(formatProvider, message, args);
		_inner.Write(message2, LogLevel.Info);
	}

	public void Info(string? message)
	{
		_inner.Write(message ?? "(null)", LogLevel.Info);
	}

	public void Info<T>(string? message)
	{
		_inner.Write(message ?? "(null)", typeof(T), LogLevel.Info);
	}

	public void Info(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, LogLevel.Info);
	}

	public void Info<T>(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, typeof(T), LogLevel.Info);
	}

	public void Info<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
	{
		_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Info);
	}

	public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Info);
	}

	public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Info);
	}

	public void Warn<T>(T value)
	{
		if (value != null)
		{
			_inner.Write(value.ToString() ?? "(null)", LogLevel.Warn);
		}
	}

	public void Warn<T>(IFormatProvider formatProvider, T value)
	{
		_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Warn);
	}

	public void WarnException(string? message, Exception exception)
	{
		_inner.Write(exception, $"{message}: {exception}", LogLevel.Warn);
	}

	public void Warn(Exception exception, string? message)
	{
		_inner.Write(exception, message ?? "", LogLevel.Warn);
	}

	public void Warn(IFormatProvider formatProvider, string message, params object[] args)
	{
		string message2 = InvokeStringFormat(formatProvider, message, args);
		_inner.Write(message2, LogLevel.Warn);
	}

	public void Warn(string? message)
	{
		_inner.Write(message ?? "(null)", LogLevel.Warn);
	}

	public void Warn<T>(string? message)
	{
		_inner.Write(message ?? "(null)", typeof(T), LogLevel.Warn);
	}

	public void Warn(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, LogLevel.Warn);
	}

	public void Warn<T>(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, typeof(T), LogLevel.Warn);
	}

	public void Warn<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
	{
		_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Warn);
	}

	public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Warn);
	}

	public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Warn);
	}

	public void Error<T>(T value)
	{
		if (value != null)
		{
			_inner.Write(value.ToString() ?? "(null)", LogLevel.Error);
		}
	}

	public void Error<T>(IFormatProvider formatProvider, T value)
	{
		_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Error);
	}

	public void ErrorException(string? message, Exception exception)
	{
		_inner.Write(exception, $"{message}: {exception}", LogLevel.Error);
	}

	public void Error(Exception exception, string? message)
	{
		_inner.Write(exception, message ?? "", LogLevel.Error);
	}

	public void Error(IFormatProvider formatProvider, string message, params object[] args)
	{
		string message2 = InvokeStringFormat(formatProvider, message, args);
		_inner.Write(message2, LogLevel.Error);
	}

	public void Error(string? message)
	{
		_inner.Write(message ?? "(null)", LogLevel.Error);
	}

	public void Error<T>(string? message)
	{
		_inner.Write(message ?? "(null)", typeof(T), LogLevel.Error);
	}

	public void Error(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, LogLevel.Error);
	}

	public void Error<T>(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, typeof(T), LogLevel.Error);
	}

	public void Error<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
	{
		_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Error);
	}

	public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Error);
	}

	public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Error);
	}

	public void Fatal<T>(T value)
	{
		if (value != null)
		{
			_inner.Write(value.ToString() ?? "(null)", LogLevel.Fatal);
		}
	}

	public void Fatal<T>(IFormatProvider formatProvider, T value)
	{
		_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Fatal);
	}

	public void FatalException(string? message, Exception exception)
	{
		_inner.Write(exception, $"{message}: {exception}", LogLevel.Fatal);
	}

	public void Fatal(Exception exception, string? message)
	{
		_inner.Write(exception, message ?? "", LogLevel.Fatal);
	}

	public void Fatal(IFormatProvider formatProvider, string message, params object[] args)
	{
		string message2 = InvokeStringFormat(formatProvider, message, args);
		_inner.Write(message2, LogLevel.Fatal);
	}

	public void Fatal(string? message)
	{
		_inner.Write(message ?? "(null)", LogLevel.Fatal);
	}

	public void Fatal<T>(string? message)
	{
		_inner.Write(message ?? "(null)", typeof(T), LogLevel.Fatal);
	}

	public void Fatal(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, LogLevel.Fatal);
	}

	public void Fatal<T>(string message, params object[] args)
	{
		string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
		_inner.Write(message2, typeof(T), LogLevel.Fatal);
	}

	public void Fatal<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
	{
		_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Fatal);
	}

	public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Fatal);
	}

	public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Fatal);
	}

	private string InvokeStringFormat(IFormatProvider formatProvider, string message, object[] args)
	{
		object[] parameters = new object[3] { formatProvider, message, args };
		return ((string)_stringFormat.Invoke(null, parameters)) ?? "(null)";
	}
}
