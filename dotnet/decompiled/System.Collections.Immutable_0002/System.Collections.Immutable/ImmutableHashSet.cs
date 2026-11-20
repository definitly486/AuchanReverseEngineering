using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable;

[CollectionBuilder(typeof(ImmutableHashSet), "Create")]
[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
public sealed class ImmutableHashSet<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, ICollection<T>, ISet<T>, ICollection, IStrongEnumerable<T, ImmutableHashSet<T>.Enumerator>, IReadOnlySet<T>
{
	private sealed class HashBucketByValueEqualityComparer : IEqualityComparer<HashBucket>
	{
		private static readonly IEqualityComparer<HashBucket> s_defaultInstance = new HashBucketByValueEqualityComparer(EqualityComparer<T>.Default);

		private readonly IEqualityComparer<T> _valueComparer;

		internal static IEqualityComparer<HashBucket> DefaultInstance => s_defaultInstance;

		internal HashBucketByValueEqualityComparer(IEqualityComparer<T> valueComparer)
		{
			Requires.NotNull(valueComparer, "valueComparer");
			_valueComparer = valueComparer;
		}

		public bool Equals(HashBucket x, HashBucket y)
		{
			return x.EqualsByValue(y, _valueComparer);
		}

		public int GetHashCode(HashBucket obj)
		{
			throw new NotSupportedException();
		}
	}

	private sealed class HashBucketByRefEqualityComparer : IEqualityComparer<HashBucket>
	{
		private static readonly IEqualityComparer<HashBucket> s_defaultInstance = new HashBucketByRefEqualityComparer();

		internal static IEqualityComparer<HashBucket> DefaultInstance => s_defaultInstance;

		private HashBucketByRefEqualityComparer()
		{
		}

		public bool Equals(HashBucket x, HashBucket y)
		{
			return x.EqualsByRef(y);
		}

		public int GetHashCode(HashBucket obj)
		{
			throw new NotSupportedException();
		}
	}

	[DebuggerDisplay("Count = {Count}")]
	public sealed class Builder
	{
		public int Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		internal int Version
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}
	}

	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable, IStrongEnumerator<T>
	{
		private readonly Builder _builder;

		private SortedInt32KeyNode<HashBucket>.Enumerator _mapEnumerator;

		private HashBucket.Enumerator _bucketEnumerator;

		private int _enumeratingBuilderVersion;

		public T Current
		{
			get
			{
				_mapEnumerator.ThrowIfDisposed();
				return _bucketEnumerator.Current;
			}
		}

		object? IEnumerator.Current => Current;

		internal Enumerator(SortedInt32KeyNode<HashBucket> root, Builder builder = null)
		{
			_builder = builder;
			_mapEnumerator = new SortedInt32KeyNode<HashBucket>.Enumerator(root);
			_bucketEnumerator = default(HashBucket.Enumerator);
			_enumeratingBuilderVersion = builder?.Version ?? (-1);
		}

		public bool MoveNext()
		{
			ThrowIfChanged();
			if (_bucketEnumerator.MoveNext())
			{
				return true;
			}
			if (_mapEnumerator.MoveNext())
			{
				_bucketEnumerator = new HashBucket.Enumerator(_mapEnumerator.Current.Value);
				return _bucketEnumerator.MoveNext();
			}
			return false;
		}

		public void Reset()
		{
			_enumeratingBuilderVersion = ((_builder != null) ? _builder.Version : (-1));
			_mapEnumerator.Reset();
			_bucketEnumerator.Dispose();
			_bucketEnumerator = default(HashBucket.Enumerator);
		}

		public void Dispose()
		{
			_mapEnumerator.Dispose();
			_bucketEnumerator.Dispose();
		}

		private void ThrowIfChanged()
		{
			if (_builder != null && _builder.Version != _enumeratingBuilderVersion)
			{
				throw new InvalidOperationException("CollectionModifiedDuringEnumeration");
			}
		}
	}

	internal enum OperationResult
	{
		SizeChanged,
		NoChangeRequired
	}

	internal readonly struct HashBucket
	{
		internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private enum Position
			{
				BeforeFirst,
				First,
				Additional,
				End
			}

			private readonly HashBucket _bucket;

			private bool _disposed;

			private Position _currentPosition;

			private ImmutableList<T>.Enumerator _additionalEnumerator;

			object IEnumerator.Current => Current;

			public T Current
			{
				get
				{
					ThrowIfDisposed();
					return _currentPosition switch
					{
						Position.First => _bucket._firstValue, 
						Position.Additional => _additionalEnumerator.Current, 
						_ => throw new InvalidOperationException(), 
					};
				}
			}

			internal Enumerator(HashBucket bucket)
			{
				_disposed = false;
				_bucket = bucket;
				_currentPosition = Position.BeforeFirst;
				_additionalEnumerator = default(ImmutableList<T>.Enumerator);
			}

			public bool MoveNext()
			{
				ThrowIfDisposed();
				if (_bucket.IsEmpty)
				{
					_currentPosition = Position.End;
					return false;
				}
				switch (_currentPosition)
				{
				case Position.BeforeFirst:
					_currentPosition = Position.First;
					return true;
				case Position.First:
					if (_bucket._additionalElements.IsEmpty)
					{
						_currentPosition = Position.End;
						return false;
					}
					_currentPosition = Position.Additional;
					_additionalEnumerator = new ImmutableList<T>.Enumerator(_bucket._additionalElements);
					return _additionalEnumerator.MoveNext();
				case Position.Additional:
					return _additionalEnumerator.MoveNext();
				case Position.End:
					return false;
				default:
					throw new InvalidOperationException();
				}
			}

			public void Reset()
			{
				ThrowIfDisposed();
				_additionalEnumerator.Dispose();
				_currentPosition = Position.BeforeFirst;
			}

			public void Dispose()
			{
				_disposed = true;
				_additionalEnumerator.Dispose();
			}

			private void ThrowIfDisposed()
			{
				if (_disposed)
				{
					Requires.FailObjectDisposed(this);
				}
			}
		}

		private readonly T _firstValue;

		private readonly ImmutableList<T>.Node _additionalElements;

		internal bool IsEmpty => _additionalElements == null;

		private HashBucket(T firstElement, ImmutableList<T>.Node additionalElements = null)
		{
			_firstValue = firstElement;
			_additionalElements = additionalElements ?? ImmutableList<T>.Node.EmptyNode;
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException();
		}

		public override int GetHashCode()
		{
			throw new NotSupportedException();
		}

		internal bool EqualsByRef(HashBucket other)
		{
			if ((object)_firstValue == (object)other._firstValue)
			{
				return _additionalElements == other._additionalElements;
			}
			return false;
		}

		internal bool EqualsByValue(HashBucket other, IEqualityComparer<T> valueComparer)
		{
			if (valueComparer.Equals(_firstValue, other._firstValue))
			{
				return _additionalElements == other._additionalElements;
			}
			return false;
		}

		internal HashBucket Add(T value, IEqualityComparer<T> valueComparer, out OperationResult result)
		{
			if (IsEmpty)
			{
				result = OperationResult.SizeChanged;
				return new HashBucket(value);
			}
			if (valueComparer.Equals(value, _firstValue) || _additionalElements.IndexOf(value, valueComparer) >= 0)
			{
				result = OperationResult.NoChangeRequired;
				return this;
			}
			result = OperationResult.SizeChanged;
			return new HashBucket(_firstValue, _additionalElements.Add(value));
		}

		internal bool Contains(T value, IEqualityComparer<T> valueComparer)
		{
			if (IsEmpty)
			{
				return false;
			}
			if (!valueComparer.Equals(value, _firstValue))
			{
				return _additionalElements.IndexOf(value, valueComparer) >= 0;
			}
			return true;
		}

		internal void Freeze()
		{
			_additionalElements?.Freeze();
		}
	}

	private readonly struct MutationInput
	{
		private readonly SortedInt32KeyNode<HashBucket> _root;

		private readonly IEqualityComparer<T> _equalityComparer;

		private readonly int _count;

		private readonly IEqualityComparer<HashBucket> _hashBucketEqualityComparer;

		internal SortedInt32KeyNode<HashBucket> Root => _root;

		internal IEqualityComparer<T> EqualityComparer => _equalityComparer;

		internal int Count => _count;

		internal IEqualityComparer<HashBucket> HashBucketEqualityComparer => _hashBucketEqualityComparer;

		internal MutationInput(ImmutableHashSet<T> set)
		{
			Requires.NotNull(set, "set");
			_root = set._root;
			_equalityComparer = set._equalityComparer;
			_count = set._count;
			_hashBucketEqualityComparer = set._hashBucketEqualityComparer;
		}
	}

	private enum CountType
	{
		Adjustment,
		FinalValue
	}

	private readonly struct MutationResult
	{
		private readonly SortedInt32KeyNode<HashBucket> _root;

		private readonly int _count;

		private readonly CountType _countType;

		internal SortedInt32KeyNode<HashBucket> Root => _root;

		internal int Count => _count;

		internal CountType CountType => _countType;

		internal MutationResult(SortedInt32KeyNode<HashBucket> root, int count, CountType countType = CountType.Adjustment)
		{
			Requires.NotNull(root, "root");
			_root = root;
			_count = count;
			_countType = countType;
		}

		internal ImmutableHashSet<T> Finalize(ImmutableHashSet<T> priorSet)
		{
			Requires.NotNull(priorSet, "priorSet");
			int num = Count;
			if (CountType == CountType.Adjustment)
			{
				num += priorSet._count;
			}
			return priorSet.Wrap(Root, num);
		}
	}

	public static readonly ImmutableHashSet<T> Empty = new ImmutableHashSet<T>(SortedInt32KeyNode<HashBucket>.EmptyNode, EqualityComparer<T>.Default, 0);

	private static readonly Action<KeyValuePair<int, HashBucket>> s_FreezeBucketAction = delegate(KeyValuePair<int, HashBucket> kv)
	{
		kv.Value.Freeze();
	};

	private readonly IEqualityComparer<T> _equalityComparer;

	private readonly int _count;

	private readonly SortedInt32KeyNode<HashBucket> _root;

	private readonly IEqualityComparer<HashBucket> _hashBucketEqualityComparer;

	public int Count => _count;

	public bool IsEmpty => Count == 0;

	public IEqualityComparer<T> KeyComparer => _equalityComparer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	object ICollection.SyncRoot => this;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool ICollection.IsSynchronized => true;

	private MutationInput Origin => new MutationInput(this);

	bool ICollection<T>.IsReadOnly => true;

	internal ImmutableHashSet(IEqualityComparer<T> equalityComparer)
		: this(SortedInt32KeyNode<HashBucket>.EmptyNode, equalityComparer, 0)
	{
	}

	private ImmutableHashSet(SortedInt32KeyNode<HashBucket> root, IEqualityComparer<T> equalityComparer, int count)
	{
		Requires.NotNull(root, "root");
		Requires.NotNull(equalityComparer, "equalityComparer");
		root.Freeze(s_FreezeBucketAction);
		_root = root;
		_count = count;
		_equalityComparer = equalityComparer;
		_hashBucketEqualityComparer = GetHashBucketEqualityComparer(equalityComparer);
	}

	public ImmutableHashSet<T> Union(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		return Union(other, avoidWithComparer: false);
	}

	public bool SetEquals(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		if (this == other)
		{
			return true;
		}
		return SetEquals(other, Origin);
	}

	public bool IsProperSubsetOf(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		return IsProperSubsetOf(other, Origin);
	}

	public bool IsProperSupersetOf(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		return IsProperSupersetOf(other, Origin);
	}

	public bool IsSubsetOf(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		return IsSubsetOf(other, Origin);
	}

	public bool IsSupersetOf(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		return IsSupersetOf(other, Origin);
	}

	public bool Overlaps(IEnumerable<T> other)
	{
		Requires.NotNull(other, "other");
		return Overlaps(other, Origin);
	}

	public bool Contains(T item)
	{
		return Contains(item, Origin);
	}

	public ImmutableHashSet<T> WithComparer(IEqualityComparer<T>? equalityComparer)
	{
		if (equalityComparer == null)
		{
			equalityComparer = EqualityComparer<T>.Default;
		}
		if (equalityComparer == _equalityComparer)
		{
			return this;
		}
		return new ImmutableHashSet<T>(equalityComparer).Union(this, avoidWithComparer: true);
	}

	bool ISet<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	void ISet<T>.ExceptWith(IEnumerable<T> other)
	{
		throw new NotSupportedException();
	}

	void ISet<T>.IntersectWith(IEnumerable<T> other)
	{
		throw new NotSupportedException();
	}

	void ISet<T>.SymmetricExceptWith(IEnumerable<T> other)
	{
		throw new NotSupportedException();
	}

	void ISet<T>.UnionWith(IEnumerable<T> other)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		Requires.NotNull(array, "array");
		Requires.Range(arrayIndex >= 0, "arrayIndex");
		Requires.Range(array.Length >= arrayIndex + Count, "arrayIndex");
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array[arrayIndex++] = current;
		}
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	void ICollection.CopyTo(Array array, int arrayIndex)
	{
		Requires.NotNull(array, "array");
		Requires.Range(arrayIndex >= 0, "arrayIndex");
		Requires.Range(array.Length >= arrayIndex + Count, "arrayIndex");
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array.SetValue(current, arrayIndex++);
		}
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(_root);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		if (!IsEmpty)
		{
			return GetEnumerator();
		}
		return Enumerable.Empty<T>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private static bool IsSupersetOf(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		foreach (T item in other.GetEnumerableDisposable<T, Enumerator>())
		{
			if (!Contains(item, origin))
			{
				return false;
			}
		}
		return true;
	}

	private static bool Contains(T item, MutationInput origin)
	{
		int key = ((item != null) ? origin.EqualityComparer.GetHashCode(item) : 0);
		if (origin.Root.TryGetValue(key, out var value))
		{
			return value.Contains(item, origin.EqualityComparer);
		}
		return false;
	}

	private static MutationResult Union(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		int num = 0;
		SortedInt32KeyNode<HashBucket> sortedInt32KeyNode = origin.Root;
		foreach (T item in other.GetEnumerableDisposable<T, Enumerator>())
		{
			int num2 = ((item != null) ? origin.EqualityComparer.GetHashCode(item) : 0);
			OperationResult result;
			HashBucket newBucket = sortedInt32KeyNode.GetValueOrDefault(num2).Add(item, origin.EqualityComparer, out result);
			if (result == OperationResult.SizeChanged)
			{
				sortedInt32KeyNode = UpdateRoot(sortedInt32KeyNode, num2, origin.HashBucketEqualityComparer, newBucket);
				num++;
			}
		}
		return new MutationResult(sortedInt32KeyNode, num);
	}

	private static bool Overlaps(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		if (origin.Root.IsEmpty)
		{
			return false;
		}
		foreach (T item in other.GetEnumerableDisposable<T, Enumerator>())
		{
			if (Contains(item, origin))
			{
				return true;
			}
		}
		return false;
	}

	private static bool SetEquals(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
		if (origin.Count != hashSet.Count)
		{
			return false;
		}
		foreach (T item in hashSet)
		{
			if (!Contains(item, origin))
			{
				return false;
			}
		}
		return true;
	}

	private static SortedInt32KeyNode<HashBucket> UpdateRoot(SortedInt32KeyNode<HashBucket> root, int hashCode, IEqualityComparer<HashBucket> hashBucketEqualityComparer, HashBucket newBucket)
	{
		bool replacedExistingValue;
		if (newBucket.IsEmpty)
		{
			return root.Remove(hashCode, out replacedExistingValue);
		}
		bool mutated;
		return root.SetItem(hashCode, newBucket, hashBucketEqualityComparer, out replacedExistingValue, out mutated);
	}

	private static bool IsProperSubsetOf(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		if (origin.Root.IsEmpty)
		{
			return other.Any();
		}
		HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
		if (origin.Count >= hashSet.Count)
		{
			return false;
		}
		int num = 0;
		bool flag = false;
		foreach (T item in hashSet)
		{
			if (Contains(item, origin))
			{
				num++;
			}
			else
			{
				flag = true;
			}
			if (num == origin.Count && flag)
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsProperSupersetOf(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		if (origin.Root.IsEmpty)
		{
			return false;
		}
		int num = 0;
		foreach (T item in other.GetEnumerableDisposable<T, Enumerator>())
		{
			num++;
			if (!Contains(item, origin))
			{
				return false;
			}
		}
		return origin.Count > num;
	}

	private static bool IsSubsetOf(IEnumerable<T> other, MutationInput origin)
	{
		Requires.NotNull(other, "other");
		if (origin.Root.IsEmpty)
		{
			return true;
		}
		HashSet<T> hashSet = new HashSet<T>(other, origin.EqualityComparer);
		int num = 0;
		foreach (T item in hashSet)
		{
			if (Contains(item, origin))
			{
				num++;
			}
		}
		return num == origin.Count;
	}

	private static IEqualityComparer<HashBucket> GetHashBucketEqualityComparer(IEqualityComparer<T> valueComparer)
	{
		if (!ImmutableExtensions.IsValueType<T>())
		{
			return HashBucketByRefEqualityComparer.DefaultInstance;
		}
		if (valueComparer == EqualityComparer<T>.Default)
		{
			return HashBucketByValueEqualityComparer.DefaultInstance;
		}
		return new HashBucketByValueEqualityComparer(valueComparer);
	}

	private ImmutableHashSet<T> Wrap(SortedInt32KeyNode<HashBucket> root, int adjustedCountIfDifferentRoot)
	{
		if (root == _root)
		{
			return this;
		}
		return new ImmutableHashSet<T>(root, _equalityComparer, adjustedCountIfDifferentRoot);
	}

	private ImmutableHashSet<T> Union(IEnumerable<T> items, bool avoidWithComparer)
	{
		Requires.NotNull(items, "items");
		if (IsEmpty && !avoidWithComparer && items is ImmutableHashSet<T> immutableHashSet)
		{
			return immutableHashSet.WithComparer(KeyComparer);
		}
		return Union(items, Origin).Finalize(this);
	}
}
public static class ImmutableHashSet
{
	public static ImmutableHashSet<TSource> ToImmutableHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? equalityComparer)
	{
		if (source is ImmutableHashSet<TSource> immutableHashSet)
		{
			return immutableHashSet.WithComparer(equalityComparer);
		}
		return ImmutableHashSet<TSource>.Empty.WithComparer(equalityComparer).Union(source);
	}

	public static ImmutableHashSet<TSource> ToImmutableHashSet<TSource>(this IEnumerable<TSource> source)
	{
		return source.ToImmutableHashSet(null);
	}
}
