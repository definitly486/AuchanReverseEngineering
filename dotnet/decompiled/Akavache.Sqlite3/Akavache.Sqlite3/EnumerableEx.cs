using System.Collections.Generic;

namespace Akavache.Sqlite3;

internal static class EnumerableEx
{
	public static IEnumerable<T> Return<T>(T value)
	{
		yield return value;
	}
}
