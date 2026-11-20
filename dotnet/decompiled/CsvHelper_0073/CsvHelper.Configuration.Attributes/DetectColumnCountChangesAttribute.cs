using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class DetectColumnCountChangesAttribute : Attribute, IClassMapper
{
	public bool DetectColumnCountChanges { get; private set; }

	public DetectColumnCountChangesAttribute(bool detectColumnCountChanges = true)
	{
		DetectColumnCountChanges = detectColumnCountChanges;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.DetectColumnCountChanges = DetectColumnCountChanges;
	}
}
