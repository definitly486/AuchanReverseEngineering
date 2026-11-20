using System;
using NLog.Config;

namespace NLog.Filters;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class FilterAttribute : NameBaseAttribute
{
	public FilterAttribute(string name)
		: base(name)
	{
	}
}
