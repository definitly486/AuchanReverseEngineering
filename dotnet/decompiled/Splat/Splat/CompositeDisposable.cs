using System;
using System.Collections.Generic;
using System.Threading;

namespace Splat;

internal sealed class CompositeDisposable : IDisposable
{
	private const int DefaultCapacity = 16;

	private bool _disposed;

	private List<IDisposable>? _disposables;

	private int _count;

	public CompositeDisposable()
	{
		_disposables = new List<IDisposable>();
	}

	public CompositeDisposable(int capacity)
	{
		capacity.ThrowArgumentNullExceptionIfNull("capacity");
		_disposables = new List<IDisposable>(capacity);
	}

	public CompositeDisposable(params IDisposable[] disposables)
	{
		disposables.ThrowArgumentNullExceptionIfNull("disposables");
		_disposables = new List<IDisposable>(disposables.Length);
		Init(disposables);
	}

	public CompositeDisposable(IEnumerable<IDisposable> disposables)
	{
		if (disposables != null)
		{
			if (disposables is ICollection<IDisposable> collection)
			{
				_disposables = new List<IDisposable>(collection.Count);
				Init(disposables);
			}
			else
			{
				_disposables = new List<IDisposable>(16);
				Init(disposables);
			}
			return;
		}
		throw new ArgumentNullException("disposables");
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		List<IDisposable> list = Interlocked.Exchange(ref _disposables, null);
		if (list != null)
		{
			foreach (IDisposable item in list)
			{
				item.Dispose();
			}
		}
		Volatile.Write(ref _count, 0);
		Volatile.Write(ref _disposed, value: true);
	}

	private void Init(IEnumerable<IDisposable> disposables)
	{
		if (_disposables == null)
		{
			return;
		}
		foreach (IDisposable disposable in disposables)
		{
			if (disposable == null)
			{
				throw new ArgumentException("disposables for some reason are null", "disposables");
			}
			_disposables.Add(disposable);
		}
		Volatile.Write(ref _count, _disposables.Count);
	}
}
