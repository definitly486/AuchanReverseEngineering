using System;
using NLog.Config;

namespace NLog.Targets;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class TargetAttribute : NameBaseAttribute
{
	public bool IsWrapper { get; set; }

	public bool IsCompound { get; set; }

	public TargetAttribute(string name)
		: base(name)
	{
	}
}
