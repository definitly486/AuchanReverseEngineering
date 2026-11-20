using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Splat;

public interface IStaticFullLogger
{
	LogLevel Level { get; }

	void Debug(Exception exception, [Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Debug([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Debug<T>([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Debug<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument, [CallerMemberName] string? callerMemberName = null);

	void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null);

	void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null);

	void Info(Exception exception, [Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Info([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Info<T>([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Info<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument, [CallerMemberName] string? callerMemberName = null);

	void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null);

	void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null);

	void Warn(Exception exception, [Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Warn([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Warn<T>([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Warn<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument, [CallerMemberName] string? callerMemberName = null);

	void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null);

	void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null);

	void Error(Exception exception, [Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Error([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Error<T>([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Error<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument, [CallerMemberName] string? callerMemberName = null);

	void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null);

	void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null);

	void Fatal(Exception exception, [Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Fatal([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Fatal<T>([Localizable(false)] string message, [CallerMemberName] string? callerMemberName = null);

	void Fatal<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument, [CallerMemberName] string? callerMemberName = null);

	void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, [CallerMemberName] string? callerMemberName = null);

	void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, [CallerMemberName] string? callerMemberName = null);

	void Write([Localizable(false)] string message, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null);

	void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null);

	void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null);

	void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel, [CallerMemberName] string? callerMemberName = null);
}
