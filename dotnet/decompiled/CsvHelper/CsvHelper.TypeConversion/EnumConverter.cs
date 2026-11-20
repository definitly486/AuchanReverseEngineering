using System;
using System.Collections.Generic;
using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace CsvHelper.TypeConversion;

public class EnumConverter : DefaultTypeConverter
{
	private readonly Type type;

	private readonly Dictionary<string, string> enumNamesByAttributeNames = new Dictionary<string, string>();

	private readonly Dictionary<string, string> enumNamesByAttributeNamesIgnoreCase = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<object, string> attributeNamesByEnumValues = new Dictionary<object, string>();

	public EnumConverter(Type type)
	{
		if (!typeof(Enum).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
		{
			throw new ArgumentException("'" + type.FullName + "' is not an Enum.");
		}
		this.type = type;
		foreach (object value in Enum.GetValues(type))
		{
			string text = Enum.GetName(type, value) ?? string.Empty;
			NameAttribute nameAttribute = type.GetField(text)?.GetCustomAttribute<NameAttribute>();
			if (nameAttribute == null || nameAttribute.Names.Length == 0)
			{
				continue;
			}
			string[] names = nameAttribute.Names;
			foreach (string text2 in names)
			{
				if (!enumNamesByAttributeNames.ContainsKey(text2))
				{
					enumNamesByAttributeNames.Add(text2, text);
				}
				if (!enumNamesByAttributeNamesIgnoreCase.ContainsKey(text2))
				{
					enumNamesByAttributeNamesIgnoreCase.Add(text2, text);
				}
				if (!attributeNamesByEnumValues.ContainsKey(value))
				{
					attributeNamesByEnumValues.Add(value, text2);
				}
			}
		}
	}

	public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		bool valueOrDefault = memberMapData.TypeConverterOptions.EnumIgnoreCase == true;
		if (text != null && (valueOrDefault ? enumNamesByAttributeNamesIgnoreCase : enumNamesByAttributeNames).TryGetValue(text, out string value))
		{
			return Enum.Parse(type, value);
		}
		if (Enum.TryParse(type, text, valueOrDefault, out object result))
		{
			return result;
		}
		return base.ConvertFromString(text, row, memberMapData);
	}

	public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
	{
		if (value != null && attributeNamesByEnumValues.TryGetValue(value, out string value2))
		{
			return value2;
		}
		return base.ConvertToString(value, row, memberMapData);
	}
}
