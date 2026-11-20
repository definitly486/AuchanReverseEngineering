using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using JetBrains.Annotations;
using NLog.Common;
using NLog.Internal;
using NLog.Layouts;
using NLog.MessageTemplates;
using NLog.Time;

namespace NLog;

public class LogEventInfo
{
	public static readonly DateTime ZeroDate = DateTime.UtcNow;

	private static int globalSequenceId;

	private string? _formattedMessage;

	private string _message;

	private object?[]? _parameters;

	private IFormatProvider? _formatProvider;

	private LogMessageFormatter? _messageFormatter;

	private IDictionary<Layout, object?>? _layoutCache;

	private PropertiesDictionary? _properties;

	private int _sequenceId;

	[Obsolete("Use ${counter:sequence=global} instead of ${sequenceid}. Marked obsolete with NLog 6.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int SequenceID
	{
		get
		{
			if (_sequenceId == 0)
			{
				Interlocked.CompareExchange(ref _sequenceId, Interlocked.Increment(ref globalSequenceId), 0);
			}
			return _sequenceId;
		}
	}

	public DateTime TimeStamp { get; set; }

	public LogLevel Level { get; set; }

	internal CallSiteInformation? CallSiteInformation { get; private set; }

	public bool HasStackTrace => CallSiteInformation?.StackTrace != null;

	[Obsolete("Instead use ${callsite} or CallerMemberName. Marked obsolete with NLog 5.3")]
	public StackFrame? UserStackFrame => CallSiteInformation?.UserStackFrame;

	[Obsolete("Instead use ${callsite} or CallerMemberName. Marked obsolete with NLog 5.4")]
	public int UserStackFrameNumber => CallSiteInformation?.UserStackFrameNumberLegacy ?? CallSiteInformation?.UserStackFrameNumber ?? 0;

	public StackTrace? StackTrace => CallSiteInformation?.StackTrace;

	public string? CallerClassName => CallSiteInformation?.GetCallerClassName(null, includeNameSpace: true, cleanAsyncMoveNext: true, cleanAnonymousDelegates: true);

	public string? CallerMemberName => CallSiteInformation?.GetCallerMethodName(null, includeMethodInfo: false, cleanAsyncMoveNext: true, cleanAnonymousDelegates: true);

	public string? CallerFilePath => CallSiteInformation?.GetCallerFilePath(0);

	public int CallerLineNumber => CallSiteInformation?.GetCallerLineNumber(0) ?? 0;

	public Exception? Exception { get; set; }

	public string LoggerName { get; set; }

	public string Message
	{
		get
		{
			return _message;
		}
		set
		{
			bool rebuildMessageTemplateParameters = ResetMessageTemplateParameters();
			_message = value;
			ResetFormattedMessage(rebuildMessageTemplateParameters);
		}
	}

	public object?[]? Parameters
	{
		get
		{
			return _parameters;
		}
		set
		{
			bool rebuildMessageTemplateParameters = ResetMessageTemplateParameters();
			_parameters = value;
			ResetFormattedMessage(rebuildMessageTemplateParameters);
		}
	}

	public IFormatProvider? FormatProvider
	{
		get
		{
			return _formatProvider;
		}
		set
		{
			if (_formatProvider != value)
			{
				_formatProvider = value;
				ResetFormattedMessage(rebuildMessageTemplateParameters: false);
			}
		}
	}

	public LogMessageFormatter MessageFormatter
	{
		get
		{
			return _messageFormatter ?? LogManager.LogFactory.ActiveMessageFormatter;
		}
		set
		{
			LogMessageFormatter logMessageFormatter = value ?? LogMessageStringFormatter.Default.MessageFormatter;
			if ((object)_messageFormatter != logMessageFormatter)
			{
				_messageFormatter = logMessageFormatter;
				_formattedMessage = null;
				ResetFormattedMessage(rebuildMessageTemplateParameters: false);
			}
		}
	}

	public string FormattedMessage
	{
		get
		{
			if (_formattedMessage == null)
			{
				CalcFormattedMessage();
			}
			return _formattedMessage ?? Message;
		}
	}

	public bool HasProperties
	{
		get
		{
			if (_properties == null)
			{
				PropertiesDictionary? propertiesDictionary = TryCreatePropertiesInternal();
				if (propertiesDictionary == null)
				{
					return false;
				}
				return propertiesDictionary.Count > 0;
			}
			return _properties.Count > 0;
		}
	}

	public IDictionary<object, object?> Properties => _properties ?? CreatePropertiesInternal();

	private bool HasMessageTemplateParameters
	{
		get
		{
			if (_formattedMessage == null)
			{
				object?[]? parameters = _parameters;
				if (parameters != null && parameters.Length != 0)
				{
					return (MessageFormatter.Target as ILogMessageFormatter)?.HasProperties(this) ?? false;
				}
			}
			return false;
		}
	}

	public MessageTemplateParameters MessageTemplateParameters
	{
		get
		{
			PropertiesDictionary? properties = _properties;
			if (properties != null && properties.MessageProperties.Count > 0)
			{
				return new MessageTemplateParameters(_properties.MessageProperties, _message, _parameters);
			}
			object?[]? parameters = _parameters;
			if (parameters != null && parameters.Length != 0)
			{
				return new MessageTemplateParameters(_message, _parameters);
			}
			return NLog.MessageTemplates.MessageTemplateParameters.Empty;
		}
	}

	public LogEventInfo()
	{
		TimeStamp = TimeSource.Current.Time;
		_message = string.Empty;
		LoggerName = string.Empty;
		Level = LogLevel.Off;
	}

	public LogEventInfo(LogLevel level, string? loggerName, [Localizable(false)] string message)
		: this(level, loggerName, null, message, null, null)
	{
	}

	public LogEventInfo(LogLevel level, string? loggerName, [Localizable(false)] string message, IList<MessageTemplateParameter>? messageTemplateParameters)
		: this(level, loggerName, null, message, null, null)
	{
		if (messageTemplateParameters == null)
		{
			return;
		}
		int count = messageTemplateParameters.Count;
		if (count > 0)
		{
			MessageTemplateParameter[] array = new MessageTemplateParameter[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = messageTemplateParameters[i];
			}
			_properties = new PropertiesDictionary(array);
		}
	}

	public LogEventInfo(LogLevel level, string? loggerName, [Localizable(false)] string formattedMessage, [Localizable(false)] string messageTemplate, IList<MessageTemplateParameter>? messageTemplateParameters)
		: this(level, loggerName, messageTemplate, messageTemplateParameters)
	{
		_formattedMessage = formattedMessage;
		_messageFormatter = (LogEventInfo l) => l._formattedMessage ?? l.Message ?? string.Empty;
	}

	public LogEventInfo(LogLevel level, string? loggerName, [Localizable(false)] string formattedMessage, [Localizable(false)] string messageTemplate, ReadOnlySpan<MessageTemplateParameter> messageTemplateParameters)
		: this(level, loggerName, messageTemplate)
	{
		_formattedMessage = formattedMessage;
		_messageFormatter = (LogEventInfo l) => l._formattedMessage ?? l.Message ?? string.Empty;
		if (messageTemplateParameters.Length > 0)
		{
			MessageTemplateParameter[] array = new MessageTemplateParameter[messageTemplateParameters.Length];
			for (int num = 0; num < messageTemplateParameters.Length; num++)
			{
				array[num] = messageTemplateParameters[num];
			}
			_properties = new PropertiesDictionary(array);
		}
	}

	public LogEventInfo(LogLevel level, string? loggerName, [Localizable(false)] string message, IReadOnlyList<KeyValuePair<object, object?>>? eventProperties)
		: this(level, loggerName, null, message, null, null)
	{
		if (eventProperties == null)
		{
			return;
		}
		int count = eventProperties.Count;
		if (count > 0)
		{
			_properties = new PropertiesDictionary(count);
			for (int i = 0; i < count; i++)
			{
				KeyValuePair<object, object> keyValuePair = eventProperties[i];
				_properties[keyValuePair.Key] = keyValuePair.Value;
			}
		}
	}

	public LogEventInfo(LogLevel level, string? loggerName, IFormatProvider? formatProvider, [Localizable(false)] string message, object?[]? parameters)
		: this(level, loggerName, formatProvider, message, parameters, null)
	{
	}

	public LogEventInfo(LogLevel level, string? loggerName, IFormatProvider? formatProvider, [Localizable(false)] string message, object?[]? parameters, Exception? exception)
	{
		TimeStamp = TimeSource.Current.Time;
		Level = level;
		LoggerName = loggerName ?? string.Empty;
		_formatProvider = formatProvider;
		_message = message;
		Parameters = parameters;
		Exception = exception;
	}

	internal CallSiteInformation GetCallSiteInformationInternal()
	{
		return CallSiteInformation ?? (CallSiteInformation = new CallSiteInformation());
	}

	internal PropertiesDictionary? TryCreatePropertiesInternal(IList<MessageTemplateParameter>? templateParameters = null)
	{
		PropertiesDictionary properties = _properties;
		if (properties == null)
		{
			if ((templateParameters != null && templateParameters.Count > 0) || (templateParameters == null && HasMessageTemplateParameters))
			{
				return CreatePropertiesInternal(templateParameters);
			}
		}
		else if (templateParameters != null)
		{
			properties.ResetMessageProperties(templateParameters);
		}
		return properties;
	}

	internal PropertiesDictionary CreatePropertiesInternal(IList<MessageTemplateParameter>? templateParameters = null, int initialCapacity = 0)
	{
		if (_properties == null)
		{
			PropertiesDictionary value = ((templateParameters == null) ? new PropertiesDictionary(initialCapacity) : new PropertiesDictionary(templateParameters));
			Interlocked.CompareExchange(ref _properties, value, null);
			if (templateParameters == null && HasMessageTemplateParameters)
			{
				CalcFormattedMessage();
			}
		}
		return _properties;
	}

	public static LogEventInfo CreateNullEvent()
	{
		return new LogEventInfo(LogLevel.Off, string.Empty, null, string.Empty, null, null);
	}

	public static LogEventInfo Create(LogLevel logLevel, string? loggerName, [Localizable(false)] string message)
	{
		return new LogEventInfo(logLevel, loggerName, null, message, null, null);
	}

	[MessageTemplateFormatMethod("message")]
	public static LogEventInfo Create(LogLevel logLevel, string? loggerName, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object?[]? parameters)
	{
		return new LogEventInfo(logLevel, loggerName, formatProvider, message, parameters, null);
	}

	public static LogEventInfo Create(LogLevel logLevel, string? loggerName, IFormatProvider? formatProvider, object? message)
	{
		Exception ex = message as Exception;
		if (ex == null && message is LogEventInfo logEventInfo)
		{
			logEventInfo.LoggerName = loggerName ?? logEventInfo.LoggerName;
			logEventInfo.Level = logLevel;
			logEventInfo.FormatProvider = formatProvider ?? logEventInfo.FormatProvider;
			return logEventInfo;
		}
		formatProvider = formatProvider ?? ((ex != null) ? ExceptionMessageFormatProvider.Instance : null);
		return new LogEventInfo(logLevel, loggerName, formatProvider, "{0}", new object[1] { message }, ex);
	}

	public static LogEventInfo Create(LogLevel logLevel, string? loggerName, Exception? exception, IFormatProvider? formatProvider, [Localizable(false)] string message)
	{
		return new LogEventInfo(logLevel, loggerName, formatProvider, message, null, exception);
	}

	[MessageTemplateFormatMethod("message")]
	public static LogEventInfo Create(LogLevel logLevel, string? loggerName, Exception? exception, IFormatProvider? formatProvider, [Localizable(false)][StructuredMessageTemplate] string message, object?[]? parameters)
	{
		return new LogEventInfo(logLevel, loggerName, formatProvider, message, parameters, exception);
	}

	public AsyncLogEventInfo WithContinuation(AsyncContinuation asyncContinuation)
	{
		return new AsyncLogEventInfo(this, asyncContinuation);
	}

	public override string ToString()
	{
		return $"Log Event: Logger='{LoggerName}' Level={Level} Message='{FormattedMessage}'";
	}

	public void SetStackTrace(StackTrace stackTrace)
	{
		GetCallSiteInformationInternal().SetStackTrace(stackTrace);
	}

	[Obsolete("Instead use SetStackTrace or SetCallerInfo. Marked obsolete with NLog 5.4")]
	public void SetStackTrace(StackTrace stackTrace, int userStackFrame)
	{
		GetCallSiteInformationInternal().SetStackTrace(stackTrace, (userStackFrame >= 0) ? new int?(userStackFrame) : ((int?)null));
	}

	public void SetCallerInfo(string? callerClassName, string? callerMemberName, string? callerFilePath, int callerLineNumber)
	{
		GetCallSiteInformationInternal().SetCallerInfo(callerClassName, callerMemberName, callerFilePath, callerLineNumber);
	}

	internal void AddCachedLayoutValue(Layout layout, object? value)
	{
		if (_layoutCache == null)
		{
			Dictionary<Layout, object> dictionary = new Dictionary<Layout, object>();
			dictionary[layout] = value;
			if (Interlocked.CompareExchange(ref _layoutCache, dictionary, null) == null)
			{
				return;
			}
		}
		lock (_layoutCache)
		{
			_layoutCache[layout] = value;
		}
	}

	internal bool TryGetCachedLayoutValue(Layout layout, out object? value)
	{
		if (_layoutCache == null)
		{
			value = null;
			return false;
		}
		lock (_layoutCache)
		{
			return _layoutCache.TryGetValue(layout, out value);
		}
	}

	private static bool NeedToPreformatMessage(object?[]? parameters)
	{
		if (parameters == null || parameters.Length == 0)
		{
			return false;
		}
		if (parameters.Length > 5)
		{
			return true;
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			if (!IsSafeToDeferFormatting(parameters[i]))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool NeedToPreformatMessage(in ReadOnlySpan<object?> parameters)
	{
		if (parameters.IsEmpty)
		{
			return false;
		}
		if (parameters.Length > 5)
		{
			return true;
		}
		ReadOnlySpan<object> readOnlySpan = parameters;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			if (!IsSafeToDeferFormatting(readOnlySpan[i]))
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsSafeToDeferFormatting(object? value)
	{
		return Convert.GetTypeCode(value) != TypeCode.Object;
	}

	internal bool IsLogEventThreadAgnosticImmutable()
	{
		if (Exception != null)
		{
			return false;
		}
		if (_formattedMessage != null)
		{
			object?[]? parameters = _parameters;
			if (parameters != null && parameters.Length != 0)
			{
				return false;
			}
		}
		PropertiesDictionary propertiesDictionary = TryCreatePropertiesInternal();
		if (propertiesDictionary == null || propertiesDictionary.Count == 0)
		{
			return true;
		}
		if (propertiesDictionary.Count > 5)
		{
			return false;
		}
		if (propertiesDictionary.Count == _parameters?.Length && propertiesDictionary.Count == propertiesDictionary.MessageProperties.Count)
		{
			return true;
		}
		return HasImmutableProperties(propertiesDictionary);
	}

	private static bool HasImmutableProperties(PropertiesDictionary properties)
	{
		if (properties.Count == properties.MessageProperties.Count)
		{
			for (int i = 0; i < properties.MessageProperties.Count; i++)
			{
				if (!IsSafeToDeferFormatting(properties.MessageProperties[i].Value))
				{
					return false;
				}
			}
		}
		else
		{
			using PropertiesDictionary.PropertyDictionaryEnumerator propertyDictionaryEnumerator = properties.GetPropertyEnumerator();
			while (propertyDictionaryEnumerator.MoveNext())
			{
				if (!IsSafeToDeferFormatting(propertyDictionaryEnumerator.Current.Value))
				{
					return false;
				}
			}
		}
		return true;
	}

	internal void SetMessageFormatter(LogMessageFormatter messageFormatter, LogMessageFormatter? singleTargetMessageFormatter)
	{
		bool num = _messageFormatter != null;
		if (!num)
		{
			_messageFormatter = messageFormatter;
		}
		if (num || NeedToPreformatMessage(_parameters))
		{
			CalcFormattedMessage();
		}
		else
		{
			if (singleTargetMessageFormatter == null)
			{
				return;
			}
			object?[]? parameters = _parameters;
			if (parameters != null && parameters.Length != 0)
			{
				string message = _message;
				if (message != null && message.Length < 256)
				{
					_messageFormatter = singleTargetMessageFormatter;
				}
			}
		}
	}

	private void CalcFormattedMessage()
	{
		try
		{
			_formattedMessage = MessageFormatter(this);
		}
		catch (Exception ex)
		{
			_formattedMessage = Message ?? string.Empty;
			InternalLogger.Warn(ex, "Error when formatting a message.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
	}

	internal void AppendFormattedMessage(ILogMessageFormatter messageFormatter, StringBuilder builder)
	{
		if (_formattedMessage != null)
		{
			builder.Append(_formattedMessage);
			return;
		}
		object?[]? parameters = _parameters;
		if (parameters != null && parameters.Length != 0 && !string.IsNullOrEmpty(_message))
		{
			int length = builder.Length;
			try
			{
				messageFormatter.AppendFormattedMessage(this, builder);
				return;
			}
			catch (Exception ex)
			{
				builder.Length = length;
				builder.Append(_message);
				InternalLogger.Warn(ex, "Error when formatting a message.");
				if (ex.MustBeRethrown())
				{
					throw;
				}
				return;
			}
		}
		builder.Append(FormattedMessage);
	}

	private void ResetFormattedMessage(bool rebuildMessageTemplateParameters)
	{
		if (_messageFormatter == null || _messageFormatter.Target is ILogMessageFormatter)
		{
			_formattedMessage = null;
		}
		if (rebuildMessageTemplateParameters && HasMessageTemplateParameters)
		{
			CalcFormattedMessage();
		}
	}

	private bool ResetMessageTemplateParameters()
	{
		if (_properties == null)
		{
			return false;
		}
		if (HasMessageTemplateParameters)
		{
			_properties.ResetMessageProperties();
			return true;
		}
		return _properties.MessageProperties.Count == 0;
	}
}
