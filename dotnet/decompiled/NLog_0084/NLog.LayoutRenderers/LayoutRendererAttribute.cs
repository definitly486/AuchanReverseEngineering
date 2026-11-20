using System;
using NLog.Config;

namespace NLog.LayoutRenderers;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class LayoutRendererAttribute : NameBaseAttribute
{
	public LayoutRendererAttribute(string name)
		: base(name)
	{
	}
}
