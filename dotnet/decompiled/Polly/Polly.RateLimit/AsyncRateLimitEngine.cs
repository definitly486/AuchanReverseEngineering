using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.RateLimit;

internal static class AsyncRateLimitEngine
{
	internal static async Task<TResult> ImplementationAsync<TResult>(IRateLimiter rateLimiter, Func<TimeSpan, Context, TResult>? retryAfterFactory, Func<Context, CancellationToken, Task<TResult>> action, Context context, bool continueOnCapturedContext, CancellationToken cancellationToken)
	{
		var (flag, timeSpan) = rateLimiter.PermitExecution();
		if (flag)
		{
			return await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
		}
		if (retryAfterFactory != null)
		{
			return retryAfterFactory(timeSpan, context);
		}
		throw new RateLimitRejectedException(timeSpan);
	}
}
