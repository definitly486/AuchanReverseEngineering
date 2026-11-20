using System;

namespace Akavache.Sqlite3;

public static class SqlLite
{
	public static void Start(Action bundleRegistration)
	{
		if (bundleRegistration == null)
		{
			throw new ArgumentNullException("bundleRegistration");
		}
		bundleRegistration();
	}
}
