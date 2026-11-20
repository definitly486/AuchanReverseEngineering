using System;
using System.Threading;

namespace Polly.RateLimit;

internal static class RateLimitEngine
{
	internal static TResult Implementation<TResult>(IRateLimiter rateLimiter, Func<TimeSpan, Context, TResult>? retryAfterFactory, Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		var (flag, timeSpan) = rateLimiter.PermitExecution();
		if (flag)
		{
			return action(context, cancellationToken);
		}
		if (retryAfterFactory != null)
		{
			return retryAfterFactory(timeSpan, context);
		}
		throw new RateLimitRejectedException(timeSpan);
	}
}
