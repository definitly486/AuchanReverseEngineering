using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NLog.Internal;

internal struct SingleItemOptimizedHashSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
	public struct SingleItemScopedInsert : IDisposable
	{
		private readonly T _singleItem;

		private readonly HashSet<T>? _hashset;

		public SingleItemScopedInsert(T singleItem, ref SingleItemOptimizedHashSet<T> existing, bool forceHashSet, IEqualityComparer<T> comparer)
		{
			_singleItem = singleItem;
			if (existing._hashset != null)
			{
				existing._hashset.Add(singleItem);
				_hashset = existing._hashset;
			}
			else if (forceHashSet)
			{
				existing = new SingleItemOptimizedHashSet<T>(singleItem, existing, comparer);
				existing.Add(singleItem);
				_hashset = existing._hashset;
			}
			else
			{
				existing = new SingleItemOptimizedHashSet<T>(singleItem, existing, comparer);
				_hashset = null;
			}
		}

		public void Dispose()
		{
			if (_hashset != null)
			{
				_hashset.Remove(_singleItem);
			}
		}
	}

	public sealed class ReferenceEqualityComparer : IEqualityComparer<T>
	{
		public static readonly ReferenceEqualityComparer Default = new ReferenceEqualityComparer();

		bool IEqualityComparer<T>.Equals(T x, T y)
		{
			return (object)x == (object)y;
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}

	private readonly T? _singleItem;

	private HashSet<T>? _hashset;

	private readonly IEqualityComparer<T>? _comparer;

	private IEqualityComparer<T> Comparer => _comparer ?? EqualityComparer<T>.Default;

	public int Count => _hashset?.Count ?? ((!EqualityComparer<T>.Default.Equals(_singleItem, default(T))) ? 1 : 0);

	public bool IsReadOnly => false;

	public SingleItemOptimizedHashSet(T singleItem, SingleItemOptimizedHashSet<T> existing, IEqualityComparer<T>? comparer = null)
	{
		_comparer = existing._comparer ?? comparer ?? EqualityComparer<T>.Default;
		if (existing._hashset != null)
		{
			_hashset = new HashSet<T>(existing._hashset, _comparer);
			_hashset.Add(singleItem);
			_singleItem = default(T);
		}
		else if (existing.Count == 1 && existing._singleItem != null)
		{
			_hashset = new HashSet<T>(_comparer);
			_hashset.Add(existing._singleItem);
			_hashset.Add(singleItem);
			_singleItem = default(T);
		}
		else
		{
			_hashset = null;
			_singleItem = singleItem;
		}
	}

	public void Add(T item)
	{
		if (_hashset != null)
		{
			_hashset.Add(item);
			return;
		}
		HashSet<T> hashSet = new HashSet<T>(Comparer);
		if (Count == 1 && _singleItem != null)
		{
			hashSet.Add(_singleItem);
		}
		hashSet.Add(item);
		_hashset = hashSet;
	}

	public void Clear()
	{
		if (_hashset != null)
		{
			_hashset.Clear();
		}
		else
		{
			_hashset = new HashSet<T>(Comparer);
		}
	}

	public bool Contains(T item)
	{
		if (_hashset != null)
		{
			return _hashset.Contains(item);
		}
		if (Count == 1 && _singleItem != null)
		{
			return Comparer.Equals(_singleItem, item);
		}
		return false;
	}

	public bool Remove(T item)
	{
		if (_hashset != null)
		{
			return _hashset.Remove(item);
		}
		if (Count == 1 && _singleItem != null && Comparer.Equals(_singleItem, item))
		{
			_hashset = new HashSet<T>(Comparer);
			return true;
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (_hashset != null)
		{
			_hashset.CopyTo(array, arrayIndex);
		}
		else if (Count == 1 && _singleItem != null)
		{
			array[arrayIndex] = _singleItem;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		if (_hashset != null)
		{
			return _hashset.GetEnumerator();
		}
		return SingleItemEnumerator();
	}

	private IEnumerator<T> SingleItemEnumerator()
	{
		if (Count == 1 && _singleItem != null)
		{
			yield return _singleItem;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
