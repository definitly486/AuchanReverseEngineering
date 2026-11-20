using System;
using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class DateTimeConverter : DefaultTypeConverter
{
	public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		if (text == null)
		{
			return base.ConvertFromString(null, row, memberMapData);
		}
		IFormatProvider provider = ((IFormatProvider)(memberMapData.TypeConverterOptions.CultureInfo?.GetFormat(typeof(DateTimeFormatInfo)))) ?? memberMapData.TypeConverterOptions.CultureInfo;
		DateTimeStyles valueOrDefault = memberMapData.TypeConverterOptions.DateTimeStyle.GetValueOrDefault();
		if (!((memberMapData.TypeConverterOptions.Formats == null || memberMapData.TypeConverterOptions.Formats.Length == 0) ? DateTime.TryParse(text, provider, valueOrDefault, out var result) : DateTime.TryParseExact(text, memberMapData.TypeConverterOptions.Formats, provider, valueOrDefault, out result)))
		{
			return base.ConvertFromString(text, row, memberMapData);
		}
		return result;
	}
}
