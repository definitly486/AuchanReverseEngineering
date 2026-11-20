using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class CacheFieldsAttribute : Attribute, IClassMapper
{
	public bool CacheFields { get; private set; }

	public CacheFieldsAttribute(bool cacheFields = true)
	{
		CacheFields = cacheFields;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.CacheFields = CacheFields;
	}
}
