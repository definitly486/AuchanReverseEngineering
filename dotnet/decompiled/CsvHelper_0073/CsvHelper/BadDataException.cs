using System;

namespace CsvHelper;

[Serializable]
public class BadDataException : CsvHelperException
{
	public readonly string Field;

	public readonly string RawRecord;

	public BadDataException(string field, string rawRecord, CsvContext context)
		: base(context)
	{
		Field = field;
		RawRecord = rawRecord;
	}

	public BadDataException(string field, string rawRecord, CsvContext context, string message)
		: base(context, message)
	{
		Field = field;
		RawRecord = rawRecord;
	}

	public BadDataException(string field, string rawRecord, CsvContext context, string message, Exception innerException)
		: base(context, message, innerException)
	{
		Field = field;
		RawRecord = rawRecord;
	}
}
