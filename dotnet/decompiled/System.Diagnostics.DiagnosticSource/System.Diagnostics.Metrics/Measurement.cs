using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.Metrics;

public readonly struct Measurement<T> where T : struct
{
	private readonly KeyValuePair<string, object>[] _tags;

	public ReadOnlySpan<KeyValuePair<string, object?>> Tags => _tags.AsSpan();

	public T Value { get; }

	public Measurement(T value)
	{
		_tags = Instrument.EmptyTags;
		Value = value;
	}

	public Measurement(T value, [ParamCollection] scoped ReadOnlySpan<KeyValuePair<string, object?>> tags)
	{
		_tags = tags.ToArray();
		Value = value;
	}
}
