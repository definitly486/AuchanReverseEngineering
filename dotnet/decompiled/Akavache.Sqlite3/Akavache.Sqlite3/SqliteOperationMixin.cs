using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal static class SqliteOperationMixin
{
	public static SQLite3.Result Checked(this IPreparedSqliteOperation connection, int sqlite3ErrorCode, string? message = null)
	{
		if ((sqlite3ErrorCode == 0 || (uint)(sqlite3ErrorCode - 100) <= 1u) ? true : false)
		{
			return (SQLite3.Result)sqlite3ErrorCode;
		}
		string text = raw.sqlite3_errmsg(connection.Connection.Handle).utf8_to_string();
		SQLiteException ex = SQLiteException.New((SQLite3.Result)sqlite3ErrorCode, (message ?? string.Empty) + ": " + text);
		connection.Log().Warn(ex, message);
		throw ex;
	}
}
