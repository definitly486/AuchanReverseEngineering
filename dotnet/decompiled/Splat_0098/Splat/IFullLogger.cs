using System;
using System.ComponentModel;

namespace Splat;

public interface IFullLogger : IAllocationFreeLogger, IAllocationFreeErrorLogger, ILogger
{
	void Debug<T>(T value);

	void Debug<T>(IFormatProvider formatProvider, T value);

	[Obsolete("Use void Debug(Exception exception, [Localizable(false)] string? message)")]
	void DebugException([Localizable(false)] string? message, Exception exception);

	void Debug(Exception exception, [Localizable(false)] string? message);

	void Debug(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

	void Debug([Localizable(false)] string? message);

	void Debug<T>([Localizable(false)] string? message);

	void Debug([Localizable(false)] string message, params object[] args);

	void Debug<T>([Localizable(false)] string message, params object[] args);

	void Debug<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

	void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

	void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Info<T>(T value);

	void Info<T>(IFormatProvider formatProvider, T value);

	[Obsolete("Use void Info(Exception exception, [Localizable(false)] string? message)")]
	void InfoException([Localizable(false)] string? message, Exception exception);

	void Info(Exception exception, [Localizable(false)] string? message);

	void Info(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

	void Info([Localizable(false)] string? message);

	void Info<T>([Localizable(false)] string? message);

	void Info([Localizable(false)] string message, params object[] args);

	void Info<T>([Localizable(false)] string message, params object[] args);

	void Info<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

	void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

	void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Warn<T>(T value);

	void Warn<T>(IFormatProvider formatProvider, T value);

	[Obsolete("Use void Warn(Exception exception, [Localizable(false)] string? message)")]
	void WarnException([Localizable(false)] string? message, Exception exception);

	void Warn(Exception exception, [Localizable(false)] string? message);

	void Warn(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

	void Warn([Localizable(false)] string? message);

	void Warn<T>([Localizable(false)] string? message);

	void Warn([Localizable(false)] string message, params object[] args);

	void Warn<T>([Localizable(false)] string message, params object[] args);

	void Warn<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

	void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

	void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Error<T>(T value);

	void Error<T>(IFormatProvider formatProvider, T value);

	[Obsolete("Use void Error(Exception exception, [Localizable(false)] string? message)")]
	void ErrorException([Localizable(false)] string? message, Exception exception);

	void Error(Exception exception, [Localizable(false)] string? message);

	void Error(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

	void Error([Localizable(false)] string? message);

	void Error<T>([Localizable(false)] string? message);

	void Error([Localizable(false)] string message, params object[] args);

	void Error<T>([Localizable(false)] string message, params object[] args);

	void Error<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

	void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

	void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Fatal<T>(T value);

	void Fatal<T>(IFormatProvider formatProvider, T value);

	[Obsolete("Use void Fatal(Exception exception, [Localizable(false)] string? message)")]
	void FatalException([Localizable(false)] string? message, Exception exception);

	void Fatal(Exception exception, [Localizable(false)] string? message);

	void Fatal(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

	void Fatal([Localizable(false)] string? message);

	void Fatal<T>([Localizable(false)] string? message);

	void Fatal([Localizable(false)] string message, params object[] args);

	void Fatal<T>([Localizable(false)] string message, params object[] args);

	void Fatal<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

	void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

	void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);
}
