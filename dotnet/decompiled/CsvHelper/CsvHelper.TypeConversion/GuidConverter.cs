using System;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class GuidConverter : DefaultTypeConverter
{
	public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		if (Guid.TryParse(text, out var result))
		{
			return result;
		}
		return base.ConvertFromString(text, row, memberMapData);
	}
}
