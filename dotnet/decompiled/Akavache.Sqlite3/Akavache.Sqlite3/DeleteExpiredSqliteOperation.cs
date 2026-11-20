using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class DeleteExpiredSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt _deleteOp;

	private readonly IScheduler _scheduler;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public DeleteExpiredSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
	{
		SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "DELETE FROM CacheElement WHERE Expiration < ?", out _deleteOp);
		Connection = conn;
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, "Couldn't prepare delete statement");
		}
		_scheduler = scheduler;
		_inner = _deleteOp;
	}

	public Action PrepareToExecute()
	{
		long now = _scheduler.Now.UtcTicks;
		return delegate
		{
			try
			{
				this.Checked(raw.sqlite3_bind_int64(_deleteOp, 1, now));
				this.Checked(raw.sqlite3_step(_deleteOp));
			}
			finally
			{
				this.Checked(raw.sqlite3_reset(_deleteOp));
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
