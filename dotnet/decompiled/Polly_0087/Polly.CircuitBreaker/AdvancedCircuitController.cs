using System;
using Polly.Utilities;

namespace Polly.CircuitBreaker;

internal sealed class AdvancedCircuitController<TResult> : CircuitStateController<TResult>
{
	internal static readonly long ResolutionOfCircuitTimer = TimeSpan.FromMilliseconds(20.0).Ticks;

	private readonly IHealthMetrics _metrics;

	private readonly double _failureThreshold;

	private readonly int _minimumThroughput;

	internal IHealthMetrics Metrics => _metrics;

	public AdvancedCircuitController(double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		: base(durationOfBreak, onBreak, onReset, onHalfOpen)
	{
		IHealthMetrics metrics;
		if (samplingDuration.Ticks >= ResolutionOfCircuitTimer * 10)
		{
			IHealthMetrics healthMetrics = new RollingHealthMetrics(samplingDuration);
			metrics = healthMetrics;
		}
		else
		{
			IHealthMetrics healthMetrics = new SingleHealthMetrics(samplingDuration);
			metrics = healthMetrics;
		}
		_metrics = metrics;
		_failureThreshold = failureThreshold;
		_minimumThroughput = minimumThroughput;
	}

	public override void OnCircuitReset(Context context)
	{
		using (TimedLock.Lock(Lock))
		{
			_metrics?.Reset_NeedsLock();
			ResetInternal_NeedsLock(context);
		}
	}

	public override void OnActionSuccess(Context context)
	{
		using (TimedLock.Lock(Lock))
		{
			switch (InternalCircuitState)
			{
			case CircuitState.HalfOpen:
				OnCircuitReset(context);
				break;
			default:
				throw new InvalidOperationException("Unhandled CircuitState.");
			case CircuitState.Closed:
			case CircuitState.Open:
			case CircuitState.Isolated:
				break;
			}
			_metrics.IncrementSuccess_NeedsLock();
		}
	}

	public override void OnActionFailure(DelegateResult<TResult> outcome, Context context)
	{
		using (TimedLock.Lock(Lock))
		{
			LastOutcome = outcome;
			switch (InternalCircuitState)
			{
			case CircuitState.HalfOpen:
				Break_NeedsLock(context);
				break;
			case CircuitState.Closed:
			{
				_metrics.IncrementFailure_NeedsLock();
				HealthCount healthCount_NeedsLock = _metrics.GetHealthCount_NeedsLock();
				int total = healthCount_NeedsLock.Total;
				if (total >= _minimumThroughput && (double)healthCount_NeedsLock.Failures / (double)total >= _failureThreshold)
				{
					Break_NeedsLock(context);
				}
				break;
			}
			case CircuitState.Open:
			case CircuitState.Isolated:
				_metrics.IncrementFailure_NeedsLock();
				break;
			default:
				throw new InvalidOperationException("Unhandled CircuitState.");
			}
		}
	}
}
