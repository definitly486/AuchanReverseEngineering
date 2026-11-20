namespace Microsoft.Win32.SafeHandles;

public sealed class SafeProcessHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	private readonly SafeWaitHandle _handle;

	private readonly bool _releaseRef;

	internal int ProcessId { get; }

	public SafeProcessHandle(nint existingHandle, bool ownsHandle)
		: base(ownsHandle)
	{
		SetHandle(existingHandle);
	}

	internal SafeProcessHandle(int processId, SafeWaitHandle handle)
		: this(handle.DangerousGetHandle(), ownsHandle: true)
	{
		ProcessId = processId;
		_handle = handle;
		handle.DangerousAddRef(ref _releaseRef);
	}

	protected override bool ReleaseHandle()
	{
		if (_releaseRef)
		{
			_handle.DangerousRelease();
		}
		return true;
	}
}
