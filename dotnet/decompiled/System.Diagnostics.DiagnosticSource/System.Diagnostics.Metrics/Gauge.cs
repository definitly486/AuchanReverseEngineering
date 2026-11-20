using System.Collections.Generic;

namespace System.Diagnostics.Metrics;

public sealed class Gauge<T> : Instrument<T> where T : struct
{
	internal Gauge(Meter meter, string name, string unit, string description, IEnumerable<KeyValuePair<string, object>> tags)
		: base(meter, name, unit, description, tags)
	{
		Publish();
	}
}
