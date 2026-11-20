using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Refit;

public class DefaultUrlParameterFormatter : IUrlParameterFormatter
{
	private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute?>> EnumMemberCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>>();

	private Dictionary<(Type containerType, Type parameterType), string> SpecificFormats { get; } = new Dictionary<(Type, Type), string>();

	private Dictionary<Type, string> GeneralFormats { get; } = new Dictionary<Type, string>();

	public void AddFormat<TContainer, TParameter>(string format)
	{
		SpecificFormats.Add((typeof(TContainer), typeof(TParameter)), format);
	}

	public void AddFormat<TParameter>(string format)
	{
		GeneralFormats.Add(typeof(TParameter), format);
	}

	public virtual string? Format(object? parameterValue, ICustomAttributeProvider attributeProvider, Type type)
	{
		if (attributeProvider == null)
		{
			throw new ArgumentNullException("attributeProvider");
		}
		if (parameterValue == null)
		{
			return null;
		}
		string text = attributeProvider.GetCustomAttributes(typeof(QueryAttribute), inherit: true).OfType<QueryAttribute>().FirstOrDefault()?.Format;
		EnumMemberAttribute enumMemberAttribute = null;
		Type parameterType = parameterValue.GetType();
		if (parameterType.IsEnum)
		{
			enumMemberAttribute = EnumMemberCache.GetOrAdd(parameterType, (Type t) => new ConcurrentDictionary<string, EnumMemberAttribute>()).GetOrAdd(parameterValue.ToString(), (string val) => parameterType.GetMember(val).First().GetCustomAttribute<EnumMemberAttribute>());
		}
		if (string.IsNullOrWhiteSpace(text) && SpecificFormats.TryGetValue((type, parameterType), out string value))
		{
			text = value;
		}
		if (string.IsNullOrWhiteSpace(text) && GeneralFormats.TryGetValue(parameterType, out string value2))
		{
			text = value2;
		}
		return string.Format(CultureInfo.InvariantCulture, string.IsNullOrWhiteSpace(text) ? "{0}" : ("{0:" + text + "}"), enumMemberAttribute?.Value ?? parameterValue);
	}
}
