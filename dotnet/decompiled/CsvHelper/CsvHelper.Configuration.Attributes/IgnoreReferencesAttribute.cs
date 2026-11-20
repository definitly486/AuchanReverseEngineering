using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class IgnoreReferencesAttribute : Attribute, IClassMapper
{
	public bool IgnoreReferences { get; private set; }

	public IgnoreReferencesAttribute(bool ignoreReferences = true)
	{
		IgnoreReferences = ignoreReferences;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.IgnoreReferences = IgnoreReferences;
	}
}
