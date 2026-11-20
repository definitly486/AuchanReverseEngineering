using System.Diagnostics.Tracing;

namespace System.Data;

[EventSource(Name = "System.Data.DataCommonEventSource")]
internal sealed class DataCommonEventSource : EventSource
{
	internal static readonly DataCommonEventSource Log = new DataCommonEventSource();

	[Event(1, Level = EventLevel.Informational)]
	internal void Trace(string message)
	{
		WriteEvent(1, message);
	}

	[NonEvent]
	internal void Trace<T0>(string format, T0 arg0)
	{
		Log.IsEnabled();
	}

	[NonEvent]
	internal void Trace<T0, T1>(string format, T0 arg0, T1 arg1)
	{
		Log.IsEnabled();
	}

	[NonEvent]
	internal void Trace<T0, T1, T2>(string format, T0 arg0, T1 arg1, T2 arg2)
	{
		Log.IsEnabled();
	}

	[NonEvent]
	internal void Trace<T0, T1, T2, T3>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		Log.IsEnabled();
	}

	[NonEvent]
	internal void Trace<T0, T1, T2, T3, T4>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		Log.IsEnabled();
	}

	[NonEvent]
	internal void Trace<T0, T1, T2, T3, T4, T5, T6>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
		Log.IsEnabled();
	}

	[NonEvent]
	internal long EnterScope(string message)
	{
		long result = 0L;
		if (Log.IsEnabled())
		{
		}
		return result;
	}

	[Event(2, Level = EventLevel.Verbose)]
	private void EnterScope(long scopeId, string message)
	{
		WriteEvent(2, scopeId, message);
	}

	[NonEvent]
	internal long EnterScope<T1>(string format, T1 arg1)
	{
		Log.IsEnabled();
		return 0L;
	}

	[NonEvent]
	internal long EnterScope<T1, T2>(string format, T1 arg1, T2 arg2)
	{
		Log.IsEnabled();
		return 0L;
	}

	[NonEvent]
	internal long EnterScope<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
	{
		Log.IsEnabled();
		return 0L;
	}

	[NonEvent]
	internal long EnterScope<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		Log.IsEnabled();
		return 0L;
	}

	[Event(3, Level = EventLevel.Verbose)]
	internal void ExitScope(long scopeId)
	{
		WriteEvent(3, scopeId);
	}
}
