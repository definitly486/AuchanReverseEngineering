using System;
using JetBrains.Annotations;

namespace NLog.Config;

[MeansImplicitUse]
public abstract class NameBaseAttribute : Attribute
{
	public string Name { get; }

	protected NameBaseAttribute(string name)
	{
		Name = name;
	}
}
