using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class HasHeaderRecordAttribute : Attribute, IClassMapper
{
	public bool HasHeaderRecord { get; private set; }

	public HasHeaderRecordAttribute(bool hasHeaderRecord = true)
	{
		HasHeaderRecord = hasHeaderRecord;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.HasHeaderRecord = HasHeaderRecord;
	}
}
