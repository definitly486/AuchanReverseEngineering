using System;
using System.Collections.Generic;

namespace NLog.Internal;

internal static class CollectionExtensions
{
	public static IList<TItem> Filter<TItem, TState>(this IList<TItem> items, TState state, Func<TItem, TState, bool> filter)
	{
		bool flag = false;
		IList<TItem> list = null;
		for (int i = 0; i < items.Count; i++)
		{
			TItem val = items[i];
			if (filter(val, state))
			{
				if (flag && list == null)
				{
					list = new List<TItem>();
				}
				list?.Add(val);
				continue;
			}
			if (!flag && i > 0)
			{
				list = new List<TItem>();
				for (int j = 0; j < i; j++)
				{
					list.Add(items[j]);
				}
			}
			flag = true;
		}
		IList<TItem> list2 = list;
		if (list2 == null)
		{
			if (!flag)
			{
				return items;
			}
			IList<TItem> list3 = ArrayHelper.Empty<TItem>();
			list2 = list3;
		}
		return list2;
	}
}
