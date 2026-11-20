using System.Threading;

namespace System.Reactive.Disposables;

public abstract class StableCompositeDisposable : ICancelable, IDisposable
{
	private sealed class Binary : StableCompositeDisposable
	{
		private SingleAssignmentDisposableValue _disposable1;

		private SingleAssignmentDisposableValue _disposable2;

		public override bool IsDisposed => _disposable1.IsDisposed;

		public Binary(IDisposable disposable1, IDisposable disposable2)
		{
			_disposable1.Disposable = disposable1;
			_disposable2.Disposable = disposable2;
		}

		public override void Dispose()
		{
			_disposable1.Dispose();
			_disposable2.Dispose();
		}
	}

	private sealed class NAryTrustedArray : StableCompositeDisposable
	{
		private IDisposable[]? _disposables;

		public override bool IsDisposed => Volatile.Read(in _disposables) == null;

		public NAryTrustedArray(IDisposable[] disposables)
		{
			Volatile.Write(ref _disposables, disposables);
		}

		public override void Dispose()
		{
			IDisposable[] array = Interlocked.Exchange(ref _disposables, null);
			if (array != null)
			{
				IDisposable[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Dispose();
				}
			}
		}
	}

	public abstract bool IsDisposed { get; }

	public static ICancelable Create(IDisposable disposable1, IDisposable disposable2)
	{
		if (disposable1 == null)
		{
			throw new ArgumentNullException("disposable1");
		}
		if (disposable2 == null)
		{
			throw new ArgumentNullException("disposable2");
		}
		return new Binary(disposable1, disposable2);
	}

	internal static ICancelable CreateTrusted(params IDisposable[] disposables)
	{
		return new NAryTrustedArray(disposables);
	}

	public abstract void Dispose();
}
