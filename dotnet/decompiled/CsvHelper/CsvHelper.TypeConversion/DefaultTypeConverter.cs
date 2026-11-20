using System;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class DefaultTypeConverter : ITypeConverter
{
	public virtual object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		if (!memberMapData.UseDefaultOnConversionFailure || !memberMapData.IsDefaultSet)
		{
			throw CreateTypeConverterException(text, row, memberMapData);
		}
		Type type = memberMapData.Member.MemberType();
		if (memberMapData.Default == null)
		{
			if (TypeAllowsNull(type))
			{
				return null;
			}
		}
		else if (type.IsAssignableFrom(memberMapData.Default.GetType()))
		{
			return memberMapData.Default;
		}
		throw CreateTypeConverterException(text, row, memberMapData);
	}

	public virtual string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
	{
		if (value == null)
		{
			if (memberMapData.TypeConverterOptions.NullValues.Count > 0)
			{
				return memberMapData.TypeConverterOptions.NullValues.First();
			}
			return string.Empty;
		}
		if (!(value is IFormattable formattable))
		{
			return value?.ToString() ?? string.Empty;
		}
		string text = memberMapData.TypeConverterOptions.Formats?.FirstOrDefault();
		return formattable.ToString(text, memberMapData.TypeConverterOptions.CultureInfo);
	}

	private TypeConverterException CreateTypeConverterException(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		if (!row.Configuration.ExceptionMessagesContainRawData)
		{
			text = "Hidden because ExceptionMessagesContainRawData is false.";
		}
		if (text == null)
		{
			text = string.Empty;
		}
		string message = $"The conversion cannot be performed.{"\n"}    Text: '{text}'{"\n"}    MemberName: {memberMapData.Member?.Name}{"\n"}    MemberType: {memberMapData.Member?.MemberType().FullName}{"\n"}    TypeConverter: '{memberMapData.TypeConverter?.GetType().FullName}'";
		return new TypeConverterException(this, memberMapData, text, row.Context, message);
	}

	private static bool TypeAllowsNull(Type type)
	{
		if (type.IsValueType)
		{
			return (object)Nullable.GetUnderlyingType(type) != null;
		}
		return true;
	}
}
