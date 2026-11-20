using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class BulkInvalidateSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt[] _deleteOps;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public BulkInvalidateSqliteOperation(SQLiteConnection conn, bool useTypeInsteadOfKey)
	{
		StringBuilder qs = new StringBuilder("?");
		Connection = conn;
		string column = (useTypeInsteadOfKey ? "TypeName" : "Key");
		_deleteOps = Enumerable.Range(1, 64).Select((Func<int, sqlite3_stmt>)delegate
		{
			sqlite3_stmt stmt;
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, $"DELETE FROM CacheElement WHERE {column} In ({qs})", out stmt);
			if (result != SQLite3.Result.OK)
			{
				throw SQLiteException.New(result, "Couldn't prepare statement");
			}
			qs.Append(",?");
			return stmt;
		}).ToArray();
		_inner = new CompositeDisposable(_deleteOps.OfType<IDisposable>().ToArray());
	}

	public Action PrepareToExecute(IEnumerable<string>? toDelete)
	{
		List<string> deleteList = (toDelete ?? Array.Empty<string>()).ToList();
		if (deleteList.Count == 0)
		{
			return delegate
			{
			};
		}
		sqlite3_stmt deleteOp = _deleteOps[deleteList.Count - 1];
		return delegate
		{
			try
			{
				for (int i = 0; i < deleteList.Count; i++)
				{
					this.Checked(raw.sqlite3_bind_text(deleteOp, i + 1, deleteList[i]));
				}
				this.Checked(raw.sqlite3_step(deleteOp));
			}
			finally
			{
				this.Checked(raw.sqlite3_reset(deleteOp));
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
