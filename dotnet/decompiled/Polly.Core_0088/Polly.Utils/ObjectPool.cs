using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Polly.Utils;

internal sealed class ObjectPool<T> where T : class
{
	internal static readonly int MaxCapacity = Environment.ProcessorCount * 2 - 1;

	private readonly Func<T> _createFunc;

	private readonly Func<T, bool> _returnFunc;

	private readonly ConcurrentQueue<T> _items = new ConcurrentQueue<T>();

	private T? _fastItem;

	private int _numItems;

	public ObjectPool(Func<T> createFunc, Func<T, bool> returnFunc)
	{
		_createFunc = createFunc;
		_returnFunc = returnFunc;
	}

	public T Get()
	{
		T result = _fastItem;
		if (result == null || Interlocked.CompareExchange(ref _fastItem, null, result) != result)
		{
			if (_items.TryDequeue(out result))
			{
				Interlocked.Decrement(ref _numItems);
				return result;
			}
			return _createFunc();
		}
		return result;
	}

	public void Return(T obj)
	{
		if (_returnFunc(obj) && (_fastItem != null || Interlocked.CompareExchange(ref _fastItem, obj, null) != null))
		{
			if (Interlocked.Increment(ref _numItems) <= MaxCapacity)
			{
				_items.Enqueue(obj);
			}
			else
			{
				Interlocked.Decrement(ref _numItems);
			}
		}
	}
}
