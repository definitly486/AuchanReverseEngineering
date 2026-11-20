using System;
using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class DateOnlyConverter : DefaultTypeConverter
{
	public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		if (text == null)
		{
			return base.ConvertFromString(null, row, memberMapData);
		}
		IFormatProvider provider = ((IFormatProvider)(memberMapData.TypeConverterOptions.CultureInfo?.GetFormat(typeof(DateTimeFormatInfo)))) ?? memberMapData.TypeConverterOptions.CultureInfo;
		DateTimeStyles valueOrDefault = memberMapData.TypeConverterOptions.DateTimeStyle.GetValueOrDefault();
		return (memberMapData.TypeConverterOptions.Formats == null || memberMapData.TypeConverterOptions.Formats.Length == 0) ? DateOnly.Parse(text, provider, valueOrDefault) : DateOnly.ParseExact(text, memberMapData.TypeConverterOptions.Formats, provider, valueOrDefault);
	}
}
