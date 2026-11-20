using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace NLog;

[CLSCompliant(false)]
public interface ILogger : ISuppress, ILoggerBase
{
	bool IsTraceEnabled { get; }

	bool IsDebugEnabled { get; }

	bool IsInfoEnabled { get; }

	bool IsWarnEnabled { get; }

	bool IsErrorEnabled { get; }

	bool IsFatalEnabled { get; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Trace(object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Debug(object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Info(object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Warn(object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Error(object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, object argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Fatal(object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, object? value);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, bool argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, char argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, byte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, string? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, int argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, long argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, float argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, double argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, decimal argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, object? argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, uint argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, ulong argument);

	void Trace<T>(T? value);

	void Trace<T>(IFormatProvider? formatProvider, T? value);

	void Trace(LogMessageGenerator messageFunc);

	void Trace(Exception? exception, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Trace(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Trace(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Trace([Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Trace([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[Obsolete("Use Trace(Exception exception, string message) method instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Trace([Localizable(false)] string message, Exception? exception);

	[MessageTemplateFormatMethod("message")]
	void Trace<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Trace<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Trace<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Trace<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Trace<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Trace<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Trace(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void TraceException([Localizable(false)] string message, Exception? exception);

	void Debug<T>(T? value);

	void Debug<T>(IFormatProvider? formatProvider, T? value);

	void Debug(LogMessageGenerator messageFunc);

	void Debug(Exception? exception, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Debug(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Debug([Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Debug([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Debug<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Debug<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Debug<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Debug<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Debug(Exception exception, string message) method instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Debug([Localizable(false)] string message, Exception exception);

	[Obsolete("Use Debug(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void DebugException([Localizable(false)] string message, Exception? exception);

	void Info<T>(T? value);

	void Info<T>(IFormatProvider? formatProvider, T? value);

	void Info(LogMessageGenerator messageFunc);

	void Info(Exception? exception, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Info(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Info(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Info([Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Info([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Info<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Info<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument argument);

	[MessageTemplateFormatMethod("message")]
	void Info<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Info<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Info(Exception exception, string message) method instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Info([Localizable(false)] string message, Exception? exception);

	[Obsolete("Use Info(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void InfoException([Localizable(false)] string message, Exception? exception);

	void Warn<T>(T? value);

	void Warn<T>(IFormatProvider? formatProvider, T? value);

	void Warn(LogMessageGenerator messageFunc);

	void Warn(Exception? exception, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Warn(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Warn([Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Warn([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Warn<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Warn<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Warn<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Warn<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Warn(Exception exception, string message) method instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Warn([Localizable(false)] string message, Exception? exception);

	[Obsolete("Use Warn(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void WarnException([Localizable(false)] string message, Exception? exception);

	void Error<T>(T? value);

	void Error<T>(IFormatProvider? formatProvider, T? value);

	void Error(LogMessageGenerator messageFunc);

	void Error(Exception? exception, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Error(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Error([Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Error([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Error<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Error<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Error<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Error<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Error(Exception exception, string message) method instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Error([Localizable(false)] string message, Exception? exception);

	[Obsolete("Use Error(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void ErrorException([Localizable(false)] string message, Exception? exception);

	void Fatal<T>(T? value);

	void Fatal<T>(IFormatProvider? formatProvider, T? value);

	void Fatal(LogMessageGenerator messageFunc);

	void Fatal(Exception? exception, [Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Fatal(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Fatal(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	void Fatal([Localizable(false)] string message);

	[MessageTemplateFormatMethod("message")]
	void Fatal([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args);

	[MessageTemplateFormatMethod("message")]
	void Fatal<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Fatal<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument);

	[MessageTemplateFormatMethod("message")]
	void Fatal<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Fatal<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2);

	[MessageTemplateFormatMethod("message")]
	void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[MessageTemplateFormatMethod("message")]
	void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3);

	[Obsolete("Use Fatal(Exception exception, string message) method instead. Marked obsolete with v4.3.11")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void Fatal([Localizable(false)] string message, Exception? exception);

	[Obsolete("Use Fatal(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void FatalException([Localizable(false)] string message, Exception? exception);
}
