using System.Threading;

namespace System.Reactive.Disposables;

internal struct SerialDisposableValue : ICancelable, IDisposable
{
	private IDisposable? _current;

	public bool IsDisposed => Volatile.Read(in _current) == BooleanDisposable.True;

	public IDisposable? Disposable
	{
		set
		{
			System.Reactive.Disposables.Disposable.TrySetSerial(ref _current, value);
		}
	}

	public bool TrySetFirst(IDisposable disposable)
	{
		return System.Reactive.Disposables.Disposable.TrySetSingle(ref _current, disposable) == TrySetSingleResult.Success;
	}

	public void Dispose()
	{
		System.Reactive.Disposables.Disposable.Dispose(ref _current);
	}
}
