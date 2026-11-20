using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SQLitePCL;

public class sqlite3_snapshot : SafeHandle
{
	public override bool IsInvalid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ReleaseHandle()
	{
		throw new NotSupportedException("Linked away");
	}
}
