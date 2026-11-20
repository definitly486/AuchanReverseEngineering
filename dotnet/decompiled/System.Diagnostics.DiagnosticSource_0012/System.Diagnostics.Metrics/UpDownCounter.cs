using System.Collections.Generic;

namespace System.Diagnostics.Metrics;

public sealed class UpDownCounter<T> : Instrument<T> where T : struct
{
	internal UpDownCounter(Meter meter, string name, string unit, string description, IEnumerable<KeyValuePair<string, object>> tags)
		: base(meter, name, unit, description, tags)
	{
		Publish();
	}

	public void Add(T delta, in TagList tagList)
	{
		RecordMeasurement(delta, in tagList);
	}
}
