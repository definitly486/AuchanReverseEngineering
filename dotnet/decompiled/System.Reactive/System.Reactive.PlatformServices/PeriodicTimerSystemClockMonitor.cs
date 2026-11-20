using System.ComponentModel;

namespace System.Reactive.PlatformServices;

[EditorBrowsable(EditorBrowsableState.Never)]
public class PeriodicTimerSystemClockMonitor : INotifySystemClockChanged
{
	private readonly TimeSpan _period;

	public PeriodicTimerSystemClockMonitor(TimeSpan period)
	{
		_period = period;
	}
}
