using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers;

[LayoutRenderer("counter")]
[ThreadAgnostic]
public class CounterLayoutRenderer : LayoutRenderer, IRawValue
{
	private sealed class GlobalSequence
	{
		private long _value;

		public string Name { get; }

		public GlobalSequence(string sequenceName, long initialValue)
		{
			Name = sequenceName;
			_value = initialValue;
		}

		public long NextValue(int increment)
		{
			return Interlocked.Add(ref _value, increment);
		}
	}

	private static readonly ConcurrentDictionary<string, GlobalSequence> Sequences = new ConcurrentDictionary<string, GlobalSequence>(StringComparer.Ordinal);

	private static GlobalSequence? _firstSequence;

	private long _value;

	public long Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	public int Increment { get; set; } = 1;

	public Layout? Sequence { get; set; }

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		long nextValue = GetNextValue(logEvent);
		builder.Append(nextValue);
	}

	private long GetNextValue(LogEventInfo logEvent)
	{
		if (Sequence == null)
		{
			return Interlocked.Add(ref _value, Increment);
		}
		string sequenceName = Sequence.Render(logEvent);
		return GetNextGlobalValue(sequenceName);
	}

	private long GetNextGlobalValue(string sequenceName)
	{
		GlobalSequence value = _firstSequence;
		if (value == null)
		{
			value = new GlobalSequence(sequenceName, Value);
			Interlocked.CompareExchange(ref _firstSequence, value, null);
			value = _firstSequence;
		}
		if (value.Name.Equals(sequenceName))
		{
			return value.NextValue(Increment);
		}
		if (!Sequences.TryGetValue(sequenceName, out value))
		{
			value = new GlobalSequence(sequenceName, Value);
			if (!Sequences.TryAdd(sequenceName, value))
			{
				Sequences.TryGetValue(sequenceName, out value);
			}
		}
		return value.NextValue(Increment);
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = GetNextValue(logEvent);
		return true;
	}
}
