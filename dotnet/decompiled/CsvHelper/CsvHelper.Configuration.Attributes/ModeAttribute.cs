using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ModeAttribute : Attribute, IClassMapper
{
	public CsvMode Mode { get; private set; }

	public ModeAttribute(CsvMode mode)
	{
		Mode = mode;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.Mode = Mode;
	}
}
