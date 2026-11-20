using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Versioning;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

public sealed class Semaphore : WaitHandle
{
	public Semaphore(int initialCount, int maximumCount)
	{
		CreateSemaphoreCore(initialCount, maximumCount);
	}

	public Semaphore(int initialCount, int maximumCount, string? name, NamedWaitHandleOptions options)
	{
		CreateSemaphoreCore(initialCount, maximumCount, name, new NamedWaitHandleOptionsInternal(options), out var _);
	}

	public Semaphore(int initialCount, int maximumCount, string? name)
	{
		CreateSemaphoreCore(initialCount, maximumCount, name, default(NamedWaitHandleOptionsInternal), out var _);
	}

	public Semaphore(int initialCount, int maximumCount, string? name, NamedWaitHandleOptions options, out bool createdNew)
	{
		CreateSemaphoreCore(initialCount, maximumCount, name, new NamedWaitHandleOptionsInternal(options), out createdNew);
	}

	public Semaphore(int initialCount, int maximumCount, string? name, out bool createdNew)
	{
		CreateSemaphoreCore(initialCount, maximumCount, name, default(NamedWaitHandleOptionsInternal), out createdNew);
	}

	private static void ValidateArguments(int initialCount, int maximumCount)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(initialCount, "initialCount");
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maximumCount, "maximumCount");
		if (initialCount > maximumCount)
		{
			throw new ArgumentException("Argument_SemaphoreInitialMaximum");
		}
	}

	[SupportedOSPlatform("windows")]
	public static Semaphore OpenExisting(string name, NamedWaitHandleOptions options)
	{
		Semaphore result;
		OpenExistingResult openExistingResult = OpenExistingWorker(name, new NamedWaitHandleOptionsInternal(options), out result);
		if (openExistingResult != OpenExistingResult.Success)
		{
			ThrowForOpenExistingFailure(openExistingResult, name);
		}
		return result;
	}

	[SupportedOSPlatform("windows")]
	public static Semaphore OpenExisting(string name)
	{
		Semaphore result;
		OpenExistingResult openExistingResult = OpenExistingWorker(name, default(NamedWaitHandleOptionsInternal), out result);
		if (openExistingResult != OpenExistingResult.Success)
		{
			ThrowForOpenExistingFailure(openExistingResult, name);
		}
		return result;
	}

	[DoesNotReturn]
	private static void ThrowForOpenExistingFailure(OpenExistingResult openExistingResult, string name)
	{
		switch (openExistingResult)
		{
		case OpenExistingResult.NameNotFound:
			throw new WaitHandleCannotBeOpenedException();
		case OpenExistingResult.NameInvalid:
			throw new WaitHandleCannotBeOpenedException(SR.Format("Threading_WaitHandleCannotBeOpenedException_InvalidHandle", name));
		case OpenExistingResult.PathNotFound:
			throw new IOException(SR.Format("IO_PathNotFound_Path", name));
		default:
			throw new WaitHandleCannotBeOpenedException(SR.Format("NamedWaitHandles_ExistingObjectIncompatibleWithCurrentUserOnly", name));
		}
	}

	[SupportedOSPlatform("windows")]
	public static bool TryOpenExisting(string name, NamedWaitHandleOptions options, [NotNullWhen(true)] out Semaphore? result)
	{
		return OpenExistingWorker(name, new NamedWaitHandleOptionsInternal(options), out result) == OpenExistingResult.Success;
	}

	[SupportedOSPlatform("windows")]
	public static bool TryOpenExisting(string name, [NotNullWhen(true)] out Semaphore? result)
	{
		return OpenExistingWorker(name, default(NamedWaitHandleOptionsInternal), out result) == OpenExistingResult.Success;
	}

	public int Release()
	{
		return ReleaseCore(1);
	}

	public int Release(int releaseCount)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(releaseCount, "releaseCount");
		return ReleaseCore(releaseCount);
	}

	private void CreateSemaphoreCore(int initialCount, int maximumCount)
	{
		ValidateArguments(initialCount, maximumCount);
		base.SafeWaitHandle = WaitSubsystem.NewSemaphore(initialCount, maximumCount);
	}

	private void CreateSemaphoreCore(int initialCount, int maximumCount, string name, NamedWaitHandleOptionsInternal options, out bool createdNew)
	{
		ValidateArguments(initialCount, maximumCount);
		if (name != null)
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_NamedSynchronizationPrimitives");
		}
		base.SafeWaitHandle = WaitSubsystem.NewSemaphore(initialCount, maximumCount);
		createdNew = true;
	}

	private static OpenExistingResult OpenExistingWorker(string name, NamedWaitHandleOptionsInternal options, out Semaphore result)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_NamedSynchronizationPrimitives");
	}

	private int ReleaseCore(int releaseCount)
	{
		SafeWaitHandle safeWaitHandle = base.SafeWaitHandle;
		if (safeWaitHandle.IsInvalid)
		{
			WaitHandle.ThrowInvalidHandleException();
		}
		safeWaitHandle.DangerousAddRef();
		try
		{
			return WaitSubsystem.ReleaseSemaphore(safeWaitHandle.DangerousGetHandle(), releaseCount);
		}
		finally
		{
			safeWaitHandle.DangerousRelease();
		}
	}
}
