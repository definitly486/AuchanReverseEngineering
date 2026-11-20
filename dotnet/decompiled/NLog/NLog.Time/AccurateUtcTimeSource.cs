using System;

namespace NLog.Time;

[TimeSource("AccurateUTC")]
public sealed class AccurateUtcTimeSource : TimeSource
{
	public override DateTime Time => DateTime.UtcNow;

	public override DateTime FromSystemTime(DateTime systemTime)
	{
		return systemTime.ToUniversalTime();
	}
}
