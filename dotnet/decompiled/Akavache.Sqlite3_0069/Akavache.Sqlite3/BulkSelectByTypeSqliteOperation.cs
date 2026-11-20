using System.Reactive.Concurrency;
using SQLite;

namespace Akavache.Sqlite3;

internal class BulkSelectByTypeSqliteOperation : BulkSelectSqliteOperation
{
	public BulkSelectByTypeSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
		: base(conn, useTypeInsteadOfKey: true, scheduler)
	{
	}
}
