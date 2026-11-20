using System;
using Polly.Utilities;

namespace Polly.CircuitBreaker;

internal sealed class SingleHealthMetrics : IHealthMetrics
{
	private readonly long _samplingDuration;

	private HealthCount? _current;

	public SingleHealthMetrics(TimeSpan samplingDuration)
	{
		_samplingDuration = samplingDuration.Ticks;
	}

	public void IncrementSuccess_NeedsLock()
	{
		ActualiseCurrentMetric_NeedsLock().Successes++;
	}

	public void IncrementFailure_NeedsLock()
	{
		ActualiseCurrentMetric_NeedsLock().Failures++;
	}

	public void Reset_NeedsLock()
	{
		_current = null;
	}

	public HealthCount GetHealthCount_NeedsLock()
	{
		return ActualiseCurrentMetric_NeedsLock();
	}

	private HealthCount ActualiseCurrentMetric_NeedsLock()
	{
		long ticks = SystemClock.UtcNow().Ticks;
		if (_current == null || ticks - _current.StartedAt >= _samplingDuration)
		{
			_current = new HealthCount
			{
				StartedAt = ticks
			};
		}
		return _current;
	}
}
