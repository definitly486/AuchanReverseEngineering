using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class LineBreakInQuotedFieldIsBadDataAttribute : Attribute, IClassMapper
{
	public bool LineBreakInQuotedFieldIsBadData { get; private set; }

	public LineBreakInQuotedFieldIsBadDataAttribute(bool lineBreakInQuotedFieldIsBadData = true)
	{
		LineBreakInQuotedFieldIsBadData = lineBreakInQuotedFieldIsBadData;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.LineBreakInQuotedFieldIsBadData = LineBreakInQuotedFieldIsBadData;
	}
}
