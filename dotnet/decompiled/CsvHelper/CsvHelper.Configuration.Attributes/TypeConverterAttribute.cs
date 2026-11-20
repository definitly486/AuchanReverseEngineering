using System;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public class TypeConverterAttribute : Attribute, IMemberMapper, IParameterMapper
{
	public ITypeConverter TypeConverter { get; private set; }

	public TypeConverterAttribute(Type typeConverterType)
		: this(typeConverterType, new object[0])
	{
	}

	public TypeConverterAttribute(Type typeConverterType, params object[] constructorArgs)
	{
		if (typeConverterType == null)
		{
			throw new ArgumentNullException("typeConverterType");
		}
		TypeConverter = (ObjectResolver.Current.Resolve(typeConverterType, constructorArgs) as ITypeConverter) ?? throw new ArgumentException("Type '" + typeConverterType.FullName + "' does not implement ITypeConverter");
	}

	public void ApplyTo(MemberMap memberMap)
	{
		memberMap.Data.TypeConverter = TypeConverter;
	}

	public void ApplyTo(ParameterMap parameterMap)
	{
		parameterMap.Data.TypeConverter = TypeConverter;
	}
}
