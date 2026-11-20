using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class IgnoreBlankLinesAttribute : Attribute, IClassMapper
{
	public bool IgnoreBlankLines { get; private set; }

	public IgnoreBlankLinesAttribute(bool ignoreBlankLines = true)
	{
		IgnoreBlankLines = ignoreBlankLines;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.IgnoreBlankLines = IgnoreBlankLines;
	}
}
