using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DryIoc.ImTools;

public static class PartitionedMap
{
	public const int PARTITION_COUNT_POWER_OF_TWO = 16;

	public const int PARTITION_HASH_MASK = 15;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V>[] CreateEmpty<V>(int partionCountOfPowerOfTwo = 16)
	{
		ImMap<V>[] array = new ImMap<V>[partionCountOfPowerOfTwo];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ImMap<V>.Empty;
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefault<V>(this ImMap<V>[] parts, int hash, int partHashMask = 15)
	{
		ImMap<V> imMap = parts[hash & partHashMask];
		if (imMap != null)
		{
			ImMapEntry<V> entryOrNull = imMap.GetEntryOrNull(hash);
			if (entryOrNull != null)
			{
				return entryOrNull.Value;
			}
		}
		return default(V);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFind<V>(this ImMap<V>[] parts, int hash, out V value, int partHashMask = 15)
	{
		ImMap<V> imMap = parts[hash & partHashMask];
		if (imMap != null)
		{
			return imMap.TryFind(hash, out value);
		}
		value = default(V);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrUpdate<V>(this ImMap<V>[] parts, int hash, V value, int partHashMask = 15)
	{
		ref ImMap<V> reference = ref parts[hash & partHashMask];
		ImMap<V> imMap = reference;
		if (Interlocked.CompareExchange(ref reference, imMap.AddOrUpdate(hash, value), imMap) != imMap)
		{
			RefAddOrUpdatePart(ref reference, hash, value);
		}
	}

	private static void RefAddOrUpdatePart<V>(ref ImMap<V> part, int hash, V value)
	{
		Ref.Swap(ref part, hash, value, (ImMap<V> x, int h, V v) => x.AddOrUpdate(h, v));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrUpdate<V>(this ImMap<V>[] parts, int hash, V value, Update<int, V> update, int partHashMask = 15)
	{
		ref ImMap<V> reference = ref parts[hash & partHashMask];
		ImMap<V> imMap = reference;
		if (Interlocked.CompareExchange(ref reference, imMap.AddOrUpdate(hash, value, update), imMap) != imMap)
		{
			Ref.Swap(ref reference, hash, value, update, (ImMap<V> x, int h, V k, Update<int, V> u) => x.AddOrUpdate(h, k, u));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrKeep<V>(this ImMap<V>[] parts, int hash, V value, int partHashMask = 15)
	{
		ref ImMap<V> reference = ref parts[hash & partHashMask];
		ImMap<V> imMap = reference;
		if (Interlocked.CompareExchange(ref reference, imMap.AddOrKeep(hash, value), imMap) != imMap)
		{
			RefAddOrKeepPart(ref reference, hash, value);
		}
	}

	private static void RefAddOrKeepPart<V>(ref ImMap<V> part, int hash, V value)
	{
		Ref.Swap(ref part, hash, value, (ImMap<V> x, int h, V v) => x.AddOrUpdate(h, v));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Update<V>(this ImMap<V>[] parts, int hash, V value, int partHashMask = 15)
	{
		ref ImMap<V> reference = ref parts[hash & partHashMask];
		ImMap<V> imMap = reference;
		if (Interlocked.CompareExchange(ref reference, imMap.Update(hash, value), imMap) != imMap)
		{
			RefUpdatePart(ref reference, hash, value);
		}
	}

	private static void RefUpdatePart<V>(ref ImMap<V> part, int hash, V value)
	{
		Ref.Swap(ref part, hash, value, (ImMap<V> x, int h, V v) => x.Update(h, v));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<ImMapEntry<V>> Enumerate<V>(this ImMap<V>[] parts)
	{
		foreach (ImMap<V> imMap in parts)
		{
			if (imMap == ImMap<V>.Empty)
			{
				continue;
			}
			foreach (ImMapEntry<V> item in imMap.Enumerate())
			{
				yield return item;
			}
		}
	}

	public static S ForEach<V, S>(this ImMap<V>[] parts, S state, Action<ImMapEntry<V>, int, S> handler, MapParentStack parents = null)
	{
		if (parents == null)
		{
			parents = new MapParentStack();
		}
		foreach (ImMap<V> imMap in parts)
		{
			if (imMap != ImMap<V>.Empty)
			{
				state = imMap.ForEach(state, handler, parents);
			}
		}
		return state;
	}
}
