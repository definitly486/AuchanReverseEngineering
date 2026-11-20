using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.SafeHandles;

internal sealed class SafeEvpCipherCtxHandle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeEvpCipherCtxHandle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.Crypto.EvpCipherDestroy(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
