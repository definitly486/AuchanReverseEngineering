using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class EscapeAttribute : Attribute, IClassMapper
{
	public char Escape { get; private set; }

	public EscapeAttribute(char escape)
	{
		Escape = escape;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.Escape = Escape;
	}
}
