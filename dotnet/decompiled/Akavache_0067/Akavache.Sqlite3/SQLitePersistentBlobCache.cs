using System.Diagnostics.CodeAnalysis;
using System.Reactive.Concurrency;

namespace Akavache.Sqlite3;

[RequiresUnreferencedCode("Registrations for Akavache")]
[RequiresDynamicCode("Registrations for Akavache")]
public class SQLitePersistentBlobCache : SqlRawPersistentBlobCache
{
	public SQLitePersistentBlobCache(string databaseFile, IScheduler? scheduler = null)
		: base(databaseFile, scheduler)
	{
	}
}
