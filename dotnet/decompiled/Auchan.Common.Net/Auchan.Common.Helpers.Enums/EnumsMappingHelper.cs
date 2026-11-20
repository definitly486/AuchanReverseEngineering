using System;
using System.Reflection;

namespace Auchan.Common.Helpers.Enums;

public static class EnumsMappingHelper
{
	public static T GetMappedValue<T>(this string mappingSource, T defaultResult) where T : struct, IConvertible
	{
		MemberInfo[] members = typeof(T).GetMembers();
		foreach (MemberInfo memberInfo in members)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(typeof(StringMappingValueAttribute), inherit: false);
			if (customAttributes != null && customAttributes.Length != 0 && customAttributes[0] is StringMappingValueAttribute stringMappingValueAttribute && stringMappingValueAttribute.Value.Equals(mappingSource, StringComparison.InvariantCultureIgnoreCase))
			{
				return (T)Enum.Parse(typeof(T), memberInfo.Name);
			}
		}
		return defaultResult;
	}
}
