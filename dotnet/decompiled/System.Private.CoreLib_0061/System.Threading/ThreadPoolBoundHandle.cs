using System.Runtime.InteropServices;

namespace System.Threading;

public sealed class ThreadPoolBoundHandle : IDisposable
{
	private readonly SafeHandle _handle;

	private bool _isDisposed;

	public SafeHandle Handle => _handle;

	private unsafe NativeOverlapped* AllocateNativeOverlappedPortableCore(IOCompletionCallback callback, object state, object pinData)
	{
		return AllocateNativeOverlappedPortableCore(callback, state, pinData, flowExecutionContext: true);
	}

	private unsafe NativeOverlapped* UnsafeAllocateNativeOverlappedPortableCore(IOCompletionCallback callback, object state, object pinData)
	{
		return AllocateNativeOverlappedPortableCore(callback, state, pinData, flowExecutionContext: false);
	}

	private unsafe NativeOverlapped* AllocateNativeOverlappedPortableCore(IOCompletionCallback callback, object state, object pinData, bool flowExecutionContext)
	{
		ArgumentNullException.ThrowIfNull(callback, "callback");
		ObjectDisposedException.ThrowIf(_isDisposed, this);
		return new ThreadPoolBoundHandleOverlapped(callback, state, pinData, null, flowExecutionContext)
		{
			_boundHandle = this
		}._nativeOverlapped;
	}

	private unsafe NativeOverlapped* AllocateNativeOverlappedPortableCore(PreAllocatedOverlapped preAllocated)
	{
		ArgumentNullException.ThrowIfNull(preAllocated, "preAllocated");
		ObjectDisposedException.ThrowIf(_isDisposed, this);
		preAllocated.AddRef();
		try
		{
			ThreadPoolBoundHandleOverlapped overlappedPortableCore = preAllocated._overlappedPortableCore;
			if (overlappedPortableCore._boundHandle != null)
			{
				throw new ArgumentException("Argument_PreAllocatedAlreadyAllocated", "preAllocated");
			}
			overlappedPortableCore._boundHandle = this;
			return overlappedPortableCore._nativeOverlapped;
		}
		catch
		{
			preAllocated.Release();
			throw;
		}
	}

	private unsafe void FreeNativeOverlappedPortableCore(NativeOverlapped* overlapped)
	{
		ArgumentNullException.ThrowIfNull(overlapped, "overlapped");
		ThreadPoolBoundHandleOverlapped overlappedWrapper = GetOverlappedWrapper(overlapped);
		if (overlappedWrapper._boundHandle != this)
		{
			throw new ArgumentException("Argument_NativeOverlappedWrongBoundHandle", "overlapped");
		}
		if (overlappedWrapper._preAllocated != null)
		{
			overlappedWrapper._preAllocated.Release();
		}
		else
		{
			Overlapped.Free(overlapped);
		}
	}

	private unsafe static object GetNativeOverlappedStatePortableCore(NativeOverlapped* overlapped)
	{
		ArgumentNullException.ThrowIfNull(overlapped, "overlapped");
		return GetOverlappedWrapper(overlapped)._userState;
	}

	private unsafe static ThreadPoolBoundHandleOverlapped GetOverlappedWrapper(NativeOverlapped* overlapped)
	{
		try
		{
			return (ThreadPoolBoundHandleOverlapped)Overlapped.Unpack(overlapped);
		}
		catch (NullReferenceException innerException)
		{
			throw new ArgumentException("Argument_NativeOverlappedAlreadyFree", "overlapped", innerException);
		}
	}

	private void DisposePortableCore()
	{
		_isDisposed = true;
	}

	private ThreadPoolBoundHandle(SafeHandle handle)
	{
		_handle = handle;
	}

	public static ThreadPoolBoundHandle BindHandle(SafeHandle handle)
	{
		ArgumentNullException.ThrowIfNull(handle, "handle");
		if (handle.IsClosed || handle.IsInvalid)
		{
			throw new ArgumentException("Argument_InvalidHandle", "handle");
		}
		throw new PlatformNotSupportedException("PlatformNotSupported_OverlappedIO");
	}

	[CLSCompliant(false)]
	public unsafe NativeOverlapped* AllocateNativeOverlapped(IOCompletionCallback callback, object? state, object? pinData)
	{
		return AllocateNativeOverlappedPortableCore(callback, state, pinData);
	}

	[CLSCompliant(false)]
	public unsafe NativeOverlapped* UnsafeAllocateNativeOverlapped(IOCompletionCallback callback, object? state, object? pinData)
	{
		return UnsafeAllocateNativeOverlappedPortableCore(callback, state, pinData);
	}

	[CLSCompliant(false)]
	public unsafe NativeOverlapped* AllocateNativeOverlapped(PreAllocatedOverlapped preAllocated)
	{
		return AllocateNativeOverlappedPortableCore(preAllocated);
	}

	[CLSCompliant(false)]
	public unsafe void FreeNativeOverlapped(NativeOverlapped* overlapped)
	{
		FreeNativeOverlappedPortableCore(overlapped);
	}

	[CLSCompliant(false)]
	public unsafe static object? GetNativeOverlappedState(NativeOverlapped* overlapped)
	{
		return GetNativeOverlappedStatePortableCore(overlapped);
	}

	public void Dispose()
	{
		DisposePortableCore();
	}
}
