using System;
using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class TimeSpanConverter : DefaultTypeConverter
{
	public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		IFormatProvider cultureInfo = memberMapData.TypeConverterOptions.CultureInfo;
		IFormatProvider formatProvider = cultureInfo ?? memberMapData.TypeConverterOptions.CultureInfo;
		TimeSpanStyles valueOrDefault = memberMapData.TypeConverterOptions.TimeSpanStyle.GetValueOrDefault();
		if (memberMapData.TypeConverterOptions.Formats != null && TimeSpan.TryParseExact(text, memberMapData.TypeConverterOptions.Formats, formatProvider, valueOrDefault, out var result))
		{
			return result;
		}
		if (memberMapData.TypeConverterOptions.Formats == null && TimeSpan.TryParse(text, formatProvider, out result))
		{
			return result;
		}
		return base.ConvertFromString(text, row, memberMapData);
	}
}
