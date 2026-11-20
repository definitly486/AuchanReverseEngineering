using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Collections.Immutable;

public static class ImmutableArray
{
	public static ImmutableArray<T> Create<T>()
	{
		return ImmutableArray<T>.Empty;
	}

	public static ImmutableArray<T> CreateRange<T>(IEnumerable<T> items)
	{
		Requires.NotNull(items, "items");
		if (items is IImmutableArray immutableArray)
		{
			return new ImmutableArray<T>((T[])(immutableArray.Array ?? throw new InvalidOperationException("InvalidOperationOnDefaultArray")));
		}
		if (items.TryGetCount(out var count))
		{
			return new ImmutableArray<T>(items.ToArray(count));
		}
		return new ImmutableArray<T>(items.ToArray());
	}

	public static ImmutableArray<T>.Builder CreateBuilder<T>()
	{
		return Create<T>().ToBuilder();
	}

	public static ImmutableArray<T>.Builder CreateBuilder<T>(int initialCapacity)
	{
		return new ImmutableArray<T>.Builder(initialCapacity);
	}

	public static ImmutableArray<TSource> ToImmutableArray<TSource>(this IEnumerable<TSource> items)
	{
		if (items is ImmutableArray<TSource>)
		{
			return (ImmutableArray<TSource>)(object)items;
		}
		return CreateRange(items);
	}

	public static ImmutableArray<TSource> ToImmutableArray<TSource>(this ImmutableArray<TSource>.Builder builder)
	{
		Requires.NotNull(builder, "builder");
		return builder.ToImmutable();
	}
}
[CollectionBuilder(typeof(ImmutableArray), "Create")]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
[System.Runtime.Versioning.NonVersionable]
public readonly struct ImmutableArray<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IList<T>, ICollection<T>, IEquatable<ImmutableArray<T>>, IList, ICollection, IImmutableArray, IStructuralComparable, IStructuralEquatable, IImmutableList<T>
{
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableArrayBuilderDebuggerProxy<>))]
	public sealed class Builder : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		private T[] _elements;

		private int _count;

		public int Capacity => _elements.Length;

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				Requires.Range(value >= 0, "value");
				if (value < _count)
				{
					if (_count - value > 64)
					{
						Array.Clear(_elements, value, _count - value);
					}
					else
					{
						for (int i = value; i < Count; i++)
						{
							_elements[i] = default(T);
						}
					}
				}
				else if (value > _count)
				{
					EnsureCapacity(value);
				}
				_count = value;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index >= Count)
				{
					ThrowIndexOutOfRangeException();
				}
				return _elements[index];
			}
			set
			{
				if (index >= Count)
				{
					ThrowIndexOutOfRangeException();
				}
				_elements[index] = value;
			}
		}

		bool ICollection<T>.IsReadOnly => false;

		internal Builder(int capacity)
		{
			Requires.Range(capacity >= 0, "capacity");
			_elements = new T[capacity];
			_count = 0;
		}

		internal Builder()
			: this(8)
		{
		}

		private static void ThrowIndexOutOfRangeException()
		{
			throw new IndexOutOfRangeException();
		}

		public ImmutableArray<T> ToImmutable()
		{
			return new ImmutableArray<T>(ToArray());
		}

		public ImmutableArray<T> MoveToImmutable()
		{
			if (Capacity != Count)
			{
				throw new InvalidOperationException("CapacityMustEqualCountOnMove");
			}
			T[] elements = _elements;
			_elements = ImmutableArray<T>.Empty.array;
			_count = 0;
			return new ImmutableArray<T>(elements);
		}

		public void Clear()
		{
			Count = 0;
		}

		public void Insert(int index, T item)
		{
			Requires.Range(index >= 0 && index <= Count, "index");
			EnsureCapacity(Count + 1);
			if (index < Count)
			{
				Array.Copy(_elements, index, _elements, index + 1, Count - index);
			}
			_count++;
			_elements[index] = item;
		}

		public void Add(T item)
		{
			int num = _count + 1;
			EnsureCapacity(num);
			_elements[_count] = item;
			_count = num;
		}

		public void AddRange(T[] items, int length)
		{
			Requires.NotNull(items, "items");
			Requires.Range(length >= 0 && length <= items.Length, "length");
			int count = Count;
			Count += length;
			Array.Copy(items, 0, _elements, count, length);
		}

		public void AddRange(ImmutableArray<T> items)
		{
			AddRange(items, items.Length);
		}

		public void AddRange(ImmutableArray<T> items, int length)
		{
			Requires.Range(length >= 0, "length");
			if (items.array != null)
			{
				AddRange(items.array, length);
			}
		}

		public bool Remove(T element)
		{
			int num = IndexOf(element);
			if (num >= 0)
			{
				RemoveAt(num);
				return true;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			Requires.Range(index >= 0 && index < Count, "index");
			if (index < Count - 1)
			{
				Array.Copy(_elements, index + 1, _elements, index, Count - index - 1);
			}
			Count--;
		}

		public bool Contains(T item)
		{
			return IndexOf(item) >= 0;
		}

		public T[] ToArray()
		{
			if (Count == 0)
			{
				return ImmutableArray<T>.Empty.array;
			}
			T[] array = new T[Count];
			Array.Copy(_elements, array, Count);
			return array;
		}

		public void CopyTo(T[] array, int index)
		{
			Requires.NotNull(array, "array");
			Requires.Range(index >= 0 && index + Count <= array.Length, "index");
			Array.Copy(_elements, 0, array, index, Count);
		}

		private void EnsureCapacity(int capacity)
		{
			if (_elements.Length < capacity)
			{
				int newSize = Math.Max(_elements.Length * 2, capacity);
				Array.Resize(ref _elements, newSize);
			}
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, 0, _count, EqualityComparer<T>.Default);
		}

		public int IndexOf(T item, int startIndex, int count, IEqualityComparer<T>? equalityComparer)
		{
			if (count == 0 && startIndex == 0)
			{
				return -1;
			}
			Requires.Range(startIndex >= 0 && startIndex < Count, "startIndex");
			Requires.Range(count >= 0 && startIndex + count <= Count, "count");
			if (equalityComparer == null)
			{
				equalityComparer = EqualityComparer<T>.Default;
			}
			if (equalityComparer == EqualityComparer<T>.Default)
			{
				return Array.IndexOf(_elements, item, startIndex, count);
			}
			for (int i = startIndex; i < startIndex + count; i++)
			{
				if (equalityComparer.Equals(_elements[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private sealed class EnumeratorObject : IEnumerator<T>, IEnumerator, IDisposable
	{
		private static readonly IEnumerator<T> s_EmptyEnumerator = new EnumeratorObject(ImmutableArray<T>.Empty.array);

		private readonly T[] _array;

		private int _index;

		public T Current
		{
			get
			{
				if ((uint)_index < (uint)_array.Length)
				{
					return _array[_index];
				}
				throw new InvalidOperationException();
			}
		}

		object IEnumerator.Current => Current;

		private EnumeratorObject(T[] array)
		{
			_index = -1;
			_array = array;
		}

		public bool MoveNext()
		{
			int num = _index + 1;
			int num2 = _array.Length;
			if ((uint)num <= (uint)num2)
			{
				_index = num;
				return (uint)num < (uint)num2;
			}
			return false;
		}

		void IEnumerator.Reset()
		{
			_index = -1;
		}

		public void Dispose()
		{
		}

		internal static IEnumerator<T> Create(T[] array)
		{
			if (array.Length != 0)
			{
				return new EnumeratorObject(array);
			}
			return s_EmptyEnumerator;
		}
	}

	public static readonly ImmutableArray<T> Empty = new ImmutableArray<T>(new T[0]);

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	internal readonly T[] array;

	T IList<T>.this[int index]
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool ICollection<T>.IsReadOnly => true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	int ICollection<T>.Count
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Length;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	int IReadOnlyCollection<T>.Count
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Length;
		}
	}

	T IReadOnlyList<T>.this[int index]
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray[index];
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool IList.IsFixedSize => true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool IList.IsReadOnly => true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	int ICollection.Count
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Length;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool ICollection.IsSynchronized => true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	object ICollection.SyncRoot
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	object? IList.this[int index]
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public T this[int index]
	{
		[System.Runtime.Versioning.NonVersionable]
		get
		{
			return array[index];
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Length
	{
		[System.Runtime.Versioning.NonVersionable]
		get
		{
			return array.Length;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool IsDefault => array == null;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	Array? IImmutableArray.Array => array;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string DebuggerDisplay
	{
		get
		{
			ImmutableArray<T> immutableArray = this;
			if (!immutableArray.IsDefault)
			{
				return $"Length = {immutableArray.Length}";
			}
			return "Uninitialized";
		}
	}

	public int IndexOf(T item)
	{
		ImmutableArray<T> immutableArray = this;
		return immutableArray.IndexOf(item, 0, immutableArray.Length, EqualityComparer<T>.Default);
	}

	public int IndexOf(T item, int startIndex, int count, IEqualityComparer<T>? equalityComparer)
	{
		ImmutableArray<T> immutableArray = this;
		immutableArray.ThrowNullRefIfNotInitialized();
		if (count == 0 && startIndex == 0)
		{
			return -1;
		}
		Requires.Range(startIndex >= 0 && startIndex < immutableArray.Length, "startIndex");
		Requires.Range(count >= 0 && startIndex + count <= immutableArray.Length, "count");
		if (equalityComparer == null)
		{
			equalityComparer = EqualityComparer<T>.Default;
		}
		if (equalityComparer == EqualityComparer<T>.Default)
		{
			return Array.IndexOf(immutableArray.array, item, startIndex, count);
		}
		for (int i = startIndex; i < startIndex + count; i++)
		{
			if (equalityComparer.Equals(immutableArray.array[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public bool Contains(T item)
	{
		return IndexOf(item) >= 0;
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
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

	int IList.Add(object value)
	{
		throw new NotSupportedException();
	}

	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	private static bool IsCompatibleObject(object value)
	{
		if (!(value is T))
		{
			if (default(T) == null)
			{
				return value == null;
			}
			return false;
		}
		return true;
	}

	bool IList.Contains(object value)
	{
		if (IsCompatibleObject(value))
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Contains((T)value);
		}
		return false;
	}

	int IList.IndexOf(object value)
	{
		if (IsCompatibleObject(value))
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.IndexOf((T)value);
		}
		return -1;
	}

	void IList.Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object value)
	{
		throw new NotSupportedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		ImmutableArray<T> immutableArray = this;
		immutableArray.ThrowInvalidOperationIfNotInitialized();
		Array.Copy(immutableArray.array, 0, array, index, immutableArray.Length);
	}

	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		ImmutableArray<T> immutableArray = this;
		Array array = other as Array;
		if (array == null && other is IImmutableArray immutableArray2)
		{
			array = immutableArray2.Array;
			if (immutableArray.array == null && array == null)
			{
				return true;
			}
			if (immutableArray.array == null)
			{
				return false;
			}
		}
		return ((IStructuralEquatable)immutableArray.array).Equals((object?)array, comparer);
	}

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		ImmutableArray<T> immutableArray = this;
		return ((IStructuralEquatable)immutableArray.array)?.GetHashCode(comparer) ?? immutableArray.GetHashCode();
	}

	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		ImmutableArray<T> immutableArray = this;
		Array array = other as Array;
		if (array == null && other is IImmutableArray immutableArray2)
		{
			array = immutableArray2.Array;
			if (immutableArray.array == null && array == null)
			{
				return 0;
			}
			if ((immutableArray.array == null) ^ (array == null))
			{
				throw new ArgumentException("ArrayInitializedStateNotEqual", "other");
			}
		}
		if (array != null)
		{
			return ((IStructuralComparable)(immutableArray.array ?? throw new ArgumentException("ArrayInitializedStateNotEqual", "other"))).CompareTo((object?)array, comparer);
		}
		throw new ArgumentException("ArrayLengthsNotEqual", "other");
	}

	internal ImmutableArray(T[] items)
	{
		array = items;
	}

	[System.Runtime.Versioning.NonVersionable]
	public static bool operator ==(ImmutableArray<T> left, ImmutableArray<T> right)
	{
		return left.Equals(right);
	}

	[System.Runtime.Versioning.NonVersionable]
	public static bool operator !=(ImmutableArray<T> left, ImmutableArray<T> right)
	{
		return !left.Equals(right);
	}

	public static bool operator ==(ImmutableArray<T>? left, ImmutableArray<T>? right)
	{
		return left.GetValueOrDefault().Equals(right.GetValueOrDefault());
	}

	public static bool operator !=(ImmutableArray<T>? left, ImmutableArray<T>? right)
	{
		return !left.GetValueOrDefault().Equals(right.GetValueOrDefault());
	}

	public void CopyTo(T[] destination, int destinationIndex)
	{
		ImmutableArray<T> immutableArray = this;
		immutableArray.ThrowNullRefIfNotInitialized();
		Array.Copy(immutableArray.array, 0, destination, destinationIndex, immutableArray.Length);
	}

	public ImmutableArray<T>.Builder ToBuilder()
	{
		ImmutableArray<T> items = this;
		if (items.Length == 0)
		{
			return new Builder();
		}
		Builder builder = new Builder(items.Length);
		builder.AddRange(items);
		return builder;
	}

	public override int GetHashCode()
	{
		ImmutableArray<T> immutableArray = this;
		if (immutableArray.array != null)
		{
			return immutableArray.array.GetHashCode();
		}
		return 0;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is IImmutableArray immutableArray)
		{
			return array == immutableArray.Array;
		}
		return false;
	}

	[System.Runtime.Versioning.NonVersionable]
	public bool Equals(ImmutableArray<T> other)
	{
		return array == other.array;
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		ImmutableArray<T> immutableArray = this;
		immutableArray.ThrowInvalidOperationIfNotInitialized();
		return EnumeratorObject.Create(immutableArray.array);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		ImmutableArray<T> immutableArray = this;
		immutableArray.ThrowInvalidOperationIfNotInitialized();
		return EnumeratorObject.Create(immutableArray.array);
	}

	internal void ThrowNullRefIfNotInitialized()
	{
		_ = array.Length;
	}

	private void ThrowInvalidOperationIfNotInitialized()
	{
		if (IsDefault)
		{
			throw new InvalidOperationException("InvalidOperationOnDefaultArray");
		}
	}
}
