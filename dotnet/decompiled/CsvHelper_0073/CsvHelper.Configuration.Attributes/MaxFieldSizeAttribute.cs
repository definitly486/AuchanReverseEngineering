using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class MaxFieldSizeAttribute : Attribute, IClassMapper
{
	public double MaxFieldSize { get; private set; }

	public MaxFieldSizeAttribute(double maxFieldSize)
	{
		MaxFieldSize = maxFieldSize;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.MaxFieldSize = MaxFieldSize;
	}
}
