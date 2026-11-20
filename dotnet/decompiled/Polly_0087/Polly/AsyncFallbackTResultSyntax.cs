using System;
using System.Threading;
using System.Threading.Tasks;
using Polly.Fallback;
using Polly.Utilities;

namespace Polly;

public static class AsyncFallbackTResultSyntax
{
	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue)
	{
		return policyBuilder.FallbackAsync((CancellationToken _) => Task.FromResult(fallbackValue), (DelegateResult<TResult> _) => TaskHelper.EmptyTask);
	}

	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, Task<TResult>> fallbackAction)
	{
		return policyBuilder.FallbackAsync(fallbackAction, (DelegateResult<TResult> _) => TaskHelper.EmptyTask);
	}

	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Func<DelegateResult<TResult>, Task> onFallbackAsync)
	{
		if (onFallbackAsync == null)
		{
			throw new ArgumentNullException("onFallbackAsync");
		}
		return policyBuilder.FallbackAsync((DelegateResult<TResult> _, Context _, CancellationToken _) => Task.FromResult(fallbackValue), (DelegateResult<TResult> outcome, Context _) => onFallbackAsync(outcome));
	}

	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, Task<TResult>> fallbackAction, Func<DelegateResult<TResult>, Task> onFallbackAsync)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		if (onFallbackAsync == null)
		{
			throw new ArgumentNullException("onFallbackAsync");
		}
		return policyBuilder.FallbackAsync((DelegateResult<TResult> _, Context _, CancellationToken ct) => fallbackAction(ct), (DelegateResult<TResult> outcome, Context _) => onFallbackAsync(outcome));
	}

	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync)
	{
		if (onFallbackAsync == null)
		{
			throw new ArgumentNullException("onFallbackAsync");
		}
		return policyBuilder.FallbackAsync((DelegateResult<TResult> _, Context _, CancellationToken _) => Task.FromResult(fallbackValue), onFallbackAsync);
	}

	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<Context, CancellationToken, Task<TResult>> fallbackAction, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		return policyBuilder.FallbackAsync((DelegateResult<TResult> _, Context ctx, CancellationToken ct) => fallbackAction(ctx, ct), onFallbackAsync);
	}

	public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> fallbackAction, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync)
	{
		if (fallbackAction == null)
		{
			throw new ArgumentNullException("fallbackAction");
		}
		if (onFallbackAsync == null)
		{
			throw new ArgumentNullException("onFallbackAsync");
		}
		return new AsyncFallbackPolicy<TResult>(policyBuilder, onFallbackAsync, fallbackAction);
	}
}
