using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.SafeHandles;

internal sealed class SafeX509Handle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeX509Handle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.Crypto.X509Destroy(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
