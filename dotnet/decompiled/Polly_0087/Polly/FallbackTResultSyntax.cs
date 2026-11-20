using System;
using System.Threading;
using Polly.Fallback;

namespace Polly;

public static class FallbackTResultSyntax
{
	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue)
	{
		return policyBuilder.Fallback(() => fallbackValue, EmptyAction);
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<TResult> fallbackAction)
	{
		return policyBuilder.Fallback(fallbackAction, EmptyAction);
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, TResult> fallbackAction)
	{
		return policyBuilder.Fallback(fallbackAction, EmptyAction);
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Action<DelegateResult<TResult>> onFallback)
	{
		if (onFallback == null)
		{
			throw new ArgumentNullException("onFallback");
		}
		return policyBuilder.Fallback((DelegateResult<TResult> _, Context _, CancellationToken _) => fallbackValue, delegate(DelegateResult<TResult> outcome, Context _)
		{
			onFallback(outcome);
		});
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<TResult> fallbackAction, Action<DelegateResult<TResult>> onFallback)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		if (onFallback == null)
		{
			throw new ArgumentNullException("onFallback");
		}
		return policyBuilder.Fallback((DelegateResult<TResult> _, Context _, CancellationToken _) => fallbackAction(), delegate(DelegateResult<TResult> outcome, Context _)
		{
			onFallback(outcome);
		});
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, TResult> fallbackAction, Action<DelegateResult<TResult>> onFallback)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		if (onFallback == null)
		{
			throw new ArgumentNullException("onFallback");
		}
		return policyBuilder.Fallback((DelegateResult<TResult> _, Context _, CancellationToken ct) => fallbackAction(ct), delegate(DelegateResult<TResult> outcome, Context _)
		{
			onFallback(outcome);
		});
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Action<DelegateResult<TResult>, Context> onFallback)
	{
		if (onFallback == null)
		{
			throw new ArgumentNullException("onFallback");
		}
		return policyBuilder.Fallback((DelegateResult<TResult> _, Context _, CancellationToken _) => fallbackValue, onFallback);
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<Context, TResult> fallbackAction, Action<DelegateResult<TResult>, Context> onFallback)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		return policyBuilder.Fallback((DelegateResult<TResult> _, Context ctx, CancellationToken _) => fallbackAction(ctx), onFallback);
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<Context, CancellationToken, TResult> fallbackAction, Action<DelegateResult<TResult>, Context> onFallback)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		return policyBuilder.Fallback((DelegateResult<TResult> _, Context ctx, CancellationToken ct) => fallbackAction(ctx, ct), onFallback);
	}

	public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, CancellationToken, TResult> fallbackAction, Action<DelegateResult<TResult>, Context> onFallback)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		if (onFallback == null)
		{
			throw new ArgumentNullException("onFallback");
		}
		return new FallbackPolicy<TResult>(policyBuilder, onFallback, fallbackAction);
	}

	private static void EmptyAction<T>(DelegateResult<T> result)
	{
	}
}
