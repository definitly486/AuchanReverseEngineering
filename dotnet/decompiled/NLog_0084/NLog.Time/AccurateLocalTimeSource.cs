using System;

namespace NLog.Time;

[TimeSource("AccurateLocal")]
public sealed class AccurateLocalTimeSource : TimeSource
{
	public override DateTime Time => DateTime.Now;

	public override DateTime FromSystemTime(DateTime systemTime)
	{
		return systemTime.ToLocalTime();
	}
}
