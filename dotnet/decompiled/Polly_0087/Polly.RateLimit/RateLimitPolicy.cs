using System;
using System.Diagnostics;
using System.Threading;

namespace Polly.RateLimit;

public class RateLimitPolicy : Policy, IRateLimitPolicy, IsPolicy
{
	private readonly IRateLimiter _rateLimiter;

	internal RateLimitPolicy(IRateLimiter rateLimiter)
	{
		_rateLimiter = rateLimiter;
	}

	[DebuggerStepThrough]
	protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return RateLimitEngine.Implementation(_rateLimiter, null, action, context, cancellationToken);
	}
}
public class RateLimitPolicy<TResult> : Policy<TResult>, IRateLimitPolicy<TResult>, IRateLimitPolicy, IsPolicy
{
	private readonly IRateLimiter _rateLimiter;

	private readonly Func<TimeSpan, Context, TResult>? _retryAfterFactory;

	internal RateLimitPolicy(IRateLimiter rateLimiter, Func<TimeSpan, Context, TResult>? retryAfterFactory)
		: base((PolicyBuilder<TResult>?)null)
	{
		_rateLimiter = rateLimiter;
		_retryAfterFactory = retryAfterFactory;
	}

	[DebuggerStepThrough]
	protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return RateLimitEngine.Implementation(_rateLimiter, _retryAfterFactory, action, context, cancellationToken);
	}
}
