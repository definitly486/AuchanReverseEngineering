using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Immutable;

public static class ImmutableList
{
	public static ImmutableList<T> Create<T>()
	{
		return ImmutableList<T>.Empty;
	}

	public static ImmutableList<T> Create<T>([ParamCollection] scoped ReadOnlySpan<T> items)
	{
		return ImmutableList<T>.Empty.AddRange(items);
	}

	public static ImmutableList<T>.Builder CreateBuilder<T>()
	{
		return Create<T>().ToBuilder();
	}

	public static ImmutableList<TSource> ToImmutableList<TSource>(this IEnumerable<TSource> source)
	{
		if (source is ImmutableList<TSource> result)
		{
			return result;
		}
		return ImmutableList<TSource>.Empty.AddRange(source);
	}

	public static int IndexOf<T>(this IImmutableList<T> list, T item, IEqualityComparer<T>? equalityComparer)
	{
		Requires.NotNull(list, "list");
		return list.IndexOf(item, 0, list.Count, equalityComparer);
	}
}
[CollectionBuilder(typeof(ImmutableList), "Create")]
[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
public sealed class ImmutableList<T> : IImmutableList<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IList<T>, ICollection<T>, IList, ICollection, IStrongEnumerable<T, ImmutableList<T>.Enumerator>
{
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableListBuilderDebuggerProxy<>))]
	public sealed class Builder : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		private Node _root = Node.EmptyNode;

		private ImmutableList<T> _immutable;

		private int _version;

		public int Count => Root.Count;

		bool ICollection<T>.IsReadOnly => false;

		internal int Version => _version;

		internal Node Root
		{
			get
			{
				return _root;
			}
			private set
			{
				_version++;
				if (_root != value)
				{
					_root = value;
					_immutable = null;
				}
			}
		}

		public T this[int index]
		{
			get
			{
				return Root.ItemRef(index);
			}
			set
			{
				Root = Root.ReplaceAt(index, value);
			}
		}

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		object? IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (T)value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized => false;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot => _003CSystem_002ECollections_002EICollection_002ESyncRoot_003Ek__BackingField ?? Interlocked.CompareExchange(ref _003CSystem_002ECollections_002EICollection_002ESyncRoot_003Ek__BackingField, new object(), null) ?? _003CSystem_002ECollections_002EICollection_002ESyncRoot_003Ek__BackingField;

		internal Builder(ImmutableList<T> list)
		{
			Requires.NotNull(list, "list");
			_root = list._root;
			_immutable = list;
		}

		public int IndexOf(T item)
		{
			return Root.IndexOf(item, EqualityComparer<T>.Default);
		}

		public void Insert(int index, T item)
		{
			Root = Root.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			Root = Root.RemoveAt(index);
		}

		public void Add(T item)
		{
			Root = Root.Add(item);
		}

		public void Clear()
		{
			Root = Node.EmptyNode;
		}

		public bool Contains(T item)
		{
			return IndexOf(item) >= 0;
		}

		public bool Remove(T item)
		{
			int num = IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			Root = Root.RemoveAt(num);
			return true;
		}

		public ImmutableList<T>.Enumerator GetEnumerator()
		{
			return Root.GetEnumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_root.CopyTo(array, arrayIndex);
		}

		public void AddRange(IEnumerable<T> items)
		{
			Requires.NotNull(items, "items");
			Root = Root.AddRange(items);
		}

		public ImmutableList<T> ToImmutable()
		{
			return _immutable ?? (_immutable = ImmutableList<T>.WrapNode(Root));
		}

		int IList.Add(object value)
		{
			Add((T)value);
			return Count - 1;
		}

		void IList.Clear()
		{
			Clear();
		}

		bool IList.Contains(object value)
		{
			if (ImmutableList<T>.IsCompatibleObject(value))
			{
				return Contains((T)value);
			}
			return false;
		}

		int IList.IndexOf(object value)
		{
			if (ImmutableList<T>.IsCompatibleObject(value))
			{
				return IndexOf((T)value);
			}
			return -1;
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, (T)value);
		}

		void IList.Remove(object value)
		{
			if (ImmutableList<T>.IsCompatibleObject(value))
			{
				Remove((T)value);
			}
		}

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			Root.CopyTo(array, arrayIndex);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable, ISecurePooledObjectUser, IStrongEnumerator<T>
	{
		private readonly Builder _builder;

		private readonly int _poolUserId;

		private readonly int _startIndex;

		private readonly int _count;

		private int _remainingCount;

		private readonly bool _reversed;

		private Node _root;

		private SecurePooledObject<Stack<RefAsValueType<Node>>> _stack;

		private Node _current;

		private int _enumeratingBuilderVersion;

		int ISecurePooledObjectUser.PoolUserId => _poolUserId;

		public T Current
		{
			get
			{
				ThrowIfDisposed();
				if (_current != null)
				{
					return _current.Value;
				}
				throw new InvalidOperationException();
			}
		}

		object? IEnumerator.Current => Current;

		internal Enumerator(Node root, Builder builder = null, int startIndex = -1, int count = -1, bool reversed = false)
		{
			Requires.NotNull(root, "root");
			Requires.Range(startIndex >= -1, "startIndex");
			Requires.Range(count >= -1, "count");
			Requires.Argument(reversed || count == -1 || ((startIndex != -1) ? startIndex : 0) + count <= root.Count);
			Requires.Argument(!reversed || count == -1 || ((startIndex == -1) ? (root.Count - 1) : startIndex) - count + 1 >= 0);
			_root = root;
			_builder = builder;
			_current = null;
			_startIndex = ((startIndex >= 0) ? startIndex : (reversed ? (root.Count - 1) : 0));
			_count = ((count == -1) ? root.Count : count);
			_remainingCount = _count;
			_reversed = reversed;
			_enumeratingBuilderVersion = builder?.Version ?? (-1);
			_poolUserId = SecureObjectPool.NewId();
			_stack = null;
			if (_count > 0)
			{
				if (!SecureObjectPool<Stack<RefAsValueType<Node>>, Enumerator>.TryTake(this, out _stack))
				{
					_stack = SecureObjectPool<Stack<RefAsValueType<Node>>, Enumerator>.PrepNew(this, new Stack<RefAsValueType<Node>>(root.Height));
				}
				ResetStack();
			}
		}

		public void Dispose()
		{
			_root = null;
			_current = null;
			if (_stack != null && _stack.TryUse(ref this, out var value))
			{
				value.ClearFastWhenEmpty();
				SecureObjectPool<Stack<RefAsValueType<Node>>, Enumerator>.TryAdd(this, _stack);
			}
			_stack = null;
		}

		public bool MoveNext()
		{
			ThrowIfDisposed();
			ThrowIfChanged();
			if (_stack != null)
			{
				Stack<RefAsValueType<Node>> stack = _stack.Use(ref this);
				if (_remainingCount > 0 && stack.Count > 0)
				{
					PushNext(NextBranch(_current = stack.Pop().Value));
					_remainingCount--;
					return true;
				}
			}
			_current = null;
			return false;
		}

		public void Reset()
		{
			ThrowIfDisposed();
			_enumeratingBuilderVersion = ((_builder != null) ? _builder.Version : (-1));
			_remainingCount = _count;
			if (_stack != null)
			{
				ResetStack();
			}
		}

		private void ResetStack()
		{
			Stack<RefAsValueType<Node>> stack = _stack.Use(ref this);
			stack.ClearFastWhenEmpty();
			Node node = _root;
			int num = (_reversed ? (_root.Count - _startIndex - 1) : _startIndex);
			while (!node.IsEmpty && num != PreviousBranch(node).Count)
			{
				if (num < PreviousBranch(node).Count)
				{
					stack.Push(new RefAsValueType<Node>(node));
					node = PreviousBranch(node);
				}
				else
				{
					num -= PreviousBranch(node).Count + 1;
					node = NextBranch(node);
				}
			}
			if (!node.IsEmpty)
			{
				stack.Push(new RefAsValueType<Node>(node));
			}
		}

		private Node NextBranch(Node node)
		{
			if (!_reversed)
			{
				return node.Right;
			}
			return node.Left;
		}

		private Node PreviousBranch(Node node)
		{
			if (!_reversed)
			{
				return node.Left;
			}
			return node.Right;
		}

		private void ThrowIfDisposed()
		{
			if (_root == null || (_stack != null && !_stack.IsOwned(ref this)))
			{
				Requires.FailObjectDisposed(this);
			}
		}

		private void ThrowIfChanged()
		{
			if (_builder != null && _builder.Version != _enumeratingBuilderVersion)
			{
				throw new InvalidOperationException("CollectionModifiedDuringEnumeration");
			}
		}

		private void PushNext(Node node)
		{
			Requires.NotNull(node, "node");
			if (!node.IsEmpty)
			{
				Stack<RefAsValueType<Node>> stack = _stack.Use(ref this);
				while (!node.IsEmpty)
				{
					stack.Push(new RefAsValueType<Node>(node));
					node = PreviousBranch(node);
				}
			}
		}
	}

	[DefaultMember("Item")]
	[DebuggerDisplay("{_key}")]
	internal sealed class Node : IEnumerable<T>, IEnumerable
	{
		internal static readonly Node EmptyNode = new Node();

		private T _key;

		private bool _frozen;

		private byte _height;

		private int _count;

		private Node _left;

		private Node _right;

		public bool IsEmpty => _left == null;

		public int Height => _height;

		public Node Left => _left;

		public Node Right => _right;

		public T Value => _key;

		public int Count => _count;

		internal T Key => _key;

		private int BalanceFactor => _right._height - _left._height;

		private bool IsRightHeavy => BalanceFactor >= 2;

		private bool IsLeftHeavy => BalanceFactor <= -2;

		private bool IsBalanced => (uint)(BalanceFactor + 1) <= 2u;

		private Node()
		{
			_frozen = true;
		}

		private Node(T key, Node left, Node right, bool frozen = false)
		{
			Requires.NotNull(left, "left");
			Requires.NotNull(right, "right");
			_key = key;
			_left = left;
			_right = right;
			_height = ParentHeight(left, right);
			_count = ParentCount(left, right);
			_frozen = frozen;
		}

		internal ref readonly T ItemRef(int index)
		{
			Requires.Range(index >= 0 && index < Count, "index");
			return ref ItemRefUnchecked(index);
		}

		private ref readonly T ItemRefUnchecked(int index)
		{
			if (index < _left._count)
			{
				return ref _left.ItemRefUnchecked(index);
			}
			if (index > _left._count)
			{
				return ref _right.ItemRefUnchecked(index - _left._count - 1);
			}
			return ref _key;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		[ExcludeFromCodeCoverage]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal Enumerator GetEnumerator(Builder builder)
		{
			return new Enumerator(this, builder);
		}

		internal static Node NodeTreeFromList(IReadOnlyList<T> items, int start, int length)
		{
			Requires.NotNull(items, "items");
			Requires.Range(start >= 0, "start");
			Requires.Range(length >= 0, "length");
			if (length == 0)
			{
				return EmptyNode;
			}
			int num = (length - 1) / 2;
			int num2 = length - 1 - num;
			Node left = NodeTreeFromList(items, start, num2);
			Node right = NodeTreeFromList(items, start + num2 + 1, num);
			return new Node(items[start + num2], left, right, frozen: true);
		}

		internal static Node NodeTreeFromList(ReadOnlySpan<T> items)
		{
			if (items.IsEmpty)
			{
				return EmptyNode;
			}
			int num = (items.Length - 1) / 2;
			int num2 = items.Length - 1 - num;
			Node left = NodeTreeFromList(items.Slice(0, num2));
			Node right = NodeTreeFromList(items.Slice(num2 + 1));
			return new Node(items[num2], left, right, frozen: true);
		}

		internal Node Add(T key)
		{
			if (IsEmpty)
			{
				return CreateLeaf(key);
			}
			Node right = _right.Add(key);
			Node node = MutateRight(right);
			if (!node.IsBalanced)
			{
				return node.BalanceRight();
			}
			return node;
		}

		internal Node Insert(int index, T key)
		{
			Requires.Range(index >= 0 && index <= Count, "index");
			if (IsEmpty)
			{
				return CreateLeaf(key);
			}
			if (index <= _left._count)
			{
				Node left = _left.Insert(index, key);
				Node node = MutateLeft(left);
				if (!node.IsBalanced)
				{
					return node.BalanceLeft();
				}
				return node;
			}
			Node right = _right.Insert(index - _left._count - 1, key);
			Node node2 = MutateRight(right);
			if (!node2.IsBalanced)
			{
				return node2.BalanceRight();
			}
			return node2;
		}

		internal Node AddRange(IEnumerable<T> keys)
		{
			Requires.NotNull(keys, "keys");
			if (IsEmpty)
			{
				return CreateRange(keys);
			}
			Node right = _right.AddRange(keys);
			return MutateRight(right).BalanceMany();
		}

		internal Node AddRange(ReadOnlySpan<T> keys)
		{
			if (IsEmpty)
			{
				return NodeTreeFromList(keys);
			}
			Node right = _right.AddRange(keys);
			return MutateRight(right).BalanceMany();
		}

		internal Node RemoveAt(int index)
		{
			Requires.Range(index >= 0 && index < Count, "index");
			Node node;
			if (index == _left._count)
			{
				if (_right.IsEmpty && _left.IsEmpty)
				{
					node = EmptyNode;
				}
				else if (_right.IsEmpty && !_left.IsEmpty)
				{
					node = _left;
				}
				else if (!_right.IsEmpty && _left.IsEmpty)
				{
					node = _right;
				}
				else
				{
					Node node2 = _right;
					while (!node2._left.IsEmpty)
					{
						node2 = node2._left;
					}
					Node right = _right.RemoveAt(0);
					node = node2.MutateBoth(_left, right);
				}
			}
			else if (index < _left._count)
			{
				Node left = _left.RemoveAt(index);
				node = MutateLeft(left);
			}
			else
			{
				Node right2 = _right.RemoveAt(index - _left._count - 1);
				node = MutateRight(right2);
			}
			if (!node.IsEmpty && !node.IsBalanced)
			{
				return node.Balance();
			}
			return node;
		}

		internal Node ReplaceAt(int index, T value)
		{
			Requires.Range(index >= 0 && index < Count, "index");
			if (index == _left._count)
			{
				return MutateKey(value);
			}
			if (index < _left._count)
			{
				Node left = _left.ReplaceAt(index, value);
				return MutateLeft(left);
			}
			Node right = _right.ReplaceAt(index - _left._count - 1, value);
			return MutateRight(right);
		}

		internal int IndexOf(T item, IEqualityComparer<T> equalityComparer)
		{
			return IndexOf(item, 0, Count, equalityComparer);
		}

		internal bool Contains(T item, IEqualityComparer<T> equalityComparer)
		{
			return Contains(this, item, equalityComparer);
		}

		internal int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
		{
			Requires.Range(index >= 0, "index");
			Requires.Range(count >= 0, "count");
			Requires.Range(count <= Count, "count");
			Requires.Range(index + count <= Count, "count");
			if (equalityComparer == null)
			{
				equalityComparer = EqualityComparer<T>.Default;
			}
			using (Enumerator enumerator = new Enumerator(this, null, index, count))
			{
				while (enumerator.MoveNext())
				{
					if (equalityComparer.Equals(item, enumerator.Current))
					{
						return index;
					}
					index++;
				}
			}
			return -1;
		}

		internal void CopyTo(T[] array, int arrayIndex)
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

		internal void CopyTo(Array array, int arrayIndex)
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

		internal void Freeze()
		{
			if (!_frozen)
			{
				_left.Freeze();
				_right.Freeze();
				_frozen = true;
			}
		}

		private Node RotateLeft()
		{
			return _right.MutateLeft(MutateRight(_right._left));
		}

		private Node RotateRight()
		{
			return _left.MutateRight(MutateLeft(_left._right));
		}

		private Node DoubleLeft()
		{
			Node right = _right;
			Node left = right._left;
			return left.MutateBoth(MutateRight(left._left), right.MutateLeft(left._right));
		}

		private Node DoubleRight()
		{
			Node left = _left;
			Node right = left._right;
			return right.MutateBoth(left.MutateRight(right._left), MutateLeft(right._right));
		}

		private Node Balance()
		{
			if (!IsLeftHeavy)
			{
				return BalanceRight();
			}
			return BalanceLeft();
		}

		private Node BalanceLeft()
		{
			if (_left.BalanceFactor <= 0)
			{
				return RotateRight();
			}
			return DoubleRight();
		}

		private Node BalanceRight()
		{
			if (_right.BalanceFactor >= 0)
			{
				return RotateLeft();
			}
			return DoubleLeft();
		}

		private Node BalanceMany()
		{
			Node node = this;
			while (!node.IsBalanced)
			{
				if (node.IsRightHeavy)
				{
					node = node.BalanceRight();
					node.MutateLeft(node._left.BalanceMany());
				}
				else
				{
					node = node.BalanceLeft();
					node.MutateRight(node._right.BalanceMany());
				}
			}
			return node;
		}

		private Node MutateBoth(Node left, Node right)
		{
			Requires.NotNull(left, "left");
			Requires.NotNull(right, "right");
			if (_frozen)
			{
				return new Node(_key, left, right);
			}
			_left = left;
			_right = right;
			_height = ParentHeight(left, right);
			_count = ParentCount(left, right);
			return this;
		}

		private Node MutateLeft(Node left)
		{
			Requires.NotNull(left, "left");
			if (_frozen)
			{
				return new Node(_key, left, _right);
			}
			_left = left;
			_height = ParentHeight(left, _right);
			_count = ParentCount(left, _right);
			return this;
		}

		private Node MutateRight(Node right)
		{
			Requires.NotNull(right, "right");
			if (_frozen)
			{
				return new Node(_key, _left, right);
			}
			_right = right;
			_height = ParentHeight(_left, right);
			_count = ParentCount(_left, right);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static byte ParentHeight(Node left, Node right)
		{
			return checked((byte)(1 + Math.Max(left._height, right._height)));
		}

		private static int ParentCount(Node left, Node right)
		{
			return 1 + left._count + right._count;
		}

		private Node MutateKey(T key)
		{
			if (_frozen)
			{
				return new Node(key, _left, _right);
			}
			_key = key;
			return this;
		}

		private static Node CreateRange(IEnumerable<T> keys)
		{
			if (ImmutableList<T>.TryCastToImmutableList(keys, out ImmutableList<T> other))
			{
				return other._root;
			}
			IReadOnlyList<T> readOnlyList = keys.AsReadOnlyList();
			return NodeTreeFromList(readOnlyList, 0, readOnlyList.Count);
		}

		private static Node CreateLeaf(T key)
		{
			return new Node(key, EmptyNode, EmptyNode);
		}

		private static bool Contains(Node node, T value, IEqualityComparer<T> equalityComparer)
		{
			if (!node.IsEmpty)
			{
				if (!equalityComparer.Equals(value, node._key) && !Contains(node._left, value, equalityComparer))
				{
					return Contains(node._right, value, equalityComparer);
				}
				return true;
			}
			return false;
		}
	}

	public static readonly ImmutableList<T> Empty = new ImmutableList<T>();

	private readonly Node _root;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool IsEmpty => _root.IsEmpty;

	public int Count => _root.Count;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	object ICollection.SyncRoot => this;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool ICollection.IsSynchronized => true;

	public T this[int index] => _root.ItemRef(index);

	T IList<T>.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	bool ICollection<T>.IsReadOnly => true;

	bool IList.IsFixedSize => true;

	bool IList.IsReadOnly => true;

	object? IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	internal ImmutableList()
	{
		_root = Node.EmptyNode;
	}

	private ImmutableList(Node root)
	{
		Requires.NotNull(root, "root");
		root.Freeze();
		_root = root;
	}

	public ImmutableList<T> Clear()
	{
		return Empty;
	}

	public Builder ToBuilder()
	{
		return new Builder(this);
	}

	public ImmutableList<T> AddRange(IEnumerable<T> items)
	{
		Requires.NotNull(items, "items");
		if (IsEmpty)
		{
			return CreateRange(items);
		}
		Node root = _root.AddRange(items);
		return Wrap(root);
	}

	internal ImmutableList<T> AddRange(ReadOnlySpan<T> items)
	{
		if (IsEmpty)
		{
			if (items.IsEmpty)
			{
				return Empty;
			}
			return new ImmutableList<T>(Node.NodeTreeFromList(items));
		}
		if (items.IsEmpty)
		{
			return this;
		}
		return Wrap(_root.AddRange(items));
	}

	public void ForEach(Action<T> action)
	{
		Requires.NotNull(action, "action");
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			action(current);
		}
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_root.CopyTo(array, arrayIndex);
	}

	public int IndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer)
	{
		return _root.IndexOf(item, index, count, equalityComparer);
	}

	public bool Contains(T value)
	{
		return _root.Contains(value, EqualityComparer<T>.Default);
	}

	public int IndexOf(T value)
	{
		return this.IndexOf(value, EqualityComparer<T>.Default);
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

	void ICollection.CopyTo(Array array, int arrayIndex)
	{
		_root.CopyTo(array, arrayIndex);
	}

	int IList.Add(object value)
	{
		throw new NotSupportedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	bool IList.Contains(object value)
	{
		if (IsCompatibleObject(value))
		{
			return Contains((T)value);
		}
		return false;
	}

	int IList.IndexOf(object value)
	{
		if (!IsCompatibleObject(value))
		{
			return -1;
		}
		return IndexOf((T)value);
	}

	void IList.Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object value)
	{
		throw new NotSupportedException();
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(_root);
	}

	private static ImmutableList<T> WrapNode(Node root)
	{
		if (!root.IsEmpty)
		{
			return new ImmutableList<T>(root);
		}
		return Empty;
	}

	private static bool TryCastToImmutableList(IEnumerable<T> sequence, [NotNullWhen(true)] out ImmutableList<T> other)
	{
		other = sequence as ImmutableList<T>;
		if (other != null)
		{
			return true;
		}
		if (sequence is Builder builder)
		{
			other = builder.ToImmutable();
			return true;
		}
		return false;
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

	private ImmutableList<T> Wrap(Node root)
	{
		if (root != _root)
		{
			if (!root.IsEmpty)
			{
				return new ImmutableList<T>(root);
			}
			return Clear();
		}
		return this;
	}

	private static ImmutableList<T> CreateRange(IEnumerable<T> items)
	{
		if (TryCastToImmutableList(items, out var other))
		{
			return other;
		}
		IReadOnlyList<T> readOnlyList = items.AsReadOnlyList();
		if (readOnlyList.Count == 0)
		{
			return Empty;
		}
		return new ImmutableList<T>(Node.NodeTreeFromList(readOnlyList, 0, readOnlyList.Count));
	}
}
