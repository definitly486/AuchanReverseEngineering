using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Text;
using System.Threading;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class BulkSelectSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly sqlite3_stmt[] _selectOps;

	private readonly IScheduler _scheduler;

	private IDisposable _inner;

	public SQLiteConnection Connection { get; protected set; }

	public BulkSelectSqliteOperation(SQLiteConnection conn, bool useTypeInsteadOfKey, IScheduler scheduler)
	{
		StringBuilder qs = new StringBuilder("?");
		string column = (useTypeInsteadOfKey ? "TypeName" : "Key");
		Connection = conn;
		_scheduler = scheduler;
		_selectOps = Enumerable.Range(1, 64).Select((Func<int, sqlite3_stmt>)delegate
		{
			sqlite3_stmt stmt;
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, $"SELECT Key,TypeName,Value,Expiration,CreatedAt FROM CacheElement WHERE {column} In ({qs})", out stmt);
			string text = raw.sqlite3_errmsg(conn.Handle).utf8_to_string();
			if (result != SQLite3.Result.OK)
			{
				throw SQLiteException.New(result, "Couldn't prepare statement: " + text);
			}
			qs.Append(",?");
			return stmt;
		}).ToArray();
		_inner = new CompositeDisposable(_selectOps.OfType<IDisposable>().ToArray());
	}

	public Func<IEnumerable<CacheElement>> PrepareToExecute(IEnumerable<string>? toSelect)
	{
		List<string> selectList = (toSelect ?? Array.Empty<string>()).ToList();
		if (selectList.Count == 0)
		{
			return () => Array.Empty<CacheElement>();
		}
		sqlite3_stmt selectOp = _selectOps[selectList.Count - 1];
		DateTimeOffset now = _scheduler.Now;
		return delegate
		{
			List<CacheElement> list = new List<CacheElement>();
			try
			{
				for (int i = 0; i < selectList.Count; i++)
				{
					this.Checked(raw.sqlite3_bind_text(selectOp, i + 1, selectList[i]));
				}
				while (this.Checked(raw.sqlite3_step(selectOp)) == SQLite3.Result.Row)
				{
					CacheElement cacheElement = new CacheElement
					{
						Key = raw.sqlite3_column_text(selectOp, 0).utf8_to_string(),
						TypeName = raw.sqlite3_column_text(selectOp, 1).utf8_to_string(),
						Value = raw.sqlite3_column_blob(selectOp, 2).ToArray(),
						Expiration = new DateTime(raw.sqlite3_column_int64(selectOp, 3)),
						CreatedAt = new DateTime(raw.sqlite3_column_int64(selectOp, 4))
					};
					if (now.UtcTicks <= cacheElement.Expiration.Ticks)
					{
						list.Add(cacheElement);
					}
				}
				return list;
			}
			finally
			{
				this.Checked(raw.sqlite3_reset(selectOp));
			}
		};
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
	}
}
