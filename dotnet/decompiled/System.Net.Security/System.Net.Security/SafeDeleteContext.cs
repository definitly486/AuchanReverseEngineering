using System.Runtime.InteropServices;

namespace System.Net.Security;

internal abstract class SafeDeleteContext : SafeHandle
{
	public override bool IsInvalid => IntPtr.Zero == handle;

	public SafeDeleteContext(nint handle)
		: base(handle, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		return true;
	}
}
