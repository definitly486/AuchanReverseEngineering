using System;

namespace Akavache;

public class CacheEntry
{
	public DateTimeOffset CreatedAt { get; protected set; }

	public DateTimeOffset? ExpiresAt { get; protected set; }

	public string? TypeName { get; protected set; }

	public byte[] Value { get; protected set; }

	public CacheEntry(string? typeName, byte[] value, DateTimeOffset createdAt, DateTimeOffset? expiresAt)
	{
		CreatedAt = createdAt;
		ExpiresAt = expiresAt;
		TypeName = typeName;
		Value = value;
		base._002Ector();
	}
}
