using System;

namespace Polly.Caching;

public class DefaultCacheKeyStrategy : ICacheKeyStrategy
{
	public static readonly ICacheKeyStrategy Instance = new DefaultCacheKeyStrategy();

	public string GetCacheKey(Context context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return context.OperationKey;
	}
}
