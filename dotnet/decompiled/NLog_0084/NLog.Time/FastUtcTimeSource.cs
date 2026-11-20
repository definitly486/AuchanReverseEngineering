using System;

namespace NLog.Time;

[TimeSource("FastUTC")]
public sealed class FastUtcTimeSource : CachedTimeSource
{
	protected override DateTime FreshTime => DateTime.UtcNow;

	public override DateTime FromSystemTime(DateTime systemTime)
	{
		return systemTime.ToUniversalTime();
	}
}
