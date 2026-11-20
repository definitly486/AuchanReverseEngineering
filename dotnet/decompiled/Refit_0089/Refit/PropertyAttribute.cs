using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Parameter)]
public class PropertyAttribute : Attribute
{
	public string? Key { get; }

	public PropertyAttribute()
	{
	}

	public PropertyAttribute(string key)
	{
		Key = key;
	}
}
