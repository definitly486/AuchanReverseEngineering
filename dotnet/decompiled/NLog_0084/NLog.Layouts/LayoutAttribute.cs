using System;
using NLog.Config;

namespace NLog.Layouts;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class LayoutAttribute : NameBaseAttribute
{
	public LayoutAttribute(string name)
		: base(name)
	{
	}
}
