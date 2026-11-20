using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ObservableLinq;

public static class ObservableCollectionExtensions
{
	public static ReadOnlyObservableCollection<T> AsReadOnly<T>(this ObservableCollection<T> source)
	{
		return new ReadOnlyObservableCollection<T>(source);
	}

	public static void SwitchTo<T>(this ObservableCollection<T> items, IEnumerable<T> newItems)
	{
		if (newItems == null)
		{
			throw new ArgumentNullException("newItems");
		}
		int num = 0;
		int num2 = items.Count;
		foreach (T newItem in newItems)
		{
			if (num >= num2)
			{
				items.Add(newItem);
			}
			else if (!object.Equals(items[num], newItem))
			{
				items[num] = newItem;
			}
			num++;
		}
		while (num2 > num)
		{
			items.RemoveAt(--num2);
		}
	}

	public static ReadOnlyObservableCollection<TResult> ObservableSelect<TSource, TResult>(this ObservableCollection<TSource> source, Func<TSource, TResult> selector)
	{
		return new ObservableSelectCollection<TSource, TResult>(source, selector).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<TResult> ObservableSelect<TSource, TResult>(this ReadOnlyObservableCollection<TSource> source, Func<TSource, TResult> selector)
	{
		return new ObservableSelectCollection<TSource, TResult>(source, selector).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<T> ObservableWhere<T>(this ObservableCollection<T> source, Func<T, bool> predicate)
	{
		return new ObservableWhereCollection<T>(source, predicate).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<T> ObservableWhere<T>(this ReadOnlyObservableCollection<T> source, Func<T, bool> predicate)
	{
		return new ObservableWhereCollection<T>(source, predicate).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<T> ObservableConcat<T>(this ObservableCollection<T> source, params ObservableCollection<T>[] other)
	{
		return new ObservableConcatCollection<T>(other.Prepend<ObservableCollection<T>>(source)).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<T> ObservableConcat<T>(this ReadOnlyObservableCollection<T> source, params ReadOnlyObservableCollection<T>[] other)
	{
		return new ObservableConcatCollection<T>(other.Prepend<ReadOnlyObservableCollection<T>>(source)).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<IObservableGrouping<TKey, TElement>> ObservableGroupBy<TKey, TElement>(this ObservableCollection<TElement> source, Func<TElement, TKey> keySelector)
	{
		return new ObservableGroupCollection<TKey, TElement>(source, keySelector).AsReadOnly();
	}

	public static ReadOnlyObservableCollection<IObservableGrouping<TKey, TElement>> ObservableGroupBy<TKey, TElement>(this ReadOnlyObservableCollection<TElement> source, Func<TElement, TKey> keySelector)
	{
		return new ObservableGroupCollection<TKey, TElement>(source, keySelector).AsReadOnly();
	}
}
