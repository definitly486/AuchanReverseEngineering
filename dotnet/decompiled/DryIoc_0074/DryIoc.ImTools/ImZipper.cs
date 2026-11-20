using System;

namespace DryIoc.ImTools;

public sealed class ImZipper<T>
{
	public static readonly ImZipper<T> Empty = new ImZipper<T>();

	public readonly int Index;

	public readonly int Count;

	public readonly ImList<T> Left;

	public readonly ImList<T> Right;

	public readonly T Focus;

	public bool IsEmpty => Count == 0;

	public override string ToString()
	{
		if (!IsEmpty)
		{
			return Count + ":" + Left.Reverse()?.ToString() + "|" + Index + ":" + Focus?.ToString() + "|" + Right;
		}
		return "[||]";
	}

	public ImZipper<T> Append(T focus)
	{
		return PushLeft(focus);
	}

	public ImZipper<T> PushLeft(T focus)
	{
		if (!IsEmpty)
		{
			return new ImZipper<T>(Left.Push(Focus), focus, Index + 1, Right, Count + 1);
		}
		return new ImZipper<T>(ImList<T>.Empty, focus, 0, ImList<T>.Empty, 1);
	}

	public ImZipper<T> Insert(T focus)
	{
		return PushRight(focus);
	}

	public ImZipper<T> PushRight(T focus)
	{
		if (!IsEmpty)
		{
			return new ImZipper<T>(Left, focus, Index, Right.Push(Focus), Count + 1);
		}
		return new ImZipper<T>(ImList<T>.Empty, focus, 0, ImList<T>.Empty, 1);
	}

	public ImZipper<T> PopLeft()
	{
		if (!IsEmpty)
		{
			if (!Left.IsEmpty || !Right.IsEmpty)
			{
				if (Left.IsEmpty)
				{
					return new ImZipper<T>(Left, Right.Head, Index, Right.Tail, Count - 1);
				}
				return new ImZipper<T>(Left.Tail, Left.Head, Index - 1, Right, Count - 1);
			}
			return Empty;
		}
		return this;
	}

	public ImZipper<T> PopRight()
	{
		if (!IsEmpty)
		{
			if (!Left.IsEmpty || !Right.IsEmpty)
			{
				if (Right.IsEmpty)
				{
					return new ImZipper<T>(Left.Tail, Left.Head, Index - 1, Right, Count - 1);
				}
				return new ImZipper<T>(Left, Right.Head, Index, Right.Tail, Count - 1);
			}
			return Empty;
		}
		return this;
	}

	public ImZipper<T> ShiftLeft()
	{
		if (!IsEmpty && !Left.IsEmpty)
		{
			return new ImZipper<T>(Left.Tail, Left.Head, Index - 1, Right.Push(Focus), Count);
		}
		return this;
	}

	public ImZipper<T> ShiftRight()
	{
		if (!IsEmpty && !Right.IsEmpty)
		{
			return new ImZipper<T>(Left.Push(Focus), Right.Head, Index + 1, Right.Tail, Count);
		}
		return this;
	}

	public ImZipper<T> WithFocus(T focus)
	{
		if (!IsEmpty)
		{
			return new ImZipper<T>(Left, focus, Index, Right, Count);
		}
		return this;
	}

	public ImZipper<R> Map<R>(Func<T, R> map)
	{
		if (!IsEmpty)
		{
			return new ImZipper<R>(Left.Reverse().Fold(ImList<R>.Empty, (T x, ImList<R> r) => r.Push(map(x))), map(Focus), Index, Right.Map(map), Count);
		}
		return ImZipper<R>.Empty;
	}

	public ImZipper<R> Map<R>(Func<T, int, R> map)
	{
		if (!IsEmpty)
		{
			return new ImZipper<R>(Left.Reverse().Fold(ImList<R>.Empty, (T x, int i, ImList<R> r) => r.Push(map(x, i))), map(Focus, Index), Index, Right.Map((T x, int i) => map(x, Index + 1 + i)), Count);
		}
		return ImZipper<R>.Empty;
	}

	private ImZipper()
	{
		Index = -1;
	}

	private ImZipper(ImList<T> left, T focus, int index, ImList<T> right, int count)
	{
		Left = left;
		Focus = focus;
		Index = index;
		Right = right;
		Count = count;
	}
}
public static class ImZipper
{
	public static ImZipper<T> Zip<T>(params T[] items)
	{
		if (items.IsNullOrEmpty())
		{
			return ImZipper<T>.Empty;
		}
		ImZipper<T> imZipper = ImZipper<T>.Empty;
		for (int i = 0; i < items.Length; i++)
		{
			imZipper = imZipper.PushLeft(items[i]);
		}
		return imZipper;
	}

	public static T[] ToArray<T>(this ImZipper<T> z)
	{
		if (z.IsEmpty)
		{
			return ArrayTools.Empty<T>();
		}
		T[] array = new T[z.Count];
		z.Fold(array, delegate(T x, int i, T[] xs)
		{
			xs[i] = x;
			return xs;
		});
		return array;
	}

	public static ImZipper<T> ShiftTo<T>(this ImZipper<T> z, int i)
	{
		if (i < 0 || i >= z.Count || i == z.Index)
		{
			return z;
		}
		while (i < z.Index)
		{
			z = z.ShiftLeft();
		}
		while (i > z.Index)
		{
			z = z.ShiftRight();
		}
		return z;
	}

	public static ImZipper<T> Update<T>(this ImZipper<T> z, Func<T, T> update)
	{
		if (z.IsEmpty)
		{
			return z;
		}
		T val = update(z.Focus);
		if ((object)z.Focus == (object)val || (val != null && val.Equals(z.Focus)))
		{
			return z;
		}
		return z.WithFocus(val);
	}

	public static ImZipper<T> UpdateAt<T>(this ImZipper<T> z, int i, Func<T, T> update)
	{
		if (i >= 0 && i < z.Count)
		{
			return z.ShiftTo(i).Update(update);
		}
		return z;
	}

	public static ImZipper<T> RemoveAt<T>(this ImZipper<T> z, int i)
	{
		if (i >= 0 && i < z.Count)
		{
			return z.ShiftTo(i).PopLeft();
		}
		return z;
	}

	public static S Fold<T, S>(this ImZipper<T> z, S state, Func<T, S, S> handler)
	{
		if (!z.IsEmpty)
		{
			return z.Right.Fold(handler(z.Focus, z.Left.Reverse().Fold(state, handler)), handler);
		}
		return state;
	}

	public static S Fold<T, S>(this ImZipper<T> z, S state, Func<T, int, S, S> handler)
	{
		if (z.IsEmpty)
		{
			return state;
		}
		int focusIndex = z.Index;
		S arg = z.Left.Reverse().Fold(state, handler);
		return z.Right.Fold(handler(z.Focus, focusIndex, arg), (T x, int i, S r) => handler(x, focusIndex + i + 1, r));
	}

	public static void ForEach<T>(this ImZipper<T> z, Action<T> effect)
	{
		if (!z.IsEmpty)
		{
			if (!z.Left.IsEmpty)
			{
				z.Left.Reverse().ForEach(effect);
			}
			effect(z.Focus);
			if (!z.Right.IsEmpty)
			{
				z.Right.ForEach(effect);
			}
		}
	}
}
