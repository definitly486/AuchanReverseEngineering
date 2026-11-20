using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace SQLitePCL;

public class sqlite3 : SafeHandle
{
	private ConcurrentDictionary<IntPtr, sqlite3_stmt> _stmts;

	private IDisposable extra;

	public override bool IsInvalid => handle == IntPtr.Zero;

	private sqlite3()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		raw.internal_sqlite3_close_v2(handle);
		dispose_extra();
		return true;
	}

	public int manual_close_v2()
	{
		int result = raw.internal_sqlite3_close_v2(handle);
		handle = IntPtr.Zero;
		dispose_extra();
		return result;
	}

	public int manual_close()
	{
		int result = raw.internal_sqlite3_close(handle);
		handle = IntPtr.Zero;
		dispose_extra();
		return result;
	}

	internal static sqlite3 New(IntPtr p)
	{
		sqlite3 obj = new sqlite3();
		obj.SetHandle(p);
		return obj;
	}

	internal void add_stmt(sqlite3_stmt stmt)
	{
		if (_stmts != null)
		{
			_stmts[stmt.ptr] = stmt;
		}
	}

	internal void remove_stmt(sqlite3_stmt s)
	{
		if (_stmts != null)
		{
			_stmts.TryRemove(s.ptr, out var _);
		}
	}

	public T GetOrCreateExtra<T>(Func<T> f) where T : class, IDisposable
	{
		if (extra != null)
		{
			return (T)extra;
		}
		return (T)(extra = f());
	}

	private void dispose_extra()
	{
		if (extra != null)
		{
			extra.Dispose();
			extra = null;
		}
	}
}
