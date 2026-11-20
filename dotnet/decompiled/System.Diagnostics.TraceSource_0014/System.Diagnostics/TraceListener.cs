using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public abstract class TraceListener : MarshalByRefObject, IDisposable
{
	private int _indentLevel;

	private int _indentSize = 4;

	private TraceOptions _traceOptions;

	private bool _needIndent = true;

	private string _listenerName;

	private TraceFilter _filter;

	public virtual bool IsThreadSafe => false;

	public int IndentLevel
	{
		set
		{
			_indentLevel = ((value >= 0) ? value : 0);
		}
	}

	public int IndentSize
	{
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("IndentSize", value, "TraceListenerIndentSize");
			}
			_indentSize = value;
		}
	}

	public TraceFilter? Filter => _filter;

	protected bool NeedIndent
	{
		get
		{
			return _needIndent;
		}
		set
		{
			_needIndent = value;
		}
	}

	public TraceOptions TraceOutputOptions => _traceOptions;

	protected TraceListener(string? name)
	{
		_listenerName = name;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public virtual void Flush()
	{
	}

	public virtual void Fail(string? message, string? detailMessage)
	{
		WriteLine((detailMessage == null) ? ("TraceListenerFail" + " " + message) : $"{"TraceListenerFail"} {message} {detailMessage}");
	}

	public abstract void Write(string? message);

	protected virtual void WriteIndent()
	{
		NeedIndent = false;
		for (int i = 0; i < _indentLevel; i++)
		{
			if (_indentSize == 4)
			{
				Write("    ");
				continue;
			}
			for (int j = 0; j < _indentSize; j++)
			{
				Write(" ");
			}
		}
	}

	public abstract void WriteLine(string? message);

	public virtual void TraceEvent(TraceEventCache? eventCache, string source, TraceEventType eventType, int id, string? message)
	{
		if (Filter == null || Filter.ShouldTrace(eventCache, source, eventType, id, message))
		{
			WriteHeader(source, eventType, id);
			WriteLine(message);
			WriteFooter(eventCache);
		}
	}

	private void WriteHeader(string source, TraceEventType eventType, int id)
	{
		IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
		IFormatProvider provider = invariantCulture;
		Span<char> initialBuffer = stackalloc char[256];
		DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(6, 3, invariantCulture, initialBuffer);
		handler.AppendFormatted(source);
		handler.AppendLiteral(" ");
		handler.AppendFormatted(eventType);
		handler.AppendLiteral(": ");
		handler.AppendFormatted(id);
		handler.AppendLiteral(" : ");
		Write(string.Create(provider, initialBuffer, ref handler));
	}

	private void WriteFooter(TraceEventCache eventCache)
	{
		if (eventCache == null)
		{
			return;
		}
		_indentLevel++;
		if (IsEnabled(TraceOptions.ProcessId))
		{
			WriteLine("ProcessId=" + eventCache.ProcessId);
		}
		if (IsEnabled(TraceOptions.LogicalOperationStack))
		{
			Write("LogicalOperationStack=");
			Stack logicalOperationStack = eventCache.LogicalOperationStack;
			bool flag = true;
			foreach (object item in logicalOperationStack)
			{
				if (!flag)
				{
					Write(", ");
				}
				else
				{
					flag = false;
				}
				Write(item.ToString());
			}
			WriteLine(string.Empty);
		}
		Span<char> span = stackalloc char[128];
		if (IsEnabled(TraceOptions.ThreadId))
		{
			WriteLine("ThreadId=" + eventCache.ThreadId);
		}
		if (IsEnabled(TraceOptions.DateTime))
		{
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> span2 = span;
			Span<char> initialBuffer = span2;
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(9, 1, formatProvider, span2);
			handler.AppendLiteral("DateTime=");
			handler.AppendFormatted(eventCache.DateTime, "o");
			WriteLine(string.Create(provider, initialBuffer, ref handler));
		}
		if (IsEnabled(TraceOptions.Timestamp))
		{
			IFormatProvider formatProvider = null;
			IFormatProvider provider2 = formatProvider;
			Span<char> span2 = span;
			Span<char> initialBuffer2 = span2;
			DefaultInterpolatedStringHandler handler2 = new DefaultInterpolatedStringHandler(10, 1, formatProvider, span2);
			handler2.AppendLiteral("Timestamp=");
			handler2.AppendFormatted(eventCache.Timestamp);
			WriteLine(string.Create(provider2, initialBuffer2, ref handler2));
		}
		if (IsEnabled(TraceOptions.Callstack))
		{
			WriteLine("Callstack=" + eventCache.Callstack);
		}
		_indentLevel--;
	}

	internal bool IsEnabled(TraceOptions opts)
	{
		return (opts & TraceOutputOptions) != 0;
	}
}
