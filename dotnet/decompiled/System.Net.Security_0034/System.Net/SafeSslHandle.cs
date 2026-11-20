using System.Runtime.InteropServices;

namespace System.Net;

internal sealed class SafeSslHandle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeSslHandle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.AndroidCrypto.SSLStreamRelease(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
