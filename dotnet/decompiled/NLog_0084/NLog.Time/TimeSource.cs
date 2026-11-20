using System;
using NLog.Config;
using NLog.Internal;

namespace NLog.Time;

[NLogConfigurationItem]
public abstract class TimeSource
{
	public abstract DateTime Time { get; }

	public static TimeSource Current { get; set; } = new FastLocalTimeSource();

	public override string ToString()
	{
		TimeSourceAttribute firstCustomAttribute = GetType().GetFirstCustomAttribute<TimeSourceAttribute>();
		if (firstCustomAttribute != null)
		{
			return firstCustomAttribute.Name + " (time source)";
		}
		return GetType().Name;
	}

	public abstract DateTime FromSystemTime(DateTime systemTime);
}
