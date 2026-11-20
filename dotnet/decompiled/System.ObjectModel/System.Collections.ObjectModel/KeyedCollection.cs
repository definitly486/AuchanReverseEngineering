using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections.ObjectModel;

[Serializable]
[DebuggerTypeProxy(typeof(KeyedCollection<, >.KeyedCollectionDebugView))]
[DebuggerDisplay("Count = {Count}")]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class KeyedCollection<TKey, TItem> : Collection<TItem> where TKey : notnull
{
	private sealed class KeyedCollectionDebugView
	{
		[DebuggerDisplay("{Value}", Name = "[{Key}]")]
		internal readonly struct KeyedCollectionDebugViewItem
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
			public TKey Key { get; }

			[DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
			public TItem Value { get; }

			public KeyedCollectionDebugViewItem(TKey key, TItem value)
			{
				Key = key;
				Value = value;
			}
		}

		private readonly KeyedCollection<TKey, TItem> _collection;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyedCollectionDebugViewItem[] Items
		{
			get
			{
				KeyedCollectionDebugViewItem[] array = new KeyedCollectionDebugViewItem[_collection.Count];
				for (int i = 0; i < array.Length; i++)
				{
					TItem val = _collection[i];
					array[i] = new KeyedCollectionDebugViewItem(_collection.GetKeyForItem(val), val);
				}
				return array;
			}
		}

		public KeyedCollectionDebugView(KeyedCollection<TKey, TItem> collection)
		{
			ArgumentNullException.ThrowIfNull(collection, "collection");
			_collection = collection;
		}
	}

	private readonly IEqualityComparer<TKey> comparer;

	private Dictionary<TKey, TItem> dict;

	private int keyCount;

	private readonly int threshold;

	private new List<TItem> Items => (List<TItem>)base.Items;

	public TItem this[TKey key]
	{
		get
		{
			if (TryGetValue(key, out var item))
			{
				return item;
			}
			throw new KeyNotFoundException(System.SR.Format("Arg_KeyNotFoundWithKey", key.ToString()));
		}
	}

	protected IDictionary<TKey, TItem>? Dictionary => dict;

	protected KeyedCollection()
		: this((IEqualityComparer<TKey>?)null, 0)
	{
	}

	protected KeyedCollection(IEqualityComparer<TKey>? comparer)
		: this(comparer, 0)
	{
	}

	protected KeyedCollection(IEqualityComparer<TKey>? comparer, int dictionaryCreationThreshold)
		: base((IList<TItem>)new List<TItem>())
	{
		if (dictionaryCreationThreshold < -1)
		{
			throw new ArgumentOutOfRangeException("dictionaryCreationThreshold", "ArgumentOutOfRange_InvalidThreshold");
		}
		this.comparer = comparer ?? EqualityComparer<TKey>.Default;
		threshold = ((dictionaryCreationThreshold == -1) ? int.MaxValue : dictionaryCreationThreshold);
	}

	public bool Contains(TKey key)
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		if (dict != null)
		{
			return dict.ContainsKey(key);
		}
		foreach (TItem item in Items)
		{
			if (comparer.Equals(GetKeyForItem(item), key))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TItem item)
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		if (dict != null)
		{
			return dict.TryGetValue(key, out item);
		}
		foreach (TItem item2 in Items)
		{
			TKey keyForItem = GetKeyForItem(item2);
			if (keyForItem != null && comparer.Equals(key, keyForItem))
			{
				item = item2;
				return true;
			}
		}
		item = default(TItem);
		return false;
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		dict?.Clear();
		keyCount = 0;
	}

	protected abstract TKey GetKeyForItem(TItem item);

	protected override void InsertItem(int index, TItem item)
	{
		TKey keyForItem = GetKeyForItem(item);
		if (keyForItem != null)
		{
			AddKey(keyForItem, item);
		}
		base.InsertItem(index, item);
	}

	protected override void RemoveItem(int index)
	{
		TKey keyForItem = GetKeyForItem(Items[index]);
		if (keyForItem != null)
		{
			RemoveKey(keyForItem);
		}
		base.RemoveItem(index);
	}

	protected override void SetItem(int index, TItem item)
	{
		TKey keyForItem = GetKeyForItem(item);
		TKey keyForItem2 = GetKeyForItem(Items[index]);
		if (comparer.Equals(keyForItem2, keyForItem))
		{
			if (keyForItem != null && dict != null)
			{
				dict[keyForItem] = item;
			}
		}
		else
		{
			if (keyForItem != null)
			{
				AddKey(keyForItem, item);
			}
			if (keyForItem2 != null)
			{
				RemoveKey(keyForItem2);
			}
		}
		base.SetItem(index, item);
	}

	private void AddKey(TKey key, TItem item)
	{
		if (dict != null)
		{
			dict.Add(key, item);
			return;
		}
		if (keyCount == threshold)
		{
			CreateDictionary();
			dict.Add(key, item);
			return;
		}
		if (Contains(key))
		{
			throw new ArgumentException(System.SR.Format("Argument_AddingDuplicate", key), "key");
		}
		keyCount++;
	}

	private void CreateDictionary()
	{
		dict = new Dictionary<TKey, TItem>(comparer);
		foreach (TItem item in Items)
		{
			TKey keyForItem = GetKeyForItem(item);
			if (keyForItem != null)
			{
				dict.Add(keyForItem, item);
			}
		}
	}

	private void RemoveKey(TKey key)
	{
		if (dict != null)
		{
			dict.Remove(key);
		}
		else
		{
			keyCount--;
		}
	}
}
