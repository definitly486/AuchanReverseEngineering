using System;
using Polly.CircuitBreaker;

namespace Polly;

public static class AsyncCircuitBreakerTResultSyntax
{
	public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak)
	{
		return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, (Action<DelegateResult<TResult>, TimeSpan>)delegate
		{
		}, (Action)delegate
		{
		});
	}

	public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset)
	{
		return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context _)
		{
			onBreak(outcome, timespan);
		}, delegate
		{
			onReset();
		});
	}

	public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset)
	{
		return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, delegate
		{
		});
	}

	public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
	{
		return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context _)
		{
			onBreak(outcome, timespan);
		}, delegate
		{
			onReset();
		}, onHalfOpen);
	}

	public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
	{
		return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, CircuitState _, TimeSpan timespan, Context context)
		{
			onBreak(outcome, timespan, context);
		}, onReset, onHalfOpen);
	}

	public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
	{
		if (handledEventsAllowedBeforeBreaking <= 0)
		{
			throw new ArgumentOutOfRangeException("handledEventsAllowedBeforeBreaking", "Value must be greater than zero.");
		}
		if (durationOfBreak < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
		}
		if (onBreak == null)
		{
			throw new ArgumentNullException("onBreak");
		}
		if (onReset == null)
		{
			throw new ArgumentNullException("onReset");
		}
		if (onHalfOpen == null)
		{
			throw new ArgumentNullException("onHalfOpen");
		}
		ConsecutiveCountCircuitController<TResult> breakerController = new ConsecutiveCountCircuitController<TResult>(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
		return new AsyncCircuitBreakerPolicy<TResult>(policyBuilder, breakerController);
	}
}
