namespace System.Threading;

public sealed class PreAllocatedOverlapped : IDisposable, IDeferredDisposable
{
	private DeferredDisposableLifetime<PreAllocatedOverlapped> _lifetime;

	internal ThreadPoolBoundHandleOverlapped _overlappedPortableCore;

	[CLSCompliant(false)]
	public PreAllocatedOverlapped(IOCompletionCallback callback, object? state, object? pinData)
		: this(callback, state, pinData, flowExecutionContext: true)
	{
	}

	[CLSCompliant(false)]
	public static PreAllocatedOverlapped UnsafeCreate(IOCompletionCallback callback, object? state, object? pinData)
	{
		return UnsafeCreatePortableCore(callback, state, pinData);
	}

	private PreAllocatedOverlapped(IOCompletionCallback callback, object state, object pinData, bool flowExecutionContext)
	{
		ArgumentNullException.ThrowIfNull(callback, "callback");
		_overlappedPortableCore = new ThreadPoolBoundHandleOverlapped(callback, state, pinData, this, flowExecutionContext);
	}

	internal bool AddRef()
	{
		return AddRefPortableCore();
	}

	public void Dispose()
	{
		DisposePortableCore();
	}

	internal void Release()
	{
		ReleasePortableCore();
	}

	void IDeferredDisposable.OnFinalRelease(bool disposed)
	{
		IDeferredDisposableOnFinalReleasePortableCore(disposed);
	}

	private static PreAllocatedOverlapped UnsafeCreatePortableCore(IOCompletionCallback callback, object state, object pinData)
	{
		return new PreAllocatedOverlapped(callback, state, pinData, flowExecutionContext: false);
	}

	private bool AddRefPortableCore()
	{
		return _lifetime.AddRef();
	}

	private void ReleasePortableCore()
	{
		_lifetime.Release(this);
	}

	private void DisposePortableCore()
	{
		_lifetime.Dispose(this);
		GC.SuppressFinalize(this);
	}

	private unsafe void IDeferredDisposableOnFinalReleasePortableCore(bool disposed)
	{
		if (_overlappedPortableCore != null)
		{
			if (disposed)
			{
				Overlapped.Free(_overlappedPortableCore._nativeOverlapped);
				return;
			}
			_overlappedPortableCore._boundHandle = null;
			_overlappedPortableCore._completed = false;
			*_overlappedPortableCore._nativeOverlapped = default(NativeOverlapped);
		}
	}
}
