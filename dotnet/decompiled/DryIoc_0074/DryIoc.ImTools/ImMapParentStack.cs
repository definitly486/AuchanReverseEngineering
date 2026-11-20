using System;

namespace DryIoc.ImTools;

public sealed class ImMapParentStack<V>
{
	public struct Entry
	{
		public ImMapEntry<V> NextEntry;

		public ImMap<V> NextBranch;
	}

	private const int DefaultInitialCapacity = 4;

	public Entry[] Items;

	public ImMapParentStack(int capacity = 4)
	{
		Items = new Entry[capacity];
	}

	public void Put(int index, ImMapEntry<V> entry, ImMap<V> branch)
	{
		if (index >= Items.Length)
		{
			Items = Expand(Items);
		}
		ref Entry reference = ref Items[index];
		reference.NextEntry = entry;
		reference.NextBranch = branch;
	}

	private static Entry[] Expand(Entry[] items)
	{
		int num = items.Length;
		Entry[] array = new Entry[num << 1];
		Array.Copy(items, 0, array, 0, num);
		return array;
	}
}
