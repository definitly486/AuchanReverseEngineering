using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public abstract class TypeConverter<T> : ITypeConverter
{
	public abstract T? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData);

	public abstract string? ConvertToString(T? value, IWriterRow row, MemberMapData memberMapData);

	object? ITypeConverter.ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		return ConvertFromString(text, row, memberMapData);
	}

	string? ITypeConverter.ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
	{
		return ConvertToString((T)value, row, memberMapData);
	}
}
