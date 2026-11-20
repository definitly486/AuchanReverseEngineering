using System;

namespace DryIoc.ImTools;

public sealed class MapParentStack
{
	private const int DefaultInitialCapacity = 4;

	private object[] _items;

	public MapParentStack()
	{
		_items = new object[4];
	}

	public void Put(object item, int index)
	{
		if (index >= _items.Length)
		{
			_items = Expand(_items);
		}
		_items[index] = item;
	}

	public object Get(int index)
	{
		return _items[index];
	}

	private static object[] Expand(object[] items)
	{
		int num = items.Length;
		object[] array = new object[num << 1];
		Array.Copy(items, 0, array, 0, num);
		return array;
	}
}
