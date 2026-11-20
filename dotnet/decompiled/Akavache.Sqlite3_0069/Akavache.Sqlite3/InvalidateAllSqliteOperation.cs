using System;
using SQLite;
using SQLitePCL;
using Splat;

namespace Akavache.Sqlite3;

internal class InvalidateAllSqliteOperation(SQLiteConnection connection) : IPreparedSqliteOperation, IEnableLogger, IDisposable
{
	private readonly SQLiteConnection _connection = connection;

	private bool _disposedValue;

	public SQLiteConnection Connection { get; protected set; }

	public InvalidateAllSqliteOperation(SQLiteConnection connection)
	{
		Connection = connection;
		base._002Ector();
	}

	public Action PrepareToExecute()
	{
		return delegate
		{
			this.Checked(raw.sqlite3_exec(connection.Handle, "DELETE FROM CacheElement"));
		};
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposedValue)
		{
			if (disposing)
			{
				connection.Dispose();
			}
			_disposedValue = true;
		}
	}
}
