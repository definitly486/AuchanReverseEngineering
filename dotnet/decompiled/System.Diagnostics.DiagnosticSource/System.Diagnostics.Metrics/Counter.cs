using System.Collections.Generic;

namespace System.Diagnostics.Metrics;

public sealed class Counter<T> : Instrument<T> where T : struct
{
	internal Counter(Meter meter, string name, string unit, string description, IEnumerable<KeyValuePair<string, object>> tags)
		: base(meter, name, unit, description, tags)
	{
		Publish();
	}

	public void Add(T delta, KeyValuePair<string, object?> tag)
	{
		RecordMeasurement(delta, tag);
	}
}
