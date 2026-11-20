using System;
using JetBrains.Annotations;

namespace NLog.Config;

[AttributeUsage(AttributeTargets.Property)]
[MeansImplicitUse]
public sealed class ArrayParameterAttribute : Attribute
{
	public Type ItemType { get; }

	public string ElementName { get; }

	public ArrayParameterAttribute(Type itemType, string elementName)
	{
		ItemType = itemType;
		ElementName = elementName;
	}
}
