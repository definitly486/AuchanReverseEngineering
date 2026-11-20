using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.SafeHandles;

internal sealed class SafeEvpMdCtxHandle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeEvpMdCtxHandle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.Crypto.EvpMdCtxDestroy(handle);
		return true;
	}
}
