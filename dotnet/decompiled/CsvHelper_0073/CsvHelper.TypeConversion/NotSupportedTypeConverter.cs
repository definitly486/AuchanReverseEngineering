using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public class NotSupportedTypeConverter<T> : TypeConverter<T>
{
	public override T ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		string message = "Converting " + typeof(T).FullName + " is not supported. If you want to do this, create your own ITypeConverter and register it in the TypeConverterFactory by calling AddConverter.";
		throw new TypeConverterException(this, memberMapData, text ?? string.Empty, row.Context, message);
	}

	public override string? ConvertToString(T? value, IWriterRow row, MemberMapData memberMapData)
	{
		string message = "Converting " + typeof(T).FullName + " is not supported. If you want to do this, create your own ITypeConverter and register it in the TypeConverterFactory by calling AddConverter.";
		throw new TypeConverterException(this, memberMapData, value, row.Context, message);
	}
}
