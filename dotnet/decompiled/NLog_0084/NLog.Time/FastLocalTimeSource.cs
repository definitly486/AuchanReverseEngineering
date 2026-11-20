using System;

namespace NLog.Time;

[TimeSource("FastLocal")]
public sealed class FastLocalTimeSource : CachedTimeSource
{
	protected override DateTime FreshTime => DateTime.Now;

	public override DateTime FromSystemTime(DateTime systemTime)
	{
		return systemTime.ToLocalTime();
	}
}
