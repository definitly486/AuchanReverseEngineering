using System.Threading;

namespace Microsoft.Win32.SafeHandles;

public sealed class SafeWaitHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	public SafeWaitHandle()
		: base(ownsHandle: true)
	{
	}

	public SafeWaitHandle(nint existingHandle, bool ownsHandle)
		: base(ownsHandle)
	{
		SetHandle(existingHandle);
	}

	protected override bool ReleaseHandle()
	{
		WaitSubsystem.DeleteHandle(handle);
		return true;
	}
}
