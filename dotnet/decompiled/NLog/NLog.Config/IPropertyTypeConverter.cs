using System;

namespace NLog.Config;

public interface IPropertyTypeConverter
{
	object? Convert(object? propertyValue, Type propertyType, string? format, IFormatProvider? formatProvider);
}
