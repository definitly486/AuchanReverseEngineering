using System;
using NLog.Config;

namespace NLog.Time;

[AttributeUsage(AttributeTargets.Class)]
public sealed class TimeSourceAttribute : NameBaseAttribute
{
	public TimeSourceAttribute(string name)
		: base(name)
	{
	}
}
