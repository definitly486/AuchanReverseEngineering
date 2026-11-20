using System;
using Akavache.Core;

namespace Akavache.Sqlite3;

[Preserve(AllMembers = true)]
public static class LinkerPreserve
{
	static LinkerPreserve()
	{
		throw new InvalidOperationException(typeof(SQLitePersistentBlobCache).FullName);
	}
}
