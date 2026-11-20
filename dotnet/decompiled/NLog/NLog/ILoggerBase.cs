using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace NLog;

[CLSCompliant(false)]
[Obsolete("ILoggerBase should be replaced with ILogger. Marked obsolete with NLog v5.3")]
[EditorBrowsable(EditorBrowsableState.Never)]
public interface ILoggerBase
{
	string Name { get; }

	[Obsolete("Factory-property is hard to mock for ILogger-interface. Instead use Logger.Factory. Marked obsolete with NLog v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	LogFactory Factory { get; }

	[Obsolete("LoggerReconfigured-EventHandler is very exotic for ILogger-interface. Instead use Logger.LoggerReconfigured. Marked obsolete with NLog v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	event EventHandler<EventArgs> LoggerReconfigured;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	bool IsEnabled(LogLevel level);

	void Log(LogEventInfo logEvent);

	void Log(Type wrapperType, LogEventInfo logEvent);

	void Log<T>(LogLevel level, T? value);

	void Log<T>(LogLevel level, IFormatProvider? formatProvider, T? value);

	void Log(LogLevel level, LogMessageGenerator messageFunc);

	[MessageTemplateFormatMethod("message")]
	void Log(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Log(LogLevel level, Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Log(LogLevel level, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Log<TArgument>(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Log<TArgument>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Log<TArgument1, TArgument2>(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Log<TArgument1, TArgument2>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Log<TArgument1, TArgument2, TArgument3>(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Log<TArgument1, TArgument2, TArgument3>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Log(LogLevel level, Exception exception, [Localizable(false)] string message, params object[] args) instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Log(LogLevel level, [Localizable(false)] string message, Exception? exception);

	[Obsolete("Use Log(LogLevel level, Exception exception, [Localizable(false)] string message, params object[] args) instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void LogException(LogLevel level, [Localizable(false)] string message, Exception? exception);
}
