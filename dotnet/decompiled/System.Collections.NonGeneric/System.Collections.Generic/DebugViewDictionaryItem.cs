using System.Diagnostics;

namespace System.Collections.Generic;

[DebuggerDisplay("{Value}", Name = "[{Key}]")]
internal readonly struct DebugViewDictionaryItem<TKey, TValue>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
	public TKey Key { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
	public TValue Value { get; }

	public DebugViewDictionaryItem(TKey key, TValue value)
	{
		Key = key;
		Value = value;
	}
}
