using System;
using NLog.Config;

namespace NLog.LayoutRenderers;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AmbientPropertyAttribute : NameBaseAttribute
{
	public AmbientPropertyAttribute(string name)
		: base(name)
	{
	}
}
