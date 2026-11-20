using System;
using System.Runtime.InteropServices;

namespace SQLitePCL;

public class sqlite3_blob : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	private sqlite3_blob()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		raw.internal_sqlite3_blob_close(handle);
		return true;
	}
}
