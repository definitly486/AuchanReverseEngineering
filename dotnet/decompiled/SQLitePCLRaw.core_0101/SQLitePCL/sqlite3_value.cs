using System;

namespace SQLitePCL;

public class sqlite3_value
{
	private IntPtr _p;

	public sqlite3_value(IntPtr p)
	{
		_p = p;
	}
}
