using System;
using System.Text.RegularExpressions;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class DetectDelimiterValuesAttribute : Attribute, IClassMapper
{
	public string[] DetectDelimiterValues { get; private set; }

	public DetectDelimiterValuesAttribute(string detectDelimiterValues)
	{
		DetectDelimiterValues = Regex.Split(detectDelimiterValues, "\\s+");
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.DetectDelimiterValues = DetectDelimiterValues;
	}
}
