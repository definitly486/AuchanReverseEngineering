using System;

namespace CsvHelper.TypeConversion;

public class EnumConverterFactory : ITypeConverterFactory
{
	public bool CanCreate(Type type)
	{
		return typeof(Enum).IsAssignableFrom(type);
	}

	public bool Create(Type type, TypeConverterCache cache, out ITypeConverter typeConverter)
	{
		if (cache.Contains(typeof(Enum)))
		{
			typeConverter = cache.GetConverter<Enum>();
			return false;
		}
		typeConverter = new EnumConverter(type);
		return true;
	}
}
