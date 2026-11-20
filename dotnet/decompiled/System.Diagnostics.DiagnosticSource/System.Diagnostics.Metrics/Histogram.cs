using System.Collections.Generic;

namespace System.Diagnostics.Metrics;

public sealed class Histogram<T> : Instrument<T> where T : struct
{
	internal Histogram(Meter meter, string name, string unit, string description, IEnumerable<KeyValuePair<string, object>> tags, InstrumentAdvice<T> advice)
		: base(meter, name, unit, description, tags, advice)
	{
		Publish();
	}

	public void Record(T value, in TagList tagList)
	{
		RecordMeasurement(value, in tagList);
	}
}
