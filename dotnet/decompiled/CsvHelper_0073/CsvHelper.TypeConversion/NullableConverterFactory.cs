using System;

namespace CsvHelper.TypeConversion;

public class NullableConverterFactory : ITypeConverterFactory
{
	public bool CanCreate(Type type)
	{
		if (type.IsGenericType)
		{
			return type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
		}
		return false;
	}

	public bool Create(Type type, TypeConverterCache cache, out ITypeConverter typeConverter)
	{
		typeConverter = new NullableConverter(type, cache);
		return true;
	}
}
