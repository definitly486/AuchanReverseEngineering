using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections;

[Serializable]
[DebuggerTypeProxy(typeof(StackDebugView))]
[DebuggerDisplay("Count = {Count}")]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class Stack : ICollection, IEnumerable, ICloneable
{
	private sealed class StackEnumerator : IEnumerator, ICloneable
	{
		private readonly Stack _stack;

		private int _index;

		private readonly int _version;

		private object _currentElement;

		public object Current
		{
			get
			{
				if (_index == -2)
				{
					throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
				}
				if (_index == -1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumEnded");
				}
				return _currentElement;
			}
		}

		internal StackEnumerator(Stack stack)
		{
			_stack = stack;
			_version = _stack._version;
			_index = -2;
			_currentElement = null;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public bool MoveNext()
		{
			if (_version != _stack._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			if (_index == -2)
			{
				_index = _stack._size - 1;
				bool num = _index >= 0;
				if (num)
				{
					_currentElement = _stack._array[_index];
				}
				return num;
			}
			if (_index == -1)
			{
				return false;
			}
			bool num2 = --_index >= 0;
			if (num2)
			{
				_currentElement = _stack._array[_index];
				return num2;
			}
			_currentElement = null;
			return num2;
		}

		public void Reset()
		{
			if (_version != _stack._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			_index = -2;
			_currentElement = null;
		}
	}

	internal sealed class StackDebugView
	{
		private readonly Stack _stack;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public object[] Items => _stack.ToArray();

		public StackDebugView(Stack stack)
		{
			ArgumentNullException.ThrowIfNull(stack, "stack");
			_stack = stack;
		}
	}

	private object[] _array;

	private int _size;

	private int _version;

	public virtual int Count => _size;

	public virtual bool IsSynchronized => false;

	public virtual object SyncRoot => this;

	public Stack()
	{
		_array = new object[10];
		_size = 0;
		_version = 0;
	}

	public Stack(int initialCapacity)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(initialCapacity, "initialCapacity");
		if (initialCapacity < 10)
		{
			initialCapacity = 10;
		}
		_array = new object[initialCapacity];
		_size = 0;
		_version = 0;
	}

	public virtual object Clone()
	{
		Stack stack = new Stack(_size);
		stack._size = _size;
		Array.Copy(_array, stack._array, _size);
		stack._version = _version;
		return stack;
	}

	public virtual void CopyTo(Array array, int index)
	{
		ArgumentNullException.ThrowIfNull(array, "array");
		if (array.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported", "array");
		}
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		if (array.Length - index < _size)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		int i = 0;
		if (array is object[] array2)
		{
			for (; i < _size; i++)
			{
				array2[i + index] = _array[_size - i - 1];
			}
		}
		else
		{
			for (; i < _size; i++)
			{
				array.SetValue(_array[_size - i - 1], i + index);
			}
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		return new StackEnumerator(this);
	}

	public virtual object?[] ToArray()
	{
		if (_size == 0)
		{
			return Array.Empty<object>();
		}
		object[] array = new object[_size];
		for (int i = 0; i < _size; i++)
		{
			array[i] = _array[_size - i - 1];
		}
		return array;
	}
}
