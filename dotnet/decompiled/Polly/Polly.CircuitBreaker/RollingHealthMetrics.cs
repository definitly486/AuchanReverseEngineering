using System;
using System.Collections.Generic;
using Polly.Utilities;

namespace Polly.CircuitBreaker;

internal sealed class RollingHealthMetrics : IHealthMetrics
{
	internal const short WindowCount = 10;

	private readonly long _samplingDuration;

	private readonly long _windowDuration;

	private readonly Queue<HealthCount> _windows;

	private HealthCount? _currentWindow;

	public RollingHealthMetrics(TimeSpan samplingDuration)
	{
		_samplingDuration = samplingDuration.Ticks;
		_windowDuration = _samplingDuration / 10;
		_windows = new Queue<HealthCount>(11);
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
		_currentWindow = null;
		_windows.Clear();
	}

	public HealthCount GetHealthCount_NeedsLock()
	{
		ActualiseCurrentMetric_NeedsLock();
		int num = 0;
		int num2 = 0;
		foreach (HealthCount window in _windows)
		{
			num += window.Successes;
			num2 += window.Failures;
		}
		return new HealthCount
		{
			Successes = num,
			Failures = num2,
			StartedAt = _windows.Peek().StartedAt
		};
	}

	private HealthCount ActualiseCurrentMetric_NeedsLock()
	{
		long ticks = SystemClock.UtcNow().Ticks;
		HealthCount healthCount = _currentWindow;
		if (healthCount == null || ticks - healthCount.StartedAt >= _windowDuration)
		{
			HealthCount obj = new HealthCount
			{
				StartedAt = ticks
			};
			healthCount = obj;
			_currentWindow = obj;
			_windows.Enqueue(healthCount);
		}
		while (_windows.Count > 0 && ticks - _windows.Peek().StartedAt >= _samplingDuration)
		{
			_windows.Dequeue();
		}
		return healthCount;
	}
}
