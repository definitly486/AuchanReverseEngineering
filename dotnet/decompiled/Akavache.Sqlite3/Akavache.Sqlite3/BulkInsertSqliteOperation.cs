using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class BulkInsertSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt _insertOp;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public BulkInsertSqliteOperation(SQLiteConnection conn)
	{
		SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "INSERT OR REPLACE INTO CacheElement VALUES (?,?,?,?,?)", out _insertOp);
		Connection = conn;
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, "Couldn't prepare statement");
		}
		_inner = _insertOp;
	}

	public Action PrepareToExecute(IEnumerable<CacheElement>? toInsert)
	{
		IEnumerable<CacheElement> enumerable = toInsert?.ToList();
		IEnumerable<CacheElement> insertList = enumerable ?? Enumerable.Empty<CacheElement>();
		return delegate
		{
			foreach (CacheElement item in insertList)
			{
				try
				{
					this.Checked(raw.sqlite3_bind_text(_insertOp, 1, item.Key));
					this.Checked(string.IsNullOrWhiteSpace(item.TypeName) ? raw.sqlite3_bind_null(_insertOp, 2) : raw.sqlite3_bind_text(_insertOp, 2, item.TypeName));
					this.Checked(raw.sqlite3_bind_blob(_insertOp, 3, item.Value));
					this.Checked(raw.sqlite3_bind_int64(_insertOp, 4, item.Expiration.Ticks));
					this.Checked(raw.sqlite3_bind_int64(_insertOp, 5, item.CreatedAt.Ticks));
					this.Checked(raw.sqlite3_step(_insertOp));
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(_insertOp));
				}
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
