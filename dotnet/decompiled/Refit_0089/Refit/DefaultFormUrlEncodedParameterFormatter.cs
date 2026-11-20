using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Refit;

public class DefaultFormUrlEncodedParameterFormatter : IFormUrlEncodedParameterFormatter
{
	private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute?>> EnumMemberCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>>();

	public virtual string? Format(object? parameterValue, string? formatString)
	{
		if (parameterValue == null)
		{
			return null;
		}
		Type parameterType = parameterValue.GetType();
		EnumMemberAttribute enumMemberAttribute = null;
		if (parameterType.GetTypeInfo().IsEnum)
		{
			enumMemberAttribute = EnumMemberCache.GetOrAdd(parameterType, (Type t) => new ConcurrentDictionary<string, EnumMemberAttribute>()).GetOrAdd(parameterValue.ToString(), (string val) => parameterType.GetMember(val).First().GetCustomAttribute<EnumMemberAttribute>());
		}
		return string.Format(CultureInfo.InvariantCulture, string.IsNullOrWhiteSpace(formatString) ? "{0}" : ("{0:" + formatString + "}"), enumMemberAttribute?.Value ?? parameterValue);
	}
}
