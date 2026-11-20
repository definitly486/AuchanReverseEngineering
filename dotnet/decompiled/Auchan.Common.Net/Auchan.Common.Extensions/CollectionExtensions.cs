using System.Collections.Generic;

namespace Auchan.Common.Extensions;

public static class CollectionExtensions
{
	public static void AddCollection<T>(this ICollection<T> source, IEnumerable<T> collection)
	{
		foreach (T item in collection)
		{
			source.Add(item);
		}
	}

	public static void InsertSafe<T>(this IList<T> source, int index, T item)
	{
		if (index >= source.Count)
		{
			source.Add(item);
		}
		else
		{
			source.Insert(index, item);
		}
	}
}
