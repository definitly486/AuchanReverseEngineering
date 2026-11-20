using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DryIoc.ImTools;

public static class PartitionedHashMap
{
	public const int PARTITION_COUNT_POWER_OF_TWO = 16;

	public const int PARTITION_HASH_MASK = 15;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V>[] CreateEmpty<K, V>(int partionCountOfPowerOfTwo = 16)
	{
		ImHashMap<K, V>[] array = new ImHashMap<K, V>[partionCountOfPowerOfTwo];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ImHashMap<K, V>.Empty;
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefault<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, int partHashMask = 15)
	{
		ImHashMap<K, V> imHashMap = parts[hash & partHashMask];
		if (imHashMap == null)
		{
			return default(V);
		}
		return imHashMap.GetValueOrDefault(hash, key);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefaultByReferenceEquals<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, int partHashMask = 15) where K : class
	{
		ImHashMap<K, V> imHashMap = parts[hash & partHashMask];
		if (imHashMap == null)
		{
			return default(V);
		}
		return imHashMap.GetValueOrDefaultByReferenceEquals(hash, key);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefault<K, V>(this ImHashMap<K, V>[] parts, K key, int partHashMask = 15)
	{
		return parts.GetValueOrDefault(key.GetHashCode(), key, partHashMask);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFind<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, out V value, int partHashMask = 15)
	{
		ImHashMap<K, V> imHashMap = parts[hash & partHashMask];
		if (imHashMap != null)
		{
			return imHashMap.TryFind(hash, key, out value);
		}
		value = default(V);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFind<K, V>(this ImHashMap<K, V>[] parts, K key, out V value, int partHashMask = 15)
	{
		return parts.TryFind(key.GetHashCode(), key, out value, partHashMask);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFindByReferenceEquals<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, out V value, int partHashMask = 15) where K : class
	{
		ImHashMap<K, V> imHashMap = parts[hash & partHashMask];
		if (imHashMap != null)
		{
			return imHashMap.TryFindByReferenceEquals(hash, key, out value);
		}
		value = default(V);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefaultByReferenceEquals<K, V>(this ImHashMap<K, V>[] parts, K key, int partHashMask = 15) where K : class
	{
		return parts.GetValueOrDefaultByReferenceEquals(key.GetHashCode(), key, partHashMask);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrUpdate<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, V value, int partHashMask = 15)
	{
		ref ImHashMap<K, V> reference = ref parts[hash & partHashMask];
		ImHashMap<K, V> imHashMap = reference;
		if (Interlocked.CompareExchange(ref reference, imHashMap.AddOrUpdate(hash, key, value), imHashMap) != imHashMap)
		{
			RefAddOrUpdatePart(ref reference, hash, key, value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrUpdate<K, V>(this ImHashMap<K, V>[] parts, K key, V value, int partHashMask = 15)
	{
		parts.AddOrUpdate(key.GetHashCode(), key, value, partHashMask);
	}

	private static void RefAddOrUpdatePart<K, V>(ref ImHashMap<K, V> part, int hash, K key, V value)
	{
		Ref.Swap(ref part, hash, key, value, (ImHashMap<K, V> x, int h, K k, V v) => x.AddOrUpdate(h, k, v));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrUpdate<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, V value, Update<K, V> update, int partHashMask = 15)
	{
		ref ImHashMap<K, V> reference = ref parts[hash & partHashMask];
		ImHashMap<K, V> imHashMap = reference;
		if (Interlocked.CompareExchange(ref reference, imHashMap.AddOrUpdate(hash, key, value, update), imHashMap) != imHashMap)
		{
			Ref.Swap(ref reference, new ImHashMapEntry<K, V>(hash, key, value), update, (ImHashMap<K, V> x, ImHashMapEntry<K, V> e, Update<K, V> u) => x.AddOrUpdate(e.Hash, e.Key, e.Value, u));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrKeep<K, V>(this ImHashMap<K, V>[] parts, int hash, K key, V value, int partHashMask = 15)
	{
		ref ImHashMap<K, V> reference = ref parts[hash & partHashMask];
		ImHashMap<K, V> imHashMap = reference;
		if (Interlocked.CompareExchange(ref reference, imHashMap.AddOrKeep(hash, key, value), imHashMap) != imHashMap)
		{
			RefAddOrKeepPart(ref reference, hash, key, value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddOrKeep<K, V>(this ImHashMap<K, V>[] parts, K key, V value, int partHashMask = 15)
	{
		parts.AddOrKeep(key.GetHashCode(), key, value, partHashMask);
	}

	private static void RefAddOrKeepPart<K, V>(ref ImHashMap<K, V> part, int hash, K key, V value)
	{
		Ref.Swap(ref part, hash, key, value, (ImHashMap<K, V> x, int h, K k, V v) => x.AddOrUpdate(h, k, v));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<ImHashMapEntry<K, V>> Enumerate<K, V>(this ImHashMap<K, V>[] parts, MapParentStack parents = null)
	{
		if (parents == null)
		{
			parents = new MapParentStack();
		}
		foreach (ImHashMap<K, V> imHashMap in parts)
		{
			if (imHashMap == ImHashMap<K, V>.Empty)
			{
				continue;
			}
			foreach (ImHashMapEntry<K, V> item in imHashMap.Enumerate(parents))
			{
				yield return item;
			}
		}
	}

	public static S ForEach<K, V, S>(this ImHashMap<K, V>[] parts, S state, Action<ImHashMapEntry<K, V>, int, S> handler, MapParentStack parents = null)
	{
		if (parents == null)
		{
			parents = new MapParentStack();
		}
		foreach (ImHashMap<K, V> imHashMap in parts)
		{
			if (imHashMap != ImHashMap<K, V>.Empty)
			{
				state = imHashMap.ForEach(state, handler, parents);
			}
		}
		return state;
	}
}
