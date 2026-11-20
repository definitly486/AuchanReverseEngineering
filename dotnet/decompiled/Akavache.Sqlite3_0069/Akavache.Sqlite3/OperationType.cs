namespace Akavache.Sqlite3;

internal enum OperationType
{
	DoNothing,
	BulkSelectSqliteOperation,
	BulkSelectByTypeSqliteOperation,
	BulkInsertSqliteOperation,
	BulkInvalidateSqliteOperation,
	BulkInvalidateByTypeSqliteOperation,
	InvalidateAllSqliteOperation,
	VacuumSqliteOperation,
	DeleteExpiredSqliteOperation,
	GetKeysSqliteOperation
}
