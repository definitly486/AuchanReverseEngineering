using SQLite;

namespace Akavache.Sqlite3;

internal class BulkInvalidateByTypeSqliteOperation : BulkInvalidateSqliteOperation
{
	public BulkInvalidateByTypeSqliteOperation(SQLiteConnection conn)
		: base(conn, useTypeInsteadOfKey: true)
	{
	}
}
