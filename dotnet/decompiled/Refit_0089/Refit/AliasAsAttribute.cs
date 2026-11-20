using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
public class AliasAsAttribute(string name) : Attribute()
{
	public string Name { get; protected set; } = name;
}
