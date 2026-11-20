using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class GetKeysSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt _selectOp;

	private readonly IScheduler _scheduler;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public GetKeysSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
	{
		SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "SELECT Key FROM CacheElement WHERE Expiration >= ?", out _selectOp);
		Connection = conn;
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, "Couldn't prepare statement");
		}
		_inner = _selectOp;
		_scheduler = scheduler;
	}

	public Func<IEnumerable<string>> PrepareToExecute()
	{
		return delegate
		{
			List<string> list = new List<string>();
			try
			{
				this.Checked(raw.sqlite3_bind_int64(_selectOp, 1, _scheduler.Now.UtcTicks));
				while (this.Checked(raw.sqlite3_step(_selectOp)) == SQLite3.Result.Row)
				{
					list.Add(raw.sqlite3_column_text(_selectOp, 0).utf8_to_string());
				}
				return list;
			}
			finally
			{
				this.Checked(raw.sqlite3_reset(_selectOp));
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
