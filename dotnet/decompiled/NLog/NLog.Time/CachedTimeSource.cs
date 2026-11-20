using System;
using System.Threading;

namespace NLog.Time;

public abstract class CachedTimeSource : TimeSource
{
	private int _lastTicks = -1;

	private DateTime _lastTime = DateTime.MinValue;

	protected abstract DateTime FreshTime { get; }

	public override DateTime Time
	{
		get
		{
			int tickCount = Environment.TickCount;
			if (tickCount != _lastTicks)
			{
				return RetrieveFreshTime(tickCount);
			}
			return _lastTime;
		}
	}

	private DateTime RetrieveFreshTime(int tickCount)
	{
		DateTime result = (_lastTime = FreshTime);
		Thread.MemoryBarrier();
		_lastTicks = tickCount;
		return result;
	}
}
