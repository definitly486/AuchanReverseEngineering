using System;
using System.Text;

namespace SQLitePCL;

public static class raw
{
	private static ISQLite3Provider _imp;

	private static bool _frozen;

	private static ISQLite3Provider Provider
	{
		get
		{
			if (_imp == null)
			{
				throw new Exception("You need to call SQLitePCL.raw.SetProvider().  If you are using a bundle package, this is done by calling SQLitePCL.Batteries.Init().");
			}
			return _imp;
		}
	}

	static raw()
	{
		_frozen = false;
	}

	public static void SetProvider(ISQLite3Provider imp)
	{
		if (!_frozen)
		{
			imp.sqlite3_libversion_number();
			_imp = imp;
		}
	}

	public static int sqlite3_open(utf8z filename, out sqlite3 db)
	{
		IntPtr db2;
		int result = Provider.sqlite3_open(filename, out db2);
		db = sqlite3.New(db2);
		return result;
	}

	public static int sqlite3_open(string filename, out sqlite3 db)
	{
		return sqlite3_open(filename.to_utf8z(), out db);
	}

	public static int sqlite3_open_v2(utf8z filename, out sqlite3 db, int flags, utf8z vfs)
	{
		IntPtr db2;
		int result = Provider.sqlite3_open_v2(filename, out db2, flags, vfs);
		db = sqlite3.New(db2);
		return result;
	}

	public static int sqlite3_open_v2(string filename, out sqlite3 db, int flags, string vfs)
	{
		return sqlite3_open_v2(filename.to_utf8z(), out db, flags, vfs.to_utf8z());
	}

	internal static int internal_sqlite3_close_v2(IntPtr p)
	{
		return Provider.sqlite3_close_v2(p);
	}

	internal static int internal_sqlite3_close(IntPtr p)
	{
		return Provider.sqlite3_close(p);
	}

	public static int sqlite3_close_v2(sqlite3 db)
	{
		return db.manual_close_v2();
	}

	public static int sqlite3_close(sqlite3 db)
	{
		return db.manual_close();
	}

	public static int sqlite3_libversion_number()
	{
		return Provider.sqlite3_libversion_number();
	}

	public static int sqlite3_enable_load_extension(sqlite3 db, int onoff)
	{
		return Provider.sqlite3_enable_load_extension(db, onoff);
	}

	public static utf8z sqlite3_errmsg(sqlite3 db)
	{
		return Provider.sqlite3_errmsg(db);
	}

	public static long sqlite3_last_insert_rowid(sqlite3 db)
	{
		return Provider.sqlite3_last_insert_rowid(db);
	}

	public static int sqlite3_changes(sqlite3 db)
	{
		return Provider.sqlite3_changes(db);
	}

	public static int sqlite3_busy_timeout(sqlite3 db, int ms)
	{
		return Provider.sqlite3_busy_timeout(db, ms);
	}

	public static int sqlite3_errcode(sqlite3 db)
	{
		return Provider.sqlite3_errcode(db);
	}

	public static int sqlite3_extended_errcode(sqlite3 db)
	{
		return Provider.sqlite3_extended_errcode(db);
	}

	public static int sqlite3_prepare_v2(sqlite3 db, string sql, out sqlite3_stmt stmt)
	{
		byte[] array = sql.to_utf8_with_z();
		ReadOnlySpan<byte> sql2 = new ReadOnlySpan<byte>(array);
		ReadOnlySpan<byte> tail;
		return sqlite3_prepare_v2(db, sql2, out stmt, out tail);
	}

	public static int sqlite3_prepare_v2(sqlite3 db, ReadOnlySpan<byte> sql, out sqlite3_stmt stmt, out ReadOnlySpan<byte> tail)
	{
		IntPtr stmt2;
		int result = Provider.sqlite3_prepare_v2(db, sql, out stmt2, out tail);
		stmt = sqlite3_stmt.From(stmt2, db);
		return result;
	}

	public static int sqlite3_exec(sqlite3 db, string sql)
	{
		IntPtr errMsg;
		int result = Provider.sqlite3_exec(db, sql.to_utf8z(), null, null, out errMsg);
		if (!(errMsg == IntPtr.Zero))
		{
			Provider.sqlite3_free(errMsg);
		}
		return result;
	}

	public static int sqlite3_step(sqlite3_stmt stmt)
	{
		return Provider.sqlite3_step(stmt);
	}

	public static int sqlite3_finalize(sqlite3_stmt stmt)
	{
		return stmt.manual_close();
	}

	public static int internal_sqlite3_finalize(IntPtr stmt)
	{
		return Provider.sqlite3_finalize(stmt);
	}

	public static int sqlite3_reset(sqlite3_stmt stmt)
	{
		return Provider.sqlite3_reset(stmt);
	}

	public static int sqlite3_bind_blob(sqlite3_stmt stmt, int index, ReadOnlySpan<byte> blob)
	{
		return Provider.sqlite3_bind_blob(stmt, index, blob);
	}

	public static int sqlite3_bind_double(sqlite3_stmt stmt, int index, double val)
	{
		return Provider.sqlite3_bind_double(stmt, index, val);
	}

	public static int sqlite3_bind_int(sqlite3_stmt stmt, int index, int val)
	{
		return Provider.sqlite3_bind_int(stmt, index, val);
	}

	public static int sqlite3_bind_int64(sqlite3_stmt stmt, int index, long val)
	{
		return Provider.sqlite3_bind_int64(stmt, index, val);
	}

	public static int sqlite3_bind_null(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_bind_null(stmt, index);
	}

	public static int sqlite3_bind_text(sqlite3_stmt stmt, int index, ReadOnlySpan<byte> val)
	{
		return Provider.sqlite3_bind_text(stmt, index, val);
	}

	public static int sqlite3_bind_text(sqlite3_stmt stmt, int index, utf8z val)
	{
		return Provider.sqlite3_bind_text(stmt, index, val);
	}

	public unsafe static int sqlite3_bind_text(sqlite3_stmt stmt, int index, string val)
	{
		if (val != null && val.Length <= 512)
		{
			int byteCount = Encoding.UTF8.GetByteCount(val);
			if (byteCount <= 512 && byteCount > 0)
			{
				Span<byte> span = stackalloc byte[byteCount];
				fixed (string text = val)
				{
					char* ptr = (char*)(nuint)text;
					if (ptr != null)
					{
						ptr += 6;
					}
					fixed (byte* bytes = span)
					{
						Encoding.UTF8.GetBytes(ptr, val.Length, bytes, byteCount);
					}
				}
				return sqlite3_bind_text(stmt, index, span);
			}
		}
		return sqlite3_bind_text(stmt, index, val.to_utf8z());
	}

	public static int sqlite3_bind_parameter_index(sqlite3_stmt stmt, utf8z strName)
	{
		return Provider.sqlite3_bind_parameter_index(stmt, strName);
	}

	public static int sqlite3_bind_parameter_index(sqlite3_stmt stmt, string strName)
	{
		return sqlite3_bind_parameter_index(stmt, strName.to_utf8z());
	}

	public static utf8z sqlite3_column_name(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_name(stmt, index);
	}

	public static utf8z sqlite3_column_text(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_text(stmt, index);
	}

	public static int sqlite3_column_count(sqlite3_stmt stmt)
	{
		return Provider.sqlite3_column_count(stmt);
	}

	public static double sqlite3_column_double(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_double(stmt, index);
	}

	public static int sqlite3_column_int(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_int(stmt, index);
	}

	public static long sqlite3_column_int64(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_int64(stmt, index);
	}

	public static ReadOnlySpan<byte> sqlite3_column_blob(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_blob(stmt, index);
	}

	public static int sqlite3_column_bytes(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_bytes(stmt, index);
	}

	public static int sqlite3_column_type(sqlite3_stmt stmt, int index)
	{
		return Provider.sqlite3_column_type(stmt, index);
	}

	public static sqlite3_backup sqlite3_backup_init(sqlite3 destDb, string destName, sqlite3 sourceDb, string sourceName)
	{
		return Provider.sqlite3_backup_init(destDb, destName.to_utf8z(), sourceDb, sourceName.to_utf8z());
	}

	public static int sqlite3_backup_step(sqlite3_backup backup, int nPage)
	{
		return Provider.sqlite3_backup_step(backup, nPage);
	}

	public static int sqlite3_backup_finish(sqlite3_backup backup)
	{
		return backup.manual_close();
	}

	internal static int internal_sqlite3_backup_finish(IntPtr p)
	{
		return Provider.sqlite3_backup_finish(p);
	}

	internal static int internal_sqlite3_blob_close(IntPtr blob)
	{
		return Provider.sqlite3_blob_close(blob);
	}
}
