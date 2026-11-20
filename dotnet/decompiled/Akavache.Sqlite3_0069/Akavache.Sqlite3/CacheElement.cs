using System;
using SQLite;

namespace Akavache.Sqlite3;

internal class CacheElement
{
	[PrimaryKey]
	public string Key { get; set; } = string.Empty;

	[Indexed]
	public string? TypeName { get; set; }

	public byte[] Value { get; set; } = Array.Empty<byte>();

	[Indexed]
	public DateTime Expiration { get; set; }

	public DateTime CreatedAt { get; set; }
}
