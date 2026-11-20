using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class DelimiterAttribute : Attribute, IClassMapper
{
	public string Delimiter { get; private set; }

	public DelimiterAttribute(string delimiter)
	{
		Delimiter = delimiter;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.Delimiter = Delimiter;
	}
}
