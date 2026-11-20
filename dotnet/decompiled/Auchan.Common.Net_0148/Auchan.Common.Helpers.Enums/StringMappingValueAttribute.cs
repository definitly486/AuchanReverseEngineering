using System;

namespace Auchan.Common.Helpers.Enums;

public class StringMappingValueAttribute : Attribute
{
	private readonly string _value;

	public string Value => _value;

	public StringMappingValueAttribute(string value)
	{
		_value = value;
	}
}
