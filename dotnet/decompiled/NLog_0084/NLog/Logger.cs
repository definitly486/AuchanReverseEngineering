using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NLog.Common;
using NLog.Internal;
using NLog.MessageTemplates;

namespace NLog;

[CLSCompliant(true)]
public class Logger : ILogger, ISuppress, ILoggerBase
{
	internal static readonly Type DefaultLoggerType = typeof(Logger);

	private ITargetWithFilterChain[] _targetsByLevel = TargetWithFilterChain.NoTargetsByLevel;

	private Logger _contextLogger;

	private ThreadSafeDictionary<string, object?>? _contextProperties;

	private volatile bool _isTraceEnabled;

	private volatile bool _isDebugEnabled;

	private volatile bool _isInfoEnabled;

	private volatile bool _isWarnEnabled;

	private volatile bool _isErrorEnabled;

	private volatile bool _isFatalEnabled;

	public bool IsTraceEnabled => _contextLogger._isTraceEnabled;

	public bool IsDebugEnabled => _contextLogger._isDebugEnabled;

	public bool IsInfoEnabled => _contextLogger._isInfoEnabled;

	public bool IsWarnEnabled => _contextLogger._isWarnEnabled;

	public bool IsErrorEnabled => _contextLogger._isErrorEnabled;

	public bool IsFatalEnabled => _contextLogger._isFatalEnabled;

	public string Name { get; private set; }

	public LogFactory Factory { get; private set; }

	public IDictionary<string, object?> Properties => _contextProperties ?? Interlocked.CompareExchange(ref _contextProperties, CreateContextPropertiesDictionary(null), null) ?? _contextProperties;

	public event EventHandler<EventArgs>? LoggerReconfigured;

	[Conditional("DEBUG")]
	public void ConditionalDebug<T>(T? value)
	{
		Debug(value);
	}

	[Conditional("DEBUG")]
	public void ConditionalDebug<T>(IFormatProvider? formatProvider, T? value)
	{
		Debug(formatProvider, value);
	}

	[Conditional("DEBUG")]
	public void ConditionalDebug(LogMessageGenerator messageFunc)
	{
		Debug(messageFunc);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Debug(exception, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		Debug(exception, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Debug(exception, formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Debug(formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	public void ConditionalDebug([Localizable(false)] string message)
	{
		Debug(message);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Debug(message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		Debug(message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		Debug(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		Debug(message, argument);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		Debug(formatProvider, message, argument1, argument2);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		Debug(message, argument1, argument2);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		Debug(formatProvider, message, argument1, argument2, argument3);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalDebug<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		Debug(message, argument1, argument2, argument3);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(object? value)
	{
		this.Debug<object>(value);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, object? value)
	{
		this.Debug<object>(formatProvider, value);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		this.Debug<object, object>(message, arg1, arg2);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		this.Debug<object, object, object>(message, arg1, arg2, arg3);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		this.Debug<bool>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		this.Debug<bool>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		this.Debug<char>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		this.Debug<char>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		this.Debug<byte>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		this.Debug<byte>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		this.Debug<string>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		this.Debug<string>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		this.Debug<int>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		this.Debug<int>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		this.Debug<long>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		this.Debug<long>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		this.Debug<float>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		this.Debug<float>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		this.Debug<double>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		this.Debug<double>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		this.Debug<decimal>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		this.Debug<decimal>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		this.Debug<object>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalDebug([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		this.Debug<object>(message, argument);
	}

	[Conditional("DEBUG")]
	public void ConditionalTrace<T>(T? value)
	{
		Trace(value);
	}

	[Conditional("DEBUG")]
	public void ConditionalTrace<T>(IFormatProvider? formatProvider, T? value)
	{
		Trace(formatProvider, value);
	}

	[Conditional("DEBUG")]
	public void ConditionalTrace(LogMessageGenerator messageFunc)
	{
		Trace(messageFunc);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Trace(exception, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		Trace(exception, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Trace(exception, formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Trace(formatProvider, message, args);
	}

	[Conditional("DEBUG")]
	public void ConditionalTrace([Localizable(false)] string message)
	{
		Trace(message);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		Trace(message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		Trace(message, args);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		Trace(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		Trace(message, argument);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		Trace(formatProvider, message, argument1, argument2);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		Trace(message, argument1, argument2);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		Trace(formatProvider, message, argument1, argument2, argument3);
	}

	[Conditional("DEBUG")]
	[MessageTemplateFormatMethod("message")]
	public void ConditionalTrace<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		Trace(message, argument1, argument2, argument3);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(object value)
	{
		this.Trace<object>(value);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, object? value)
	{
		this.Trace<object>(formatProvider, value);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		this.Trace<object, object>(message, arg1, arg2);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		this.Trace<object, object, object>(message, arg1, arg2, arg3);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		this.Trace<bool>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		this.Trace<bool>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		this.Trace<char>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		this.Trace<char>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		this.Trace<byte>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		this.Trace<byte>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		this.Trace<string>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		this.Trace<string>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		this.Trace<int>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		this.Trace<int>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		this.Trace<long>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		this.Trace<long>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		this.Trace<float>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		this.Trace<float>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		this.Trace<double>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		this.Trace<double>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		this.Trace<decimal>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		this.Trace<decimal>(message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		this.Trace<object>(formatProvider, message, argument);
	}

	[Conditional("DEBUG")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void ConditionalTrace([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		this.Trace<object>(message, argument);
	}

	public void Trace<T>(T? value)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, Factory.DefaultCultureInfo, value);
		}
	}

	public void Trace<T>(IFormatProvider? formatProvider, T? value)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, value);
		}
	}

	public void Trace(LogMessageGenerator messageFunc)
	{
		if (IsTraceEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(LogLevel.Trace, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, args);
		}
	}

	public void Trace([Localizable(false)] string message)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	public void Trace(Exception? exception, [Localizable(false)] string message)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, exception, message, null);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Trace<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	public void Debug<T>(T? value)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, Factory.DefaultCultureInfo, value);
		}
	}

	public void Debug<T>(IFormatProvider? formatProvider, T? value)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, value);
		}
	}

	public void Debug(LogMessageGenerator messageFunc)
	{
		if (IsDebugEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(LogLevel.Debug, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, args);
		}
	}

	public void Debug([Localizable(false)] string message)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	public void Debug(Exception? exception, [Localizable(false)] string message)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, exception, message, null);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	public void Info<T>(T? value)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, Factory.DefaultCultureInfo, value);
		}
	}

	public void Info<T>(IFormatProvider? formatProvider, T? value)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, value);
		}
	}

	public void Info(LogMessageGenerator messageFunc)
	{
		if (IsInfoEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(LogLevel.Info, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, args);
		}
	}

	public void Info([Localizable(false)] string message)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	public void Info(Exception? exception, [Localizable(false)] string message)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, exception, message, null);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	public void Warn<T>(T? value)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, Factory.DefaultCultureInfo, value);
		}
	}

	public void Warn<T>(IFormatProvider? formatProvider, T? value)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, value);
		}
	}

	public void Warn(LogMessageGenerator messageFunc)
	{
		if (IsWarnEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(LogLevel.Warn, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, args);
		}
	}

	public void Warn([Localizable(false)] string message)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	public void Warn(Exception? exception, [Localizable(false)] string message)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, exception, message, null);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	public void Error<T>(T? value)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, Factory.DefaultCultureInfo, value);
		}
	}

	public void Error<T>(IFormatProvider? formatProvider, T? value)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, value);
		}
	}

	public void Error(LogMessageGenerator messageFunc)
	{
		if (IsErrorEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(LogLevel.Error, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, args);
		}
	}

	public void Error([Localizable(false)] string message)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	public void Error(Exception? exception, [Localizable(false)] string message)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, exception, message, null);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	public void Fatal<T>(T? value)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, Factory.DefaultCultureInfo, value);
		}
	}

	public void Fatal<T>(IFormatProvider? formatProvider, T? value)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, value);
		}
	}

	public void Fatal(LogMessageGenerator messageFunc)
	{
		if (IsFatalEnabled)
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(LogLevel.Fatal, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, args);
		}
	}

	public void Fatal([Localizable(false)] string message)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	public void Fatal(Exception? exception, [Localizable(false)] string message)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, exception, message, null);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal(Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal<TArgument>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal<TArgument>([Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal<TArgument1, TArgument2>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal<TArgument1, TArgument2>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, object? value)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, object? value)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, string message, int argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Trace(object? value)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, object? value)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, string message, int argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Trace, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Trace([Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsTraceEnabled)
		{
			WriteToTargets(LogLevel.Trace, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Debug(object? value)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, object? value)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Debug, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Debug([Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsDebugEnabled)
		{
			WriteToTargets(LogLevel.Debug, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Info(object? value)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, object? value)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Info, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Info([Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsInfoEnabled)
		{
			WriteToTargets(LogLevel.Info, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Warn(object? value)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, object? value)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Warn, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Warn([Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsWarnEnabled)
		{
			WriteToTargets(LogLevel.Warn, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Error(object? value)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, object? value)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Error, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Error([Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsErrorEnabled)
		{
			WriteToTargets(LogLevel.Error, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Fatal(object? value)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, Factory.DefaultCultureInfo, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, object? value)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { arg1, arg2 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, object? arg1, object? arg2, object? arg3)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { arg1, arg2, arg3 }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, bool argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, char argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, byte argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, string? argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, int argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, long argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, float argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, double argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, decimal argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, object? argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargetsWithSpan(LogLevel.Fatal, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, sbyte argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, uint argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal(IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[1] { argument });
		}
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MessageTemplateFormatMethod("message")]
	[OverloadResolutionPriority(-1)]
	public void Fatal([Localizable(false)][StructuredMessageTemplate] string message, ulong argument)
	{
		if (IsFatalEnabled)
		{
			WriteToTargets(LogLevel.Fatal, message, new object[1] { argument });
		}
	}

	void ILoggerBase.LogException(LogLevel level, [Localizable(false)] string message, Exception? exception)
	{
		Log(level, exception, message, ArrayHelper.Empty<object>());
	}

	void ILoggerBase.Log(LogLevel level, [Localizable(false)] string message, Exception? exception)
	{
		Log(level, exception, message, ArrayHelper.Empty<object>());
	}

	[Obsolete("Use Trace(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void TraceException([Localizable(false)] string message, Exception? exception)
	{
		Trace(exception, message);
	}

	void ILogger.Trace([Localizable(false)] string message, Exception? exception)
	{
		Trace(exception, message);
	}

	[Obsolete("Use Debug(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DebugException([Localizable(false)] string message, Exception? exception)
	{
		Debug(exception, message);
	}

	void ILogger.Debug([Localizable(false)] string message, Exception? exception)
	{
		Debug(exception, message);
	}

	[Obsolete("Use Info(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void InfoException([Localizable(false)] string message, Exception? exception)
	{
		Info(exception, message);
	}

	void ILogger.Info([Localizable(false)] string message, Exception? exception)
	{
		Info(exception, message);
	}

	[Obsolete("Use Warn(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void WarnException([Localizable(false)] string message, Exception? exception)
	{
		Warn(exception, message);
	}

	void ILogger.Warn([Localizable(false)] string message, Exception? exception)
	{
		Warn(exception, message);
	}

	[Obsolete("Use Error(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ErrorException([Localizable(false)] string message, Exception? exception)
	{
		Error(exception, message);
	}

	void ILogger.Error([Localizable(false)] string message, Exception? exception)
	{
		Error(exception, message);
	}

	[Obsolete("Use Fatal(Exception exception, string message) method instead. Marked obsolete with v4.3.11 (Only here because of LibLog)")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void FatalException([Localizable(false)] string message, Exception? exception)
	{
		Fatal(exception, message);
	}

	void ILogger.Fatal([Localizable(false)] string message, Exception? exception)
	{
		Fatal(exception, message);
	}

	protected internal Logger()
	{
		_contextLogger = this;
		Name = string.Empty;
		Factory = LogManager.LogFactory;
	}

	public bool IsEnabled(LogLevel level)
	{
		return GetTargetsForLevelSafe(level) != null;
	}

	public Logger WithProperty(string propertyKey, object? propertyValue)
	{
		if (string.IsNullOrEmpty(propertyKey))
		{
			throw new ArgumentException("propertyKey");
		}
		Logger logger = CreateChildLogger();
		logger.Properties[propertyKey] = propertyValue;
		return logger;
	}

	public Logger WithProperties(IEnumerable<KeyValuePair<string, object?>> properties)
	{
		Guard.ThrowIfNull(properties, "properties");
		Logger logger = CreateChildLogger();
		IDictionary<string, object> properties2 = logger.Properties;
		foreach (KeyValuePair<string, object> property in properties)
		{
			properties2[property.Key] = property.Value;
		}
		return logger;
	}

	public Logger WithProperties([ParamCollection] scoped ReadOnlySpan<(string, object?)> properties)
	{
		Logger logger = CreateChildLogger();
		IDictionary<string, object> properties2 = logger.Properties;
		ReadOnlySpan<(string, object)> readOnlySpan = properties;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			(string, object) tuple = readOnlySpan[i];
			properties2[tuple.Item1] = tuple.Item2;
		}
		return logger;
	}

	[Obsolete("Instead use WithProperty which is safe. If really necessary then one can use Properties-property. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SetProperty(string propertyKey, object? propertyValue)
	{
		if (string.IsNullOrEmpty(propertyKey))
		{
			throw new ArgumentException("propertyKey");
		}
		Properties[propertyKey] = propertyValue;
	}

	private static ThreadSafeDictionary<string, object?> CreateContextPropertiesDictionary(ThreadSafeDictionary<string, object?>? contextProperties)
	{
		contextProperties = ((contextProperties == null) ? new ThreadSafeDictionary<string, object>() : new ThreadSafeDictionary<string, object>(contextProperties));
		return contextProperties;
	}

	public IDisposable PushScopeProperty(string propertyName, object? propertyValue)
	{
		return ScopeContext.PushProperty(propertyName, propertyValue);
	}

	public IDisposable PushScopeProperty<TValue>(string propertyName, TValue? propertyValue)
	{
		return ScopeContext.PushProperty(propertyName, propertyValue);
	}

	public IDisposable PushScopeProperties(IReadOnlyCollection<KeyValuePair<string, object?>> scopeProperties)
	{
		return ScopeContext.PushProperties(scopeProperties);
	}

	public IDisposable PushScopeProperties<TValue>(IReadOnlyCollection<KeyValuePair<string, TValue?>> scopeProperties)
	{
		return ScopeContext.PushProperties(scopeProperties);
	}

	public IDisposable PushScopeNested<T>(T nestedState)
	{
		return ScopeContext.PushNestedState(nestedState);
	}

	public IDisposable PushScopeNested(object nestedState)
	{
		return ScopeContext.PushNestedState(nestedState);
	}

	public void Log(LogEventInfo logEvent)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(logEvent.Level);
		if (targetsForLevelSafe != null)
		{
			if (logEvent.LoggerName == null || (object)logEvent.LoggerName == string.Empty)
			{
				logEvent.LoggerName = Name;
			}
			if (logEvent.FormatProvider == null)
			{
				logEvent.FormatProvider = Factory.DefaultCultureInfo;
			}
			WriteLogEventToTargets(logEvent, targetsForLevelSafe);
		}
	}

	public void Log(Type wrapperType, LogEventInfo logEvent)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(logEvent.Level);
		if (targetsForLevelSafe != null)
		{
			if (logEvent.LoggerName == null || (object)logEvent.LoggerName == string.Empty)
			{
				logEvent.LoggerName = Name;
			}
			if (logEvent.FormatProvider == null)
			{
				logEvent.FormatProvider = Factory.DefaultCultureInfo;
			}
			WriteLogEventToTargets(wrapperType, logEvent, targetsForLevelSafe);
		}
	}

	public void Log<T>(LogLevel level, T? value)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, Factory.DefaultCultureInfo, value);
		}
	}

	public void Log<T>(LogLevel level, IFormatProvider? formatProvider, T? value)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, value);
		}
	}

	public void Log(LogLevel level, LogMessageGenerator messageFunc)
	{
		if (IsEnabled(level))
		{
			Guard.ThrowIfNull(messageFunc, "messageFunc");
			WriteToTargets(level, messageFunc());
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, formatProvider, message, args);
		}
	}

	public void Log(LogLevel level, [Localizable(false)] string message)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, exception, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log(LogLevel level, Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, params object?[] args)
	{
		if (IsEnabled(level))
		{
			WriteToTargets(level, exception, formatProvider, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log<TArgument>(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, formatProvider, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log<TArgument>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, TArgument? argument)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[1] { argument }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log<TArgument1, TArgument2>(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, formatProvider, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log<TArgument1, TArgument2>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[2] { argument1, argument2 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log<TArgument1, TArgument2, TArgument3>(LogLevel level, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, formatProvider, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log<TArgument1, TArgument2, TArgument3>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, TArgument1? argument1, TArgument2? argument2, TArgument3? argument3)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, new ReadOnlySpan<object>(new object[3] { argument1, argument2, argument3 }));
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, null, Factory.DefaultCultureInfo, message, args);
		}
	}

	[MessageTemplateFormatMethod("message")]
	public void Log(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		ITargetWithFilterChain targetsForLevelSafe = GetTargetsForLevelSafe(level);
		if (targetsForLevelSafe != null)
		{
			WriteToTargetsWithSpan(targetsForLevelSafe, level, exception, Factory.DefaultCultureInfo, message, args);
		}
	}

	private void WriteToTargetsWithSpan(LogLevel level, Exception? exception, IFormatProvider? formatProvider, string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		ITargetWithFilterChain targetsForLevel = GetTargetsForLevel(level);
		if (targetsForLevel != null)
		{
			WriteToTargetsWithSpan(targetsForLevel, level, exception, formatProvider, message, args);
		}
	}

	private void WriteToTargetsWithSpan(ITargetWithFilterChain targetsForLevel, LogLevel level, Exception? exception, IFormatProvider? formatProvider, string message, [ParamCollection] scoped ReadOnlySpan<object?> args)
	{
		if (Factory.AutoMessageTemplateFormatter == null || !LogEventInfo.NeedToPreformatMessage(in args))
		{
			LogEventInfo logEvent = LogEventInfo.Create(level, Name, exception, formatProvider, message, args.IsEmpty ? null : args.ToArray());
			WriteLogEventToTargets(logEvent, targetsForLevel);
			return;
		}
		TemplateEnumerator templateEnumerator = new TemplateEnumerator(message);
		if (templateEnumerator.MoveNext() && !templateEnumerator.Current.MaybePositionalTemplate)
		{
			IList<MessageTemplateParameter> messageTemplateParameters;
			string formattedMessage = Factory.AutoMessageTemplateFormatter.Render(ref templateEnumerator, formatProvider, in args, out messageTemplateParameters);
			LogEventInfo logEventInfo = new LogEventInfo(level, Name, formattedMessage, message, messageTemplateParameters);
			logEventInfo.Exception = exception;
			WriteLogEventToTargets(logEventInfo, targetsForLevel);
		}
		else
		{
			LogEventInfo logEventInfo2 = LogEventInfo.Create(level, Name, exception, formatProvider, message, args.ToArray());
			logEventInfo2.MessageFormatter = LogMessageStringFormatter.Default.MessageFormatter;
			WriteLogEventToTargets(logEventInfo2, targetsForLevel);
		}
	}

	private LogEventInfo PrepareLogEventInfo(LogEventInfo logEvent)
	{
		if (_contextProperties != null)
		{
			foreach (KeyValuePair<string, object> contextProperty in _contextProperties)
			{
				if (!logEvent.Properties.ContainsKey(contextProperty.Key))
				{
					logEvent.Properties[contextProperty.Key] = contextProperty.Value;
				}
			}
		}
		return logEvent;
	}

	public void Swallow(Action action)
	{
		try
		{
			action();
		}
		catch (Exception value)
		{
			Error(value);
		}
	}

	public T? Swallow<T>(Func<T?> func)
	{
		return Swallow(func, default(T));
	}

	public T? Swallow<T>(Func<T?> func, T? fallback)
	{
		try
		{
			return func();
		}
		catch (Exception value)
		{
			Error(value);
			return fallback;
		}
	}

	public async void Swallow(Task task)
	{
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception value)
		{
			Error(value);
		}
	}

	public async Task SwallowAsync(Task task)
	{
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception value)
		{
			Error(value);
		}
	}

	public async Task SwallowAsync(Func<Task> asyncAction)
	{
		try
		{
			await asyncAction().ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception value)
		{
			Error(value);
		}
	}

	public async Task<TResult?> SwallowAsync<TResult>(Func<Task<TResult?>> asyncFunc)
	{
		return await SwallowAsync(asyncFunc, default(TResult)).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<TResult?> SwallowAsync<TResult>(Func<Task<TResult?>> asyncFunc, TResult? fallback)
	{
		try
		{
			return await asyncFunc().ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception value)
		{
			Error(value);
			return fallback;
		}
	}

	internal void Initialize(string name, ITargetWithFilterChain[] targetsByLevel, LogFactory factory)
	{
		Name = name;
		Factory = factory;
		SetConfiguration(targetsByLevel);
	}

	private void WriteToTargets(LogLevel level, string message, object?[] args)
	{
		WriteToTargets(level, Factory.DefaultCultureInfo, message, args);
	}

	private void WriteToTargets(LogLevel level, IFormatProvider? formatProvider, string message, object?[] args)
	{
		ITargetWithFilterChain targetsForLevel = GetTargetsForLevel(level);
		if (targetsForLevel != null)
		{
			LogEventInfo logEvent = LogEventInfo.Create(level, Name, formatProvider, message, args);
			WriteLogEventToTargets(logEvent, targetsForLevel);
		}
	}

	private void WriteToTargets(LogLevel level, string message)
	{
		ITargetWithFilterChain targetsForLevel = GetTargetsForLevel(level);
		if (targetsForLevel != null)
		{
			LogEventInfo logEvent = LogEventInfo.Create(level, Name, Factory.DefaultCultureInfo, message, null);
			WriteLogEventToTargets(logEvent, targetsForLevel);
		}
	}

	private void WriteToTargets<T>(LogLevel level, IFormatProvider? formatProvider, T? value)
	{
		ITargetWithFilterChain targetsForLevel = GetTargetsForLevel(level);
		if (targetsForLevel != null)
		{
			LogEventInfo logEvent = LogEventInfo.Create(level, Name, formatProvider, value);
			WriteLogEventToTargets(logEvent, targetsForLevel);
		}
	}

	private void WriteToTargets(LogLevel level, Exception? ex, string message, object?[]? args)
	{
		ITargetWithFilterChain targetsForLevel = GetTargetsForLevel(level);
		if (targetsForLevel != null)
		{
			LogEventInfo logEvent = ((message == null && ex != null && (args == null || args.Length == 0)) ? LogEventInfo.Create(level, Name, ExceptionMessageFormatProvider.Instance, ex) : LogEventInfo.Create(level, Name, ex, Factory.DefaultCultureInfo, message ?? string.Empty, args));
			WriteLogEventToTargets(logEvent, targetsForLevel);
		}
	}

	private void WriteToTargets(LogLevel level, Exception? ex, IFormatProvider? formatProvider, string message, object?[] args)
	{
		ITargetWithFilterChain targetsForLevel = GetTargetsForLevel(level);
		if (targetsForLevel != null)
		{
			LogEventInfo logEvent = LogEventInfo.Create(level, Name, ex, formatProvider, message, args);
			WriteLogEventToTargets(logEvent, targetsForLevel);
		}
	}

	private void WriteLogEventToTargets(LogEventInfo logEvent, ITargetWithFilterChain targetsForLevel)
	{
		try
		{
			targetsForLevel.WriteToLoggerTargets(DefaultLoggerType, PrepareLogEventInfo(logEvent), Factory);
		}
		catch (Exception ex)
		{
			if (Factory.ThrowExceptions || LogManager.ThrowExceptions)
			{
				throw;
			}
			InternalLogger.Error(ex, "Failed to write LogEvent");
		}
	}

	private void WriteLogEventToTargets(Type wrapperType, LogEventInfo logEvent, ITargetWithFilterChain targetsForLevel)
	{
		try
		{
			targetsForLevel.WriteToLoggerTargets(wrapperType ?? DefaultLoggerType, PrepareLogEventInfo(logEvent), Factory);
		}
		catch (Exception ex)
		{
			if (Factory.ThrowExceptions || LogManager.ThrowExceptions)
			{
				throw;
			}
			InternalLogger.Error(ex, "Failed to write LogEvent");
		}
	}

	internal void SetConfiguration(ITargetWithFilterChain[] targetsByLevel)
	{
		_targetsByLevel = targetsByLevel;
		_isTraceEnabled = IsEnabled(LogLevel.Trace);
		_isDebugEnabled = IsEnabled(LogLevel.Debug);
		_isInfoEnabled = IsEnabled(LogLevel.Info);
		_isWarnEnabled = IsEnabled(LogLevel.Warn);
		_isErrorEnabled = IsEnabled(LogLevel.Error);
		_isFatalEnabled = IsEnabled(LogLevel.Fatal);
		OnLoggerReconfigured(EventArgs.Empty);
	}

	private ITargetWithFilterChain GetTargetsForLevelSafe(LogLevel? level)
	{
		if ((object)level == null)
		{
			throw new InvalidOperationException("Log level must be defined");
		}
		return GetTargetsForLevel(level);
	}

	private ITargetWithFilterChain GetTargetsForLevel(LogLevel level)
	{
		if (_contextLogger == this)
		{
			return _targetsByLevel[level.Ordinal];
		}
		return _contextLogger.GetTargetsForLevel(level);
	}

	protected virtual void OnLoggerReconfigured(EventArgs e)
	{
		this.LoggerReconfigured?.Invoke(this, e);
	}

	private Logger CreateChildLogger()
	{
		Logger obj = (Logger)MemberwiseClone();
		obj.Initialize(Name, _targetsByLevel, Factory);
		obj._contextProperties = CreateContextPropertiesDictionary(_contextProperties);
		obj._contextLogger = _contextLogger;
		return obj;
	}
}
