using System;
using SQLite;
using Splat;

namespace Akavache.Sqlite3;

internal interface IPreparedSqliteOperation : IEnableLogger, IDisposable
{
	SQLiteConnection Connection { get; }
}
