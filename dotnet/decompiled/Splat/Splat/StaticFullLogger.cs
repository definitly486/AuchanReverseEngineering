using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Splat;

public sealed class StaticFullLogger : IStaticFullLogger
{
	private readonly IFullLogger _fullLogger = fullLogger ?? throw new ArgumentNullException("fullLogger");

	public LogLevel Level => _fullLogger.Level;

	public StaticFullLogger(IFullLogger fullLogger)
	{
	}

	public void Debug(Exception exception, string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Debug(exception, GetSuffixedCallerData(message, callerMemberName));
	}

	public void Debug(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Debug(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Debug<T>(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Debug<T>(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Debug<TArgument>(IFormatProvider formatProvider, string message, TArgument argument, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Debug(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument);
	}

	public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Debug(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2);
	}

	public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Debug(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2, argument3);
	}

	public void Info(Exception exception, string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Info(exception, GetSuffixedCallerData(message, callerMemberName));
	}

	public void Info(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Info(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Info<T>(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Info<T>(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Info<TArgument>(IFormatProvider formatProvider, string message, TArgument argument, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Info(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument);
	}

	public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Info(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2);
	}

	public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Info(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2, argument3);
	}

	public void Warn(Exception exception, string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Warn(exception, GetSuffixedCallerData(message, callerMemberName));
	}

	public void Warn(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Warn(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Warn<T>(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Warn<T>(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Warn<TArgument>(IFormatProvider formatProvider, string message, TArgument argument, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Warn(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument);
	}

	public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Warn(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2);
	}

	public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Warn(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2, argument3);
	}

	public void Error(Exception exception, string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Error(exception, GetSuffixedCallerData(message, callerMemberName));
	}

	public void Error(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Error(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Error<T>(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Error<T>(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Error<TArgument>(IFormatProvider formatProvider, string message, TArgument argument, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Error(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument);
	}

	public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Error(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2);
	}

	public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Error(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2, argument3);
	}

	public void Fatal(Exception exception, string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Fatal(exception, GetSuffixedCallerData(message, callerMemberName));
	}

	public void Fatal(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Fatal(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Fatal<T>(string? message, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Fatal<T>(GetSuffixedCallerData(message, callerMemberName));
	}

	public void Fatal<TArgument>(IFormatProvider formatProvider, string message, TArgument argument, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Fatal(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument);
	}

	public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Fatal(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2);
	}

	public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string? message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Fatal(formatProvider, GetSuffixedCallerData(message, callerMemberName), argument1, argument2, argument3);
	}

	public void Write(string? message, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Write(GetSuffixedCallerData(message, callerMemberName), logLevel);
	}

	public void Write(Exception exception, string? message, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Write(exception, GetSuffixedCallerData(message, callerMemberName), logLevel);
	}

	public void Write([Localizable(false)] string? message, [Localizable(false)] Type type, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Write(GetSuffixedCallerData(message, callerMemberName), type, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string? message, [Localizable(false)] Type type, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null)
	{
		_fullLogger.Write(exception, GetSuffixedCallerData(message, callerMemberName), type, logLevel);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string GetSuffixedCallerData(string? message, string? callerMemberName)
	{
		return message + " (" + callerMemberName + ")";
	}
}
