using System;

namespace CsvHelper.TypeConversion;

public interface ITypeConverterFactory
{
	bool CanCreate(Type type);

	bool Create(Type type, TypeConverterCache cache, out ITypeConverter typeConverter);
}
