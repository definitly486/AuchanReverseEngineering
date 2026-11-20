using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class TrimOptionsAttribute : Attribute, IClassMapper
{
	public TrimOptions TrimOptions { get; private set; }

	public TrimOptionsAttribute(TrimOptions trimOptions)
	{
		TrimOptions = trimOptions;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.TrimOptions = TrimOptions;
	}
}
