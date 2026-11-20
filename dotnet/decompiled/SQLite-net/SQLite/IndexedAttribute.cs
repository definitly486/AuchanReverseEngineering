using System;

namespace SQLite;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class IndexedAttribute : Attribute
{
	public string Name { get; }

	public int Order { get; }

	public virtual bool Unique { get; }
}
