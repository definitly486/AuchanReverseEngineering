using System;
using System.Collections.Generic;
using System.Linq;

namespace Splat;

public sealed class MemoizingMRUCache<TParam, TVal> where TParam : notnull
{
	private readonly object _lockObject = new object();

	private readonly Func<TParam, object?, TVal> _calculationFunction;

	private readonly Action<TVal>? _releaseFunction;

	private readonly int _maxCacheSize;

	private readonly IEqualityComparer<TParam> _comparer;

	private LinkedList<TParam> _cacheMRUList;

	private Dictionary<TParam, (LinkedListNode<TParam> param, TVal value)> _cacheEntries;

	public MemoizingMRUCache(Func<TParam, object?, TVal> calculationFunc, int maxSize)
		: this(calculationFunc, maxSize, (Action<TVal>?)null, (IEqualityComparer<TParam>)EqualityComparer<TParam>.Default)
	{
	}

	public MemoizingMRUCache(Func<TParam, object?, TVal> calculationFunc, int maxSize, Action<TVal> onRelease)
		: this(calculationFunc, maxSize, onRelease, (IEqualityComparer<TParam>)EqualityComparer<TParam>.Default)
	{
	}

	public MemoizingMRUCache(Func<TParam, object?, TVal> calculationFunc, int maxSize, IEqualityComparer<TParam> paramComparer)
		: this(calculationFunc, maxSize, (Action<TVal>?)null, paramComparer)
	{
	}

	public MemoizingMRUCache(Func<TParam, object?, TVal> calculationFunc, int maxSize, Action<TVal>? onRelease, IEqualityComparer<TParam> paramComparer)
	{
		if (maxSize <= 0)
		{
			throw new ArgumentException("Max size must be larger than 0.", "maxSize");
		}
		_calculationFunction = calculationFunc ?? throw new ArgumentNullException("calculationFunc");
		_releaseFunction = onRelease;
		_maxCacheSize = maxSize;
		_comparer = paramComparer ?? EqualityComparer<TParam>.Default;
		_cacheMRUList = new LinkedList<TParam>();
		_cacheEntries = new Dictionary<TParam, (LinkedListNode<TParam>, TVal)>();
	}

	public TVal Get(TParam key)
	{
		return Get(key, null);
	}

	public TVal Get(TParam key, object? context = null)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		lock (_lockObject)
		{
			if (_cacheEntries.TryGetValue(key, out (LinkedListNode<TParam>, TVal) value))
			{
				RefreshEntry(value.Item1);
				return value.Item2;
			}
			TVal val = _calculationFunction(key, context);
			LinkedListNode<TParam> linkedListNode = new LinkedListNode<TParam>(key);
			_cacheMRUList.AddFirst(linkedListNode);
			_cacheEntries[key] = (linkedListNode, val);
			MaintainCache();
			return val;
		}
	}

	public bool TryGet(TParam key, out TVal? result)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		lock (_lockObject)
		{
			(LinkedListNode<TParam>, TVal) value;
			bool num = _cacheEntries.TryGetValue(key, out value);
			if (num)
			{
				RefreshEntry(value.Item1);
				result = value.Item2;
			}
			else
			{
				result = default(TVal);
			}
			return num;
		}
	}

	public void Invalidate(TParam key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		lock (_lockObject)
		{
			if (_cacheEntries.TryGetValue(key, out (LinkedListNode<TParam>, TVal) value))
			{
				TVal item = value.Item2;
				_cacheMRUList.Remove(value.Item1);
				_cacheEntries.Remove(key);
				_releaseFunction?.Invoke(item);
			}
		}
	}

	public void InvalidateAll(bool aggregateReleaseExceptions = false)
	{
		Dictionary<TParam, (LinkedListNode<TParam>, TVal)> dictionary = null;
		lock (_lockObject)
		{
			if (_releaseFunction == null || _cacheEntries == null)
			{
				_cacheMRUList = new LinkedList<TParam>();
				_cacheEntries = new Dictionary<TParam, (LinkedListNode<TParam>, TVal)>(_comparer);
				return;
			}
			if (_cacheEntries.Count == 0)
			{
				return;
			}
			dictionary = _cacheEntries;
			_cacheMRUList = new LinkedList<TParam>();
			_cacheEntries = new Dictionary<TParam, (LinkedListNode<TParam>, TVal)>(_comparer);
		}
		if (dictionary == null)
		{
			return;
		}
		if (aggregateReleaseExceptions)
		{
			List<Exception> list = new List<Exception>(dictionary.Count);
			foreach (KeyValuePair<TParam, (LinkedListNode<TParam>, TVal)> item2 in dictionary)
			{
				try
				{
					_releaseFunction?.Invoke(item2.Value.Item2);
				}
				catch (Exception item)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				throw new AggregateException("Exceptions throw during MRU Cache Invalidate All Item Release.", list);
			}
			return;
		}
		foreach (KeyValuePair<TParam, (LinkedListNode<TParam>, TVal)> item3 in dictionary)
		{
			_releaseFunction?.Invoke(item3.Value.Item2);
		}
	}

	public IEnumerable<TVal> CachedValues()
	{
		lock (_lockObject)
		{
			return _cacheEntries.Select<KeyValuePair<TParam, (LinkedListNode<TParam>, TVal)>, TVal>((KeyValuePair<TParam, (LinkedListNode<TParam> param, TVal value)> x) => x.Value.value);
		}
	}

	private void MaintainCache()
	{
		while (_cacheMRUList.Count > _maxCacheSize)
		{
			if (_cacheMRUList.Last != null)
			{
				TParam value = _cacheMRUList.Last.Value;
				_releaseFunction?.Invoke(_cacheEntries[value].value);
				_cacheEntries.Remove(_cacheMRUList.Last.Value);
				_cacheMRUList.RemoveLast();
			}
		}
	}

	private void RefreshEntry(LinkedListNode<TParam> item)
	{
		if (_cacheEntries.Count > 1)
		{
			_cacheMRUList.Remove(item);
			_cacheMRUList.AddFirst(item);
		}
	}

	private void Invariants()
	{
	}
}
