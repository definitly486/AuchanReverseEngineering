using System;

namespace CsvHelper;

[Serializable]
public class MaxFieldSizeException : CsvHelperException
{
	public MaxFieldSizeException(CsvContext context)
		: base(context)
	{
	}

	public MaxFieldSizeException(CsvContext context, string message)
		: base(context, message)
	{
	}

	public MaxFieldSizeException(CsvContext context, string message, Exception innerException)
		: base(context, message, innerException)
	{
	}
}
