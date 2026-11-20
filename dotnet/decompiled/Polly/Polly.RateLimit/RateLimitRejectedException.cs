using System;

namespace Polly.RateLimit;

public class RateLimitRejectedException : ExecutionRejectedException
{
	public TimeSpan RetryAfter { get; private set; }

	public RateLimitRejectedException()
		: base("The operation could not be executed because it was rejected by the rate limit.")
	{
	}

	public RateLimitRejectedException(string message)
		: base(message)
	{
	}

	public RateLimitRejectedException(string message, Exception inner)
		: base(message, inner)
	{
	}

	public RateLimitRejectedException(TimeSpan retryAfter)
		: this(retryAfter, DefaultMessage(retryAfter))
	{
	}

	public RateLimitRejectedException(TimeSpan retryAfter, Exception innerException)
		: base(DefaultMessage(retryAfter), innerException)
	{
		SetRetryAfter(retryAfter);
	}

	public RateLimitRejectedException(TimeSpan retryAfter, string message)
		: base(message)
	{
		SetRetryAfter(retryAfter);
	}

	public RateLimitRejectedException(TimeSpan retryAfter, string message, Exception innerException)
		: base(message, innerException)
	{
		SetRetryAfter(retryAfter);
	}

	private static string DefaultMessage(TimeSpan retryAfter)
	{
		return $"The operation has been rate-limited and should be retried after {retryAfter}";
	}

	private void SetRetryAfter(TimeSpan retryAfter)
	{
		if (retryAfter < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("retryAfter", retryAfter, "The retryAfter parameter must be a TimeSpan greater than or equal to TimeSpan.Zero.");
		}
		RetryAfter = retryAfter;
	}
}
