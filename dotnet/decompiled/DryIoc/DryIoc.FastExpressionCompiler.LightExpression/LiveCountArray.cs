using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public struct LiveCountArray<T>
{
	public int Count;

	public T[] Items;

	public LiveCountArray(T[] items)
	{
		Items = items;
		Count = items.Length;
	}

	public ref T PushSlot()
	{
		if (++Count > Items.Length)
		{
			Items = Expand(Items);
		}
		return ref Items[Count - 1];
	}

	public void PushSlot(T item)
	{
		if (++Count > Items.Length)
		{
			Items = Expand(Items);
		}
		Items[Count - 1] = item;
	}

	public void Pop()
	{
		Count--;
	}

	public static T[] Expand(T[] items)
	{
		if (items.Length == 0)
		{
			return new T[4];
		}
		int num = items.Length;
		T[] array = new T[num << 1];
		Array.Copy(items, 0, array, 0, num);
		return array;
	}
}
