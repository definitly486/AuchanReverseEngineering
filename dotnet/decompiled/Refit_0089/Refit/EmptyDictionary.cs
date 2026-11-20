using System.Collections.Generic;

namespace Refit;

internal static class EmptyDictionary<TKey, TValue>
{
	private static Dictionary<TKey, TValue> Value = new Dictionary<TKey, TValue>();

	internal static Dictionary<TKey, TValue> Get()
	{
		return Value;
	}
}
