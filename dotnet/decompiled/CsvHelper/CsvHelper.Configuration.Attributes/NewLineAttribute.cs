using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class NewLineAttribute : Attribute, IClassMapper
{
	public string NewLine { get; private set; }

	public NewLineAttribute(string newLine)
	{
		NewLine = newLine;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.NewLine = NewLine;
	}
}
