using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class DetectDelimiterAttribute : Attribute, IClassMapper
{
	public bool DetectDelimiter { get; private set; }

	public DetectDelimiterAttribute(bool detectDelimiter = true)
	{
		DetectDelimiter = detectDelimiter;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.DetectDelimiter = DetectDelimiter;
	}
}
