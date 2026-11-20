using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.SafeHandles;

public sealed class SafeMemoryMappedViewHandle : SafeBuffer
{
	internal SafeMemoryMappedViewHandle(nint handle, bool ownsHandle)
		: base(ownsHandle)
	{
		SetHandle(handle);
	}

	protected override bool ReleaseHandle()
	{
		nint addr = handle;
		handle = new IntPtr(-1);
		return global::Interop.Sys.MUnmap(addr, base.ByteLength) == 0;
	}
}
