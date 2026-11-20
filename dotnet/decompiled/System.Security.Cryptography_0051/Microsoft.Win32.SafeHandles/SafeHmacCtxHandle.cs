using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.SafeHandles;

internal sealed class SafeHmacCtxHandle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeHmacCtxHandle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.Crypto.HmacDestroy(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
