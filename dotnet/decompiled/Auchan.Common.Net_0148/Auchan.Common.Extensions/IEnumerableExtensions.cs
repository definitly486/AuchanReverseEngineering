using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Auchan.Common.Extensions;

public static class IEnumerableExtensions
{
	public static IEnumerable<T> Yield<T>(this T item)
	{
		yield return item;
	}

	public static int IndexOf<T>(this IEnumerable<T> source, T item)
	{
		int num = 0;
		foreach (T item2 in source)
		{
			if (EqualityComparer<T>.Default.Equals(item, item2))
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	public static int Count(this IEnumerable? enumerable)
	{
		if (enumerable != null)
		{
			if (enumerable is ICollection collection)
			{
				return collection.Count;
			}
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}
		return 0;
	}

	[return: NotNullIfNotNull("items")]
	public static object? ElementAt(this IEnumerable? items, int position)
	{
		if (items != null)
		{
			if (items is IList list)
			{
				return list[position];
			}
			IEnumerator enumerator = items.GetEnumerator();
			for (int i = 0; i <= position; i++)
			{
				enumerator.MoveNext();
			}
			return enumerator.Current;
		}
		return null;
	}

	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable) where T : class
	{
		return from e in enumerable
			where e != null
			select (e);
	}

	public static IEnumerable<TResult> SelectNotNull<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult?> selector) where TResult : class
	{
		return (from x in enumerable.Select(selector)
			where x != null
			select x).Cast<TResult>();
	}

	public static TSource? FirstOrDefaultRecursive<TSource>(this IEnumerable<TSource> self, Func<TSource, bool> predicate, Func<TSource, IEnumerable<TSource>?> childEnumerableSelector, int maxDepth = 10) where TSource : class
	{
		return FirstOrDefaultRecursive(self, predicate, childEnumerableSelector, 0, maxDepth);
	}

	private static TSource? FirstOrDefaultRecursive<TSource>(IEnumerable<TSource> self, Func<TSource, bool> predicate, Func<TSource, IEnumerable<TSource>?> childEnumerableSelector, int depth, int maxDepth) where TSource : class
	{
		if (depth >= maxDepth)
		{
			return null;
		}
		TSource val = self.FirstOrDefault(predicate);
		if (val != null)
		{
			return val;
		}
		foreach (TSource item in self)
		{
			IEnumerable<TSource> enumerable = childEnumerableSelector(item);
			if (enumerable != null)
			{
				TSource val2 = FirstOrDefaultRecursive(enumerable, predicate, childEnumerableSelector, depth + 1, maxDepth);
				if (val2 != null)
				{
					return val2;
				}
			}
		}
		return null;
	}

	public static IEnumerable<T> TakeSafe<T>(this IEnumerable<T> collection, int count)
	{
		if (collection.Count() <= count)
		{
			return collection;
		}
		return collection.Take(count).ToList();
	}

	public static IReadOnlyCollection<T> TakeSafe<T>(this IReadOnlyCollection<T> collection, int count)
	{
		if (collection.Count <= count)
		{
			return collection;
		}
		return collection.Take(count).ToImmutableList();
	}

	public static List<T> TakeSafe<T>(this List<T> collection, int count)
	{
		if (collection.Count <= count)
		{
			return collection;
		}
		return collection.Take(count).ToList();
	}

	public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
	{
		return new ObservableCollection<T>(source);
	}

	public static ObservableRangeCollection<T> ToObservableRangeCollection<T>(this IEnumerable<T> source)
	{
		return new ObservableRangeCollection<T>(source);
	}

	public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
	{
		foreach (T item in enumerable)
		{
			action(item);
		}
		return enumerable;
	}

	public static async Task<IEnumerable<T>> ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
	{
		foreach (T item in enumerable)
		{
			await action(item);
		}
		return enumerable;
	}

	public static IEnumerable<T> TakeEnd<T>(this IEnumerable<T> enumerable, int count)
	{
		int num = enumerable.Count();
		if (num <= count)
		{
			return enumerable;
		}
		return enumerable.Skip(num - count);
	}

	public static IEnumerable<T> TakeEnd<T>(this IEnumerable<T> enumerable, int count, int endOffset)
	{
		int num = enumerable.Count() - endOffset;
		if (num <= count)
		{
			return enumerable.Take(num);
		}
		return enumerable.TakeEnd(count + endOffset).Take(count);
	}

	public static bool ContainsIgnoreCase(this IEnumerable<string> enumerable, string str)
	{
		return enumerable.Any((string s) => s.EqualsIgnoreCase(str));
	}
}
