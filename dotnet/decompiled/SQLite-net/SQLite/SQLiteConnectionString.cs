using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace SQLite;

public class SQLiteConnectionString
{
	[CompilerGenerated]
	private readonly string _003CUniqueKey_003Ek__BackingField;

	public string DatabasePath { get; }

	public bool StoreDateTimeAsTicks { get; }

	public bool StoreTimeSpanAsTicks { get; }

	public string DateTimeStringFormat { get; }

	public DateTimeStyles DateTimeStyle { get; }

	public object Key { get; }

	public SQLiteOpenFlags OpenFlags { get; }

	public Action<SQLiteConnection> PreKeyAction { get; }

	public Action<SQLiteConnection> PostKeyAction { get; }

	public string VfsName { get; }

	public SQLiteConnectionString(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks, object key = null, Action<SQLiteConnection> preKeyAction = null, Action<SQLiteConnection> postKeyAction = null, string vfsName = null, string dateTimeStringFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff", bool storeTimeSpanAsTicks = true)
	{
		if (key != null && !(key is byte[]) && !(key is string))
		{
			throw new ArgumentException("Encryption keys must be strings or byte arrays", "key");
		}
		_003CUniqueKey_003Ek__BackingField = $"{databasePath}_{(uint)openFlags:X8}";
		StoreDateTimeAsTicks = storeDateTimeAsTicks;
		StoreTimeSpanAsTicks = storeTimeSpanAsTicks;
		DateTimeStringFormat = dateTimeStringFormat;
		DateTimeStyle = (("o".Equals(DateTimeStringFormat, StringComparison.OrdinalIgnoreCase) || "r".Equals(DateTimeStringFormat, StringComparison.OrdinalIgnoreCase)) ? DateTimeStyles.RoundtripKind : DateTimeStyles.None);
		Key = key;
		PreKeyAction = preKeyAction;
		PostKeyAction = postKeyAction;
		OpenFlags = openFlags;
		VfsName = vfsName;
		DatabasePath = databasePath;
	}
}
