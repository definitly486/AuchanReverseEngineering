using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class CountBytesAttribute : Attribute, IClassMapper
{
	public bool CountBytes { get; private set; }

	public CountBytesAttribute(bool countBytes = true)
	{
		CountBytes = countBytes;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.CountBytes = CountBytes;
	}
}
