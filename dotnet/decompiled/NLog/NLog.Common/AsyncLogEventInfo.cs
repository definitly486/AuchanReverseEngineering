using System;

namespace NLog.Common;

public readonly struct AsyncLogEventInfo : IEquatable<AsyncLogEventInfo>
{
	public LogEventInfo LogEvent { get; }

	public AsyncContinuation Continuation { get; }

	public AsyncLogEventInfo(LogEventInfo logEvent, AsyncContinuation continuation)
	{
		LogEvent = logEvent;
		Continuation = continuation;
	}

	public static bool operator ==(AsyncLogEventInfo eventInfo1, AsyncLogEventInfo eventInfo2)
	{
		return eventInfo1.Equals(eventInfo2);
	}

	public static bool operator !=(AsyncLogEventInfo eventInfo1, AsyncLogEventInfo eventInfo2)
	{
		return !eventInfo1.Equals(eventInfo2);
	}

	public bool Equals(AsyncLogEventInfo other)
	{
		if ((object)Continuation == other.Continuation)
		{
			return LogEvent == other.LogEvent;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is AsyncLogEventInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return LogEvent.GetHashCode() ^ Continuation.GetHashCode();
	}
}
