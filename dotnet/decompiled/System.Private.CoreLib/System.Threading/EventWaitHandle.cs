using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Versioning;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

public class EventWaitHandle : WaitHandle
{
	public EventWaitHandle(bool initialState, EventResetMode mode)
	{
		CreateEventCore(initialState, mode);
	}

	public EventWaitHandle(bool initialState, EventResetMode mode, string? name, NamedWaitHandleOptions options)
	{
		CreateEventCore(initialState, mode, name, new NamedWaitHandleOptionsInternal(options), out var _);
	}

	public EventWaitHandle(bool initialState, EventResetMode mode, string? name)
	{
		CreateEventCore(initialState, mode, name, default(NamedWaitHandleOptionsInternal), out var _);
	}

	public EventWaitHandle(bool initialState, EventResetMode mode, string? name, NamedWaitHandleOptions options, out bool createdNew)
	{
		CreateEventCore(initialState, mode, name, new NamedWaitHandleOptionsInternal(options), out createdNew);
	}

	public EventWaitHandle(bool initialState, EventResetMode mode, string? name, out bool createdNew)
	{
		CreateEventCore(initialState, mode, name, default(NamedWaitHandleOptionsInternal), out createdNew);
	}

	private static void ValidateMode(EventResetMode mode)
	{
		if (mode != EventResetMode.AutoReset && mode != EventResetMode.ManualReset)
		{
			throw new ArgumentException("Argument_InvalidFlag", "mode");
		}
	}

	[SupportedOSPlatform("windows")]
	public static EventWaitHandle OpenExisting(string name, NamedWaitHandleOptions options)
	{
		EventWaitHandle result;
		OpenExistingResult openExistingResult = OpenExistingWorker(name, new NamedWaitHandleOptionsInternal(options), out result);
		if (openExistingResult != OpenExistingResult.Success)
		{
			ThrowForOpenExistingFailure(openExistingResult, name);
		}
		return result;
	}

	[SupportedOSPlatform("windows")]
	public static EventWaitHandle OpenExisting(string name)
	{
		EventWaitHandle result;
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
			throw new DirectoryNotFoundException(SR.Format("IO_PathNotFound_Path", name));
		default:
			throw new WaitHandleCannotBeOpenedException(SR.Format("NamedWaitHandles_ExistingObjectIncompatibleWithCurrentUserOnly", name));
		}
	}

	[SupportedOSPlatform("windows")]
	public static bool TryOpenExisting(string name, NamedWaitHandleOptions options, [NotNullWhen(true)] out EventWaitHandle? result)
	{
		return OpenExistingWorker(name, new NamedWaitHandleOptionsInternal(options), out result) == OpenExistingResult.Success;
	}

	[SupportedOSPlatform("windows")]
	public static bool TryOpenExisting(string name, [NotNullWhen(true)] out EventWaitHandle? result)
	{
		return OpenExistingWorker(name, default(NamedWaitHandleOptionsInternal), out result) == OpenExistingResult.Success;
	}

	private void CreateEventCore(bool initialState, EventResetMode mode)
	{
		ValidateMode(mode);
		base.SafeWaitHandle = WaitSubsystem.NewEvent(initialState, mode);
	}

	private void CreateEventCore(bool initialState, EventResetMode mode, string name, NamedWaitHandleOptionsInternal options, out bool createdNew)
	{
		ValidateMode(mode);
		if (name != null)
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_NamedSynchronizationPrimitives");
		}
		base.SafeWaitHandle = WaitSubsystem.NewEvent(initialState, mode);
		createdNew = true;
	}

	private static OpenExistingResult OpenExistingWorker(string name, NamedWaitHandleOptionsInternal options, out EventWaitHandle result)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_NamedSynchronizationPrimitives");
	}

	public bool Reset()
	{
		SafeWaitHandle safeWaitHandle = ValidateHandle();
		try
		{
			WaitSubsystem.ResetEvent(safeWaitHandle.DangerousGetHandle());
			return true;
		}
		finally
		{
			safeWaitHandle.DangerousRelease();
		}
	}

	public bool Set()
	{
		SafeWaitHandle safeWaitHandle = ValidateHandle();
		try
		{
			WaitSubsystem.SetEvent(safeWaitHandle.DangerousGetHandle());
			return true;
		}
		finally
		{
			safeWaitHandle.DangerousRelease();
		}
	}

	internal static bool Set(SafeWaitHandle waitHandle)
	{
		waitHandle.DangerousAddRef();
		try
		{
			WaitSubsystem.SetEvent(waitHandle.DangerousGetHandle());
			return true;
		}
		finally
		{
			waitHandle.DangerousRelease();
		}
	}

	private SafeWaitHandle ValidateHandle()
	{
		SafeWaitHandle safeWaitHandle = base.SafeWaitHandle;
		if (safeWaitHandle.IsInvalid)
		{
			WaitHandle.ThrowInvalidHandleException();
		}
		safeWaitHandle.DangerousAddRef();
		return safeWaitHandle;
	}
}
