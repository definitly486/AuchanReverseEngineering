namespace SQLitePCL;

public static class Batteries_V2
{
	public static void Init()
	{
		raw.SetProvider(new SQLite3Provider_e_sqlite3());
	}
}
