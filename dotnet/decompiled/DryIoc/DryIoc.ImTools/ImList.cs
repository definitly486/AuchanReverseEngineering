using System;
using System.Collections.Generic;
using System.Linq;

namespace DryIoc.ImTools;

public sealed class ImList<T>
{
	public static readonly ImList<T> Empty = new ImList<T>();

	public readonly T Head;

	public readonly ImList<T> Tail;

	public bool IsEmpty => Tail == null;

	public ImList<T> Push(T head)
	{
		return new ImList<T>(head, this);
	}

	public IEnumerable<T> Enumerate()
	{
		if (Tail != null)
		{
			ImList<T> list = this;
			while (list.Tail != null)
			{
				yield return list.Head;
				list = list.Tail;
			}
		}
	}

	public override string ToString()
	{
		if (!IsEmpty)
		{
			if (!Tail.IsEmpty)
			{
				if (!Tail.Tail.IsEmpty)
				{
					if (!Tail.Tail.Tail.IsEmpty)
					{
						return "[" + Head?.ToString() + "," + Tail.Head?.ToString() + "," + Tail.Tail.Head?.ToString() + ", ...]";
					}
					return "[" + Head?.ToString() + "," + Tail.Head?.ToString() + "," + Tail.Tail.Head?.ToString() + "]";
				}
				return "[" + Head?.ToString() + "," + Tail.Head?.ToString() + "]";
			}
			return "[" + Head?.ToString() + "]";
		}
		return "[]";
	}

	private ImList()
	{
	}

	private ImList(T head, ImList<T> tail)
	{
		Head = head;
		Tail = tail;
	}
}
public static class ImList
{
	public static void Deconstruct<T>(this ImList<T> list, out T head, out ImList<T> tail, out bool isEmpty)
	{
		head = list.Head;
		tail = list.Tail;
		isEmpty = list.IsEmpty;
	}

	public static ImList<T> List<T>(params T[] items)
	{
		ImList<T> imList = ImList<T>.Empty;
		if (items != null)
		{
			for (int num = items.Length - 1; num >= 0; num--)
			{
				imList = imList.Push(items[num]);
			}
		}
		return imList;
	}

	public static ImList<T> ToImList<T>(this IList<T> source)
	{
		ImList<T> imList = ImList<T>.Empty;
		if (source != null)
		{
			for (int num = source.Count - 1; num >= 0; num--)
			{
				imList = imList.Push(source[num]);
			}
		}
		return imList;
	}

	public static ImList<T> ToImList<T>(this IEnumerable<T> source)
	{
		if (source is IList<T> source2)
		{
			return source2.ToImList();
		}
		ImList<T> imList = ImList<T>.Empty;
		if (source != null)
		{
			foreach (T item in source)
			{
				imList = imList.Push(item);
			}
		}
		return imList.Reverse();
	}

	public static ImList<T> List<T>(this T head)
	{
		return ImList<T>.Empty.Push(head);
	}

	public static ImList<T> List<T>(this T head, ImList<T> tail)
	{
		return tail.Push(head);
	}

	public static void ForEach<T>(this ImList<T> list, Action<T> effect)
	{
		while (!list.IsEmpty)
		{
			effect(list.Head);
			list = list.Tail;
		}
	}

	public static S Fold<T, S>(this ImList<T> list, S state, Func<T, S, S> handler)
	{
		if (list.IsEmpty)
		{
			return state;
		}
		S val = state;
		while (!list.IsEmpty)
		{
			val = handler(list.Head, val);
			list = list.Tail;
		}
		return val;
	}

	public static S Fold<T, S>(this ImList<T> list, S state, Func<T, int, S, S> handler)
	{
		if (list.IsEmpty)
		{
			return state;
		}
		S val = state;
		int num = 0;
		while (!list.IsEmpty)
		{
			val = handler(list.Head, num, val);
			list = list.Tail;
			num++;
		}
		return val;
	}

	public static ImList<T> Reverse<T>(this ImList<T> list)
	{
		if (list.IsEmpty || list.Tail.IsEmpty)
		{
			return list;
		}
		ImList<T> imList = ImList<T>.Empty;
		while (!list.IsEmpty)
		{
			imList = imList.Push(list.Head);
			list = list.Tail;
		}
		return imList;
	}

	public static ImList<R> Map<T, R>(this ImList<T> list, Func<T, R> map)
	{
		return list.Fold(ImList<R>.Empty, (T x, ImList<R> r) => map(x).List(r)).Reverse();
	}

	public static ImList<R> Map<T, R>(this ImList<T> list, Func<T, int, R> map)
	{
		return list.Fold(ImList<R>.Empty, (T x, int i, ImList<R> r) => map(x, i).List(r)).Reverse();
	}

	public static T[] ToArray<T>(this ImList<T> source)
	{
		if (!source.IsEmpty)
		{
			if (!source.Tail.IsEmpty)
			{
				return source.Enumerate().ToArray();
			}
			return new T[1] { source.Head };
		}
		return ArrayTools.Empty<T>();
	}
}
