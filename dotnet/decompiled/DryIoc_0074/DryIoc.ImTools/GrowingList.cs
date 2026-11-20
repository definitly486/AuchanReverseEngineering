using System;
using System.Runtime.CompilerServices;

namespace DryIoc.ImTools;

public static class GrowingList
{
	public const int DefaultInitialCapacity = 2;

	public static ref T PushSlot<T>(ref T[] items, int count)
	{
		if (items == null)
		{
			items = new T[2];
		}
		else if (count >= items.Length)
		{
			Expand(ref items);
		}
		return ref items[count];
	}

	public static void Push<T>(ref T[] items, int count, T item)
	{
		if (items == null)
		{
			items = new T[2];
		}
		else if (count >= items.Length)
		{
			Expand(ref items);
		}
		items[count] = item;
	}

	internal static void Expand<T>(ref T[] items)
	{
		int num = items.Length;
		T[] array = new T[num << 1];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = items[i];
			}
		}
		else
		{
			Array.Copy(items, 0, array, 0, num);
		}
	}

	public static T[] ResizeToArray<T>(T[] items, int count)
	{
		if (count < items.Length)
		{
			Array.Resize(ref items, count);
		}
		return items;
	}

	public static string ToString<T>(T[] items, int count)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Count ");
		defaultInterpolatedStringHandler.AppendFormatted(count);
		defaultInterpolatedStringHandler.AppendLiteral(" of ");
		object value;
		if (count != 0 && items != null && items.Length != 0)
		{
			string[] obj = new string[5] { "first (", null, null, null, null };
			T val = items[0];
			obj[1] = val?.ToString();
			obj[2] = ") and last (";
			val = items[count - 1];
			obj[3] = val?.ToString();
			obj[4] = ")";
			value = string.Concat(obj);
		}
		else
		{
			value = "empty";
		}
		defaultInterpolatedStringHandler.AppendFormatted((string?)value);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}
}
public struct GrowingList<T>
{
	public const int DefaultInitialCapacity = 2;

	public T[] Items;

	public int Count;

	public GrowingList(T[] items, int count = 0)
	{
		Items = items;
		Count = count;
	}

	public ref T PushSlot()
	{
		if (Items == null)
		{
			Items = new T[2];
		}
		else if (Count >= Items.Length)
		{
			GrowingList.Expand(ref Items);
		}
		return ref Items[Count++];
	}

	public void Push(T item)
	{
		if (Items == null)
		{
			Items = new T[2];
		}
		else if (Count >= Items.Length)
		{
			GrowingList.Expand(ref Items);
		}
		Items[Count++] = item;
	}

	public void Pop()
	{
		Count--;
	}

	public T[] ResizeToArray()
	{
		T[] array = Items;
		if (Count < array.Length)
		{
			Array.Resize(ref array, Count);
		}
		return array;
	}

	public T PopItem()
	{
		return Items[--Count];
	}

	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Count ");
		defaultInterpolatedStringHandler.AppendFormatted(Count);
		defaultInterpolatedStringHandler.AppendLiteral(" of ");
		object value;
		if (Count != 0 && Items != null && Items.Length != 0)
		{
			string[] obj = new string[5] { "first (", null, null, null, null };
			T val = Items[0];
			obj[1] = val?.ToString();
			obj[2] = ") and last (";
			val = Items[Count - 1];
			obj[3] = val?.ToString();
			obj[4] = ")";
			value = string.Concat(obj);
		}
		else
		{
			value = "empty";
		}
		defaultInterpolatedStringHandler.AppendFormatted((string?)value);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}
}
