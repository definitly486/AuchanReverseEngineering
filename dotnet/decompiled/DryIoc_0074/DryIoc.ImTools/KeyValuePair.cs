using System.Collections.Generic;

namespace DryIoc.ImTools;

public static class KeyValuePair
{
	public static KeyValuePair<K, V> Pair<K, V>(this K key, V value)
	{
		return new KeyValuePair<K, V>(key, value);
	}
}
