using System;

namespace SQLitePCL;

public class sqlite3_context
{
	private IntPtr _p;

	private object _user_data;

	protected sqlite3_context(object user_data)
	{
		_user_data = user_data;
	}

	protected void set_context_ptr(IntPtr p)
	{
		_p = p;
	}
}
