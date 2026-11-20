using System;
using Polly.CircuitBreaker;
using Polly.Utilities;

namespace Polly;

public static class AsyncCircuitBreakerSyntax
{
	public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak)
	{
		return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, (Action<Exception, TimeSpan>)delegate
		{
		}, (Action)delegate
		{
		});
	}

	public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset)
	{
		return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context _)
		{
			onBreak(exception, timespan);
		}, delegate
		{
			onReset();
		});
	}

	public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset)
	{
		return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, delegate
		{
		});
	}

	public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
	{
		return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context _)
		{
			onBreak(exception, timespan);
		}, delegate
		{
			onReset();
		}, onHalfOpen);
	}

	public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
	{
		return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, CircuitState _, TimeSpan timespan, Context context)
		{
			onBreak(exception, timespan, context);
		}, onReset, onHalfOpen);
	}

	public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
	{
		if (exceptionsAllowedBeforeBreaking <= 0)
		{
			throw new ArgumentOutOfRangeException("exceptionsAllowedBeforeBreaking", "Value must be greater than zero.");
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
		ConsecutiveCountCircuitController<EmptyStruct> breakerController = new ConsecutiveCountCircuitController<EmptyStruct>(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<EmptyStruct> outcome, CircuitState state, TimeSpan timespan, Context context)
		{
			onBreak(outcome.Exception, state, timespan, context);
		}, onReset, onHalfOpen);
		return new AsyncCircuitBreakerPolicy(policyBuilder, breakerController);
	}
}
