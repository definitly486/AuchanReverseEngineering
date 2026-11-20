using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

public sealed class Mutex : WaitHandle
{
	public Mutex(bool initiallyOwned, string? name, NamedWaitHandleOptions options, out bool createdNew)
	{
		CreateMutexCore(initiallyOwned, name, new NamedWaitHandleOptionsInternal(options), out createdNew);
	}

	public Mutex(bool initiallyOwned, string? name, out bool createdNew)
	{
		CreateMutexCore(initiallyOwned, name, default(NamedWaitHandleOptionsInternal), out createdNew);
	}

	public Mutex(bool initiallyOwned, string? name, NamedWaitHandleOptions options)
	{
		CreateMutexCore(initiallyOwned, name, new NamedWaitHandleOptionsInternal(options), out var _);
	}

	public Mutex(bool initiallyOwned, string? name)
	{
		CreateMutexCore(initiallyOwned, name, default(NamedWaitHandleOptionsInternal), out var _);
	}

	public Mutex(string? name, NamedWaitHandleOptions options)
	{
		CreateMutexCore(initiallyOwned: false, name, new NamedWaitHandleOptionsInternal(options), out var _);
	}

	public Mutex(bool initiallyOwned)
	{
		CreateMutexCore(initiallyOwned);
	}

	public Mutex()
	{
		CreateMutexCore(initiallyOwned: false);
	}

	private Mutex(SafeWaitHandle handle)
	{
		base.SafeWaitHandle = handle;
	}

	public static Mutex OpenExisting(string name, NamedWaitHandleOptions options)
	{
		Mutex result;
		OpenExistingResult openExistingResult = OpenExistingWorker(name, new NamedWaitHandleOptionsInternal(options), out result);
		if (openExistingResult != OpenExistingResult.Success)
		{
			ThrowForOpenExistingFailure(openExistingResult, name);
		}
		return result;
	}

	public static Mutex OpenExisting(string name)
	{
		Mutex result;
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

	public static bool TryOpenExisting(string name, NamedWaitHandleOptions options, [NotNullWhen(true)] out Mutex? result)
	{
		return OpenExistingWorker(name, new NamedWaitHandleOptionsInternal(options), out result) == OpenExistingResult.Success;
	}

	public static bool TryOpenExisting(string name, [NotNullWhen(true)] out Mutex? result)
	{
		return OpenExistingWorker(name, default(NamedWaitHandleOptionsInternal), out result) == OpenExistingResult.Success;
	}

	private void CreateMutexCore(bool initiallyOwned)
	{
		base.SafeWaitHandle = WaitSubsystem.NewMutex(initiallyOwned);
	}

	private void CreateMutexCore(bool initiallyOwned, string name, NamedWaitHandleOptionsInternal options, out bool createdNew)
	{
		if (!string.IsNullOrEmpty(name))
		{
			name = BuildNameForOptions(name, options);
			SafeWaitHandle safeWaitHandle = WaitSubsystem.CreateNamedMutex(initiallyOwned, name, out createdNew);
			if (safeWaitHandle == null)
			{
				throw new WaitHandleCannotBeOpenedException(SR.Format("Threading_WaitHandleCannotBeOpenedException_InvalidHandle", name));
			}
			base.SafeWaitHandle = safeWaitHandle;
		}
		else
		{
			base.SafeWaitHandle = WaitSubsystem.NewMutex(initiallyOwned);
			createdNew = true;
		}
	}

	private static OpenExistingResult OpenExistingWorker(string name, NamedWaitHandleOptionsInternal options, out Mutex result)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		name = BuildNameForOptions(name, options);
		SafeWaitHandle result2;
		OpenExistingResult openExistingResult = WaitSubsystem.OpenNamedMutex(name, out result2);
		result = ((openExistingResult == OpenExistingResult.Success) ? new Mutex(result2) : null);
		return openExistingResult;
	}

	private static string BuildNameForOptions(string name, NamedWaitHandleOptionsInternal options)
	{
		if (options.WasSpecified)
		{
			name = options.GetNameWithSessionPrefix(name);
		}
		if (name.StartsWith("Local\\") && name.Length > "Local\\".Length)
		{
			name = name.Substring("Local\\".Length);
		}
		if (options.WasSpecified && options.CurrentUserOnly)
		{
			name = "User\\" + name;
		}
		return name;
	}

	public void ReleaseMutex()
	{
		SafeWaitHandle safeWaitHandle = base.SafeWaitHandle;
		if (safeWaitHandle.IsInvalid)
		{
			WaitHandle.ThrowInvalidHandleException();
		}
		safeWaitHandle.DangerousAddRef();
		try
		{
			WaitSubsystem.ReleaseMutex(safeWaitHandle.DangerousGetHandle());
		}
		finally
		{
			safeWaitHandle.DangerousRelease();
		}
	}
}
