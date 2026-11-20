using System.Collections.Generic;

namespace Auchan.Common.Extensions;

public static class DictionaryExtensions
{
	public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> a, IReadOnlyDictionary<TKey, TValue> b)
	{
		foreach (KeyValuePair<TKey, TValue> item in b)
		{
			if (a.ContainsKey(item.Key))
			{
				a[item.Key] = item.Value;
			}
			else
			{
				a.Add(item.Key, item.Value);
			}
		}
		return a;
	}

	public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> a, IDictionary<TKey, TValue> b)
	{
		foreach (KeyValuePair<TKey, TValue> item in b)
		{
			if (a.ContainsKey(item.Key))
			{
				a[item.Key] = item.Value;
			}
			else
			{
				a.Add(item.Key, item.Value);
			}
		}
		return a;
	}
}
