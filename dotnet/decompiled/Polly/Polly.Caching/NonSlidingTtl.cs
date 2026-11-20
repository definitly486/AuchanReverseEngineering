using System;
using Polly.Utilities;

namespace Polly.Caching;

public abstract class NonSlidingTtl : ITtlStrategy, ITtlStrategy<object>
{
	protected readonly DateTimeOffset absoluteExpirationTime;

	protected NonSlidingTtl(DateTimeOffset absoluteExpirationTime)
	{
		this.absoluteExpirationTime = absoluteExpirationTime;
	}

	public Ttl GetTtl(Context context, object? result)
	{
		return new Ttl(TimeSpan.FromTicks(Math.Max(0L, absoluteExpirationTime.Subtract(SystemClock.DateTimeOffsetUtcNow()).Ticks)), slidingExpiration: false);
	}
}
