using System;
using System.Reactive.Disposables;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class BeginTransactionSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt _beginOp;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public BeginTransactionSqliteOperation(SQLiteConnection conn)
	{
		SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "BEGIN TRANSACTION", out _beginOp);
		Connection = conn;
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, "Couldn't prepare statement");
		}
		_inner = _beginOp;
	}

	public Action PrepareToExecute()
	{
		return delegate
		{
			try
			{
				this.Checked(raw.sqlite3_step(_beginOp));
			}
			finally
			{
				this.Checked(raw.sqlite3_reset(_beginOp));
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
