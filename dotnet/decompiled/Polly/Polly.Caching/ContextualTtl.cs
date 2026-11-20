using System;

namespace Polly.Caching;

public class ContextualTtl : ITtlStrategy, ITtlStrategy<object>
{
	public static readonly string TimeSpanKey = "ContextualTtlTimeSpan";

	public static readonly string SlidingExpirationKey = "ContextualTtlSliding";

	private static readonly Ttl NoTtl = new Ttl(TimeSpan.Zero, slidingExpiration: false);

	public Ttl GetTtl(Context context, object? result)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (!context.ContainsKey(TimeSpanKey))
		{
			return NoTtl;
		}
		bool slidingExpiration = false;
		if (context.TryGetValue(SlidingExpirationKey, out var value))
		{
			slidingExpiration = value as bool? == true;
		}
		return new Ttl((context[TimeSpanKey] as TimeSpan?) ?? TimeSpan.Zero, slidingExpiration);
	}
}
