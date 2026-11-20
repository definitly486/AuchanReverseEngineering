using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.RateLimit;

public class AsyncRateLimitPolicy : AsyncPolicy, IRateLimitPolicy, IsPolicy
{
	private readonly IRateLimiter _rateLimiter;

	internal AsyncRateLimitPolicy(IRateLimiter rateLimiter)
	{
		_rateLimiter = rateLimiter;
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncRateLimitEngine.ImplementationAsync(_rateLimiter, null, action, context, continueOnCapturedContext, cancellationToken);
	}
}
public class AsyncRateLimitPolicy<TResult> : AsyncPolicy<TResult>, IRateLimitPolicy<TResult>, IRateLimitPolicy, IsPolicy
{
	private readonly IRateLimiter _rateLimiter;

	private readonly Func<TimeSpan, Context, TResult>? _retryAfterFactory;

	internal AsyncRateLimitPolicy(IRateLimiter rateLimiter, Func<TimeSpan, Context, TResult>? retryAfterFactory)
		: base((PolicyBuilder<TResult>?)null)
	{
		_rateLimiter = rateLimiter;
		_retryAfterFactory = retryAfterFactory;
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncRateLimitEngine.ImplementationAsync(_rateLimiter, _retryAfterFactory, action, context, continueOnCapturedContext, cancellationToken);
	}
}
