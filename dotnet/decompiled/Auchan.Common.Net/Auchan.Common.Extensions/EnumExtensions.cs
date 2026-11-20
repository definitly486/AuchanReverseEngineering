using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Auchan.Common.Extensions;

public static class EnumExtensions
{
	public static string GetDescription<T>(this T source) where T : Enum
	{
		DescriptionAttribute[] array = (DescriptionAttribute[])(source.GetType().GetField(source.ToString()) ?? throw new ArgumentException($"field {source} isn't found", "source")).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
		if (array == null || array.Length == 0)
		{
			return source.ToString();
		}
		return array[0].Description;
	}

	public static string? GetEnumMemberValue<T>(this T value) where T : Enum
	{
		return typeof(T).GetTypeInfo().DeclaredMembers.SingleOrDefault((MemberInfo x) => x.Name == value.ToString())?.GetCustomAttribute<EnumMemberAttribute>(inherit: false)?.Value;
	}
}
