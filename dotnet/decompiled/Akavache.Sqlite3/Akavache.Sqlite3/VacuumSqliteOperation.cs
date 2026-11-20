using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class VacuumSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt _vacuumOp;

	private readonly IScheduler _scheduler;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public VacuumSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
	{
		SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "VACUUM", out _vacuumOp);
		Connection = conn;
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, "Couldn't prepare vacuum statement");
		}
		_scheduler = scheduler;
		_inner = _vacuumOp;
	}

	public Action PrepareToExecute()
	{
		_ = _scheduler.Now.UtcTicks;
		return delegate
		{
			try
			{
				this.Checked(raw.sqlite3_step(_vacuumOp));
			}
			finally
			{
				this.Checked(raw.sqlite3_reset(_vacuumOp));
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
