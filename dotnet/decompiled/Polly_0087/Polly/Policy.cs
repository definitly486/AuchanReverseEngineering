using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Polly.Bulkhead;
using Polly.Caching;
using Polly.NoOp;
using Polly.RateLimit;
using Polly.Timeout;
using Polly.Utilities;
using Polly.Wrap;

namespace Polly;

public abstract class Policy : PolicyBase, ISyncPolicy, IsPolicy
{
	private const int MinimumPoliciesRequiredForWrap = 2;

	public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization)
	{
		Func<Context, Task> onBulkheadRejectedAsync = (Context _) => TaskHelper.EmptyTask;
		return BulkheadAsync(maxParallelization, 0, onBulkheadRejectedAsync);
	}

	public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization, Func<Context, Task> onBulkheadRejectedAsync)
	{
		return BulkheadAsync(maxParallelization, 0, onBulkheadRejectedAsync);
	}

	public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization, int maxQueuingActions)
	{
		Func<Context, Task> onBulkheadRejectedAsync = (Context _) => TaskHelper.EmptyTask;
		return BulkheadAsync(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
	}

	public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization, int maxQueuingActions, Func<Context, Task> onBulkheadRejectedAsync)
	{
		if (maxParallelization <= 0)
		{
			throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
		}
		if (maxQueuingActions < 0)
		{
			throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
		}
		if (onBulkheadRejectedAsync == null)
		{
			throw new ArgumentNullException("onBulkheadRejectedAsync");
		}
		return new AsyncBulkheadPolicy(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
	}

	public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization)
	{
		return BulkheadAsync<TResult>(maxParallelization, 0, EmptyHandler);
	}

	public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization, Func<Context, Task> onBulkheadRejectedAsync)
	{
		return BulkheadAsync<TResult>(maxParallelization, 0, onBulkheadRejectedAsync);
	}

	public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization, int maxQueuingActions)
	{
		return BulkheadAsync<TResult>(maxParallelization, maxQueuingActions, EmptyHandler);
	}

	public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization, int maxQueuingActions, Func<Context, Task> onBulkheadRejectedAsync)
	{
		if (maxParallelization <= 0)
		{
			throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
		}
		if (maxQueuingActions < 0)
		{
			throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
		}
		if (onBulkheadRejectedAsync == null)
		{
			throw new ArgumentNullException("onBulkheadRejectedAsync");
		}
		return new AsyncBulkheadPolicy<TResult>(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
	}

	private static Task EmptyHandler(Context context)
	{
		return TaskHelper.EmptyTask;
	}

	public static BulkheadPolicy Bulkhead(int maxParallelization)
	{
		return Bulkhead(maxParallelization, 0, EmptyAction);
	}

	public static BulkheadPolicy Bulkhead(int maxParallelization, Action<Context> onBulkheadRejected)
	{
		return Bulkhead(maxParallelization, 0, onBulkheadRejected);
	}

	public static BulkheadPolicy Bulkhead(int maxParallelization, int maxQueuingActions)
	{
		return Bulkhead(maxParallelization, maxQueuingActions, EmptyAction);
	}

	public static BulkheadPolicy Bulkhead(int maxParallelization, int maxQueuingActions, Action<Context> onBulkheadRejected)
	{
		if (maxParallelization <= 0)
		{
			throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
		}
		if (maxQueuingActions < 0)
		{
			throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
		}
		if (onBulkheadRejected == null)
		{
			throw new ArgumentNullException("onBulkheadRejected");
		}
		return new BulkheadPolicy(maxParallelization, maxQueuingActions, onBulkheadRejected);
	}

	private static void EmptyAction(Context context)
	{
	}

	public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization)
	{
		return Bulkhead<TResult>(maxParallelization, 0, EmptyAction);
	}

	public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization, Action<Context> onBulkheadRejected)
	{
		return Bulkhead<TResult>(maxParallelization, 0, onBulkheadRejected);
	}

	public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization, int maxQueuingActions)
	{
		return Bulkhead<TResult>(maxParallelization, maxQueuingActions, EmptyAction);
	}

	public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization, int maxQueuingActions, Action<Context> onBulkheadRejected)
	{
		if (maxParallelization <= 0)
		{
			throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
		}
		if (maxQueuingActions < 0)
		{
			throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
		}
		if (onBulkheadRejected == null)
		{
			throw new ArgumentNullException("onBulkheadRejected");
		}
		return new BulkheadPolicy<TResult>(maxParallelization, maxQueuingActions, onBulkheadRejected);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		Action<Context, string> action = delegate
		{
		};
		return new AsyncCachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		Action<Context, string> action = delegate
		{
		};
		return new AsyncCachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		if (onCacheGet == null)
		{
			throw new ArgumentNullException("onCacheGet");
		}
		if (onCacheMiss == null)
		{
			throw new ArgumentNullException("onCacheMiss");
		}
		if (onCachePut == null)
		{
			throw new ArgumentNullException("onCachePut");
		}
		return new AsyncCachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, EmptyCallback, EmptyCallback, EmptyCallback, onCacheError, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, EmptyCallback, EmptyCallback, EmptyCallback, onCacheError, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy, EmptyCallback, EmptyCallback, EmptyCallback, onCacheError, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy, EmptyCallback, EmptyCallback, EmptyCallback, onCacheError, onCacheError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, ttlStrategy.For<TResult>(), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return CacheAsync(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		if (onCacheGet == null)
		{
			throw new ArgumentNullException("onCacheGet");
		}
		if (onCacheMiss == null)
		{
			throw new ArgumentNullException("onCacheMiss");
		}
		if (onCachePut == null)
		{
			throw new ArgumentNullException("onCachePut");
		}
		return new AsyncCachePolicy<TResult>(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	private static void EmptyCallback(Context context, string key)
	{
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, EmptyCallback, EmptyCallback, EmptyCallback, onCacheError, onCacheError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy, EmptyCallback, EmptyCallback, EmptyCallback, onCacheError, onCacheError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		if (onCacheGet == null)
		{
			throw new ArgumentNullException("onCacheGet");
		}
		if (onCacheMiss == null)
		{
			throw new ArgumentNullException("onCacheMiss");
		}
		if (onCachePut == null)
		{
			throw new ArgumentNullException("onCachePut");
		}
		return new CachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		Action<Context, string> action = delegate
		{
		};
		return Cache(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		Action<Context, string> action = delegate
		{
		};
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		Action<Context, string> action = delegate
		{
		};
		return Cache(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception>? onCacheError = null)
	{
		Action<Context, string> action = delegate
		{
		};
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		return Cache(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		if (cacheProvider == null)
		{
			throw new ArgumentNullException("cacheProvider");
		}
		if (ttlStrategy == null)
		{
			throw new ArgumentNullException("ttlStrategy");
		}
		if (cacheKeyStrategy == null)
		{
			throw new ArgumentNullException("cacheKeyStrategy");
		}
		if (onCacheGet == null)
		{
			throw new ArgumentNullException("onCacheGet");
		}
		if (onCacheMiss == null)
		{
			throw new ArgumentNullException("onCacheMiss");
		}
		if (onCachePut == null)
		{
			throw new ArgumentNullException("onCachePut");
		}
		return new CachePolicy<TResult>(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
	}

	public static AsyncNoOpPolicy NoOpAsync()
	{
		return new AsyncNoOpPolicy();
	}

	public static AsyncNoOpPolicy<TResult> NoOpAsync<TResult>()
	{
		return new AsyncNoOpPolicy<TResult>();
	}

	public static NoOpPolicy NoOp()
	{
		return new NoOpPolicy();
	}

	public static NoOpPolicy<TResult> NoOp<TResult>()
	{
		return new NoOpPolicy<TResult>();
	}

	public Policy WithPolicyKey(string policyKey)
	{
		if (policyKeyInternal != null)
		{
			throw PolicyBase.PolicyKeyMustBeImmutableException("policyKey");
		}
		policyKeyInternal = policyKey;
		return this;
	}

	ISyncPolicy ISyncPolicy.WithPolicyKey(string policyKey)
	{
		return WithPolicyKey(policyKey);
	}

	private protected Policy(ExceptionPredicates exceptionPredicates)
		: base(exceptionPredicates)
	{
	}

	protected Policy(PolicyBuilder? policyBuilder = null)
		: base(policyBuilder)
	{
	}

	[DebuggerStepThrough]
	public void Execute(Action action)
	{
		Execute(delegate
		{
			action();
		}, new Context(), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public void Execute(Action<Context> action, IDictionary<string, object> contextData)
	{
		Execute(delegate(Context ctx, CancellationToken _)
		{
			action(ctx);
		}, new Context(contextData), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public void Execute(Action<Context> action, Context context)
	{
		Execute(delegate(Context ctx, CancellationToken _)
		{
			action(ctx);
		}, context, DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public void Execute(Action<CancellationToken> action, CancellationToken cancellationToken)
	{
		Execute(delegate(Context _, CancellationToken ct)
		{
			action(ct);
		}, new Context(), cancellationToken);
	}

	[DebuggerStepThrough]
	public void Execute(Action<Context, CancellationToken> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
	{
		Execute(action, new Context(contextData), cancellationToken);
	}

	[DebuggerStepThrough]
	public void Execute(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
		try
		{
			Implementation(action, context, cancellationToken);
		}
		finally
		{
			PolicyBase.RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
		}
	}

	[DebuggerStepThrough]
	public TResult Execute<TResult>(Func<TResult> action)
	{
		return Execute((Context _, CancellationToken _) => action(), new Context(), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute<TResult>(Func<Context, TResult> action, IDictionary<string, object> contextData)
	{
		return Execute((Context ctx, CancellationToken _) => action(ctx), new Context(contextData), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute<TResult>(Func<Context, TResult> action, Context context)
	{
		return Execute((Context ctx, CancellationToken _) => action(ctx), context, DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute<TResult>(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
	{
		return Execute((Context _, CancellationToken ct) => action(ct), new Context(), cancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute<TResult>(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
	{
		return Execute(action, new Context(contextData), cancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
		try
		{
			return Implementation(action, context, cancellationToken);
		}
		finally
		{
			PolicyBase.RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
		}
	}

	[DebuggerStepThrough]
	public PolicyResult ExecuteAndCapture(Action action)
	{
		return ExecuteAndCapture(delegate
		{
			action();
		}, new Context(), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult ExecuteAndCapture(Action<Context> action, IDictionary<string, object> contextData)
	{
		return ExecuteAndCapture(delegate(Context ctx, CancellationToken _)
		{
			action(ctx);
		}, new Context(contextData), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult ExecuteAndCapture(Action<Context> action, Context context)
	{
		return ExecuteAndCapture(delegate(Context ctx, CancellationToken _)
		{
			action(ctx);
		}, context, DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult ExecuteAndCapture(Action<CancellationToken> action, CancellationToken cancellationToken)
	{
		return ExecuteAndCapture(delegate(Context _, CancellationToken ct)
		{
			action(ct);
		}, new Context(), cancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult ExecuteAndCapture(Action<Context, CancellationToken> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
	{
		return ExecuteAndCapture(action, new Context(contextData), cancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult ExecuteAndCapture(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		try
		{
			Execute(action, context, cancellationToken);
			return PolicyResult.Successful(context);
		}
		catch (Exception exception)
		{
			return PolicyResult.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
		}
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<TResult> action)
	{
		return ExecuteAndCapture((Context _, CancellationToken _) => action(), new Context(), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, TResult> action, IDictionary<string, object> contextData)
	{
		return ExecuteAndCapture((Context ctx, CancellationToken _) => action(ctx), new Context(contextData), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, TResult> action, Context context)
	{
		return ExecuteAndCapture((Context ctx, CancellationToken _) => action(ctx), context, DefaultCancellationToken);
	}

	public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
	{
		return ExecuteAndCapture((Context _, CancellationToken ct) => action(ct), new Context(), cancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
	{
		return ExecuteAndCapture(action, new Context(contextData), cancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		try
		{
			return PolicyResult<TResult>.Successful(Execute(action, context, cancellationToken), context);
		}
		catch (Exception exception)
		{
			return PolicyResult<TResult>.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
		}
	}

	public static PolicyBuilder Handle<TException>() where TException : Exception
	{
		return new PolicyBuilder((Exception exception) => (!(exception is TException)) ? null : exception);
	}

	public static PolicyBuilder Handle<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
	{
		return new PolicyBuilder((Exception exception) => (!(exception is TException arg) || !exceptionPredicate(arg)) ? null : exception);
	}

	public static PolicyBuilder HandleInner<TException>() where TException : Exception
	{
		return new PolicyBuilder(PolicyBuilder.HandleInner((Exception ex) => ex is TException));
	}

	public static PolicyBuilder HandleInner<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
	{
		return new PolicyBuilder(PolicyBuilder.HandleInner((Exception ex) => ex is TException arg && exceptionPredicate(arg)));
	}

	public static PolicyBuilder<TResult> HandleResult<TResult>(Func<TResult, bool> resultPredicate)
	{
		return new PolicyBuilder<TResult>(resultPredicate);
	}

	public static PolicyBuilder<TResult> HandleResult<TResult>(TResult result)
	{
		return HandleResult((TResult r) => (!object.Equals(r, default(TResult)) && r.Equals(result)) || (object.Equals(r, default(TResult)) && object.Equals(result, default(TResult))));
	}

	[DebuggerStepThrough]
	protected virtual void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
	{
		Implementation(delegate(Context ctx, CancellationToken token)
		{
			action(ctx, token);
			return EmptyStruct.Instance;
		}, context, cancellationToken);
	}

	protected abstract TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);

	public static AsyncRateLimitPolicy RateLimitAsync(int numberOfExecutions, TimeSpan perTimeSpan)
	{
		return RateLimitAsync(numberOfExecutions, perTimeSpan, 1);
	}

	public static AsyncRateLimitPolicy RateLimitAsync(int numberOfExecutions, TimeSpan perTimeSpan, int maxBurst)
	{
		if (numberOfExecutions < 1)
		{
			throw new ArgumentOutOfRangeException("numberOfExecutions", numberOfExecutions, "numberOfExecutions per timespan must be an integer greater than or equal to 1.");
		}
		if (perTimeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "perTimeSpan must be a positive timespan.");
		}
		if (maxBurst < 1)
		{
			throw new ArgumentOutOfRangeException("maxBurst", maxBurst, "maxBurst must be an integer greater than or equal to 1.");
		}
		TimeSpan timeSpan = TimeSpan.FromTicks(perTimeSpan.Ticks / numberOfExecutions);
		if (timeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "The number of executions per timespan must be positive.");
		}
		return new AsyncRateLimitPolicy(new LockFreeTokenBucketRateLimiter(timeSpan, maxBurst));
	}

	public static AsyncRateLimitPolicy<TResult> RateLimitAsync<TResult>(int numberOfExecutions, TimeSpan perTimeSpan)
	{
		return RateLimitAsync<TResult>(numberOfExecutions, perTimeSpan, null);
	}

	public static AsyncRateLimitPolicy<TResult> RateLimitAsync<TResult>(int numberOfExecutions, TimeSpan perTimeSpan, Func<TimeSpan, Context, TResult>? retryAfterFactory)
	{
		return RateLimitAsync(numberOfExecutions, perTimeSpan, 1, retryAfterFactory);
	}

	public static AsyncRateLimitPolicy<TResult> RateLimitAsync<TResult>(int numberOfExecutions, TimeSpan perTimeSpan, int maxBurst)
	{
		return RateLimitAsync<TResult>(numberOfExecutions, perTimeSpan, maxBurst, null);
	}

	public static AsyncRateLimitPolicy<TResult> RateLimitAsync<TResult>(int numberOfExecutions, TimeSpan perTimeSpan, int maxBurst, Func<TimeSpan, Context, TResult>? retryAfterFactory)
	{
		if (numberOfExecutions < 1)
		{
			throw new ArgumentOutOfRangeException("numberOfExecutions", numberOfExecutions, "numberOfExecutions per timespan must be an integer greater than or equal to 1.");
		}
		if (perTimeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "perTimeSpan must be a positive timespan.");
		}
		if (maxBurst < 1)
		{
			throw new ArgumentOutOfRangeException("maxBurst", maxBurst, "maxBurst must be an integer greater than or equal to 1.");
		}
		TimeSpan timeSpan = TimeSpan.FromTicks(perTimeSpan.Ticks / numberOfExecutions);
		if (timeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "The number of executions per timespan must be positive.");
		}
		return new AsyncRateLimitPolicy<TResult>(new LockFreeTokenBucketRateLimiter(timeSpan, maxBurst), retryAfterFactory);
	}

	public static RateLimitPolicy RateLimit(int numberOfExecutions, TimeSpan perTimeSpan)
	{
		return RateLimit(numberOfExecutions, perTimeSpan, 1);
	}

	public static RateLimitPolicy RateLimit(int numberOfExecutions, TimeSpan perTimeSpan, int maxBurst)
	{
		if (numberOfExecutions < 1)
		{
			throw new ArgumentOutOfRangeException("numberOfExecutions", numberOfExecutions, "numberOfExecutions per timespan must be an integer greater than or equal to 1.");
		}
		if (perTimeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "perTimeSpan must be a positive timespan.");
		}
		if (maxBurst < 1)
		{
			throw new ArgumentOutOfRangeException("maxBurst", maxBurst, "maxBurst must be an integer greater than or equal to 1.");
		}
		TimeSpan timeSpan = TimeSpan.FromTicks(perTimeSpan.Ticks / numberOfExecutions);
		if (timeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "The number of executions per timespan must be positive.");
		}
		return new RateLimitPolicy(new LockFreeTokenBucketRateLimiter(timeSpan, maxBurst));
	}

	public static RateLimitPolicy<TResult> RateLimit<TResult>(int numberOfExecutions, TimeSpan perTimeSpan)
	{
		return RateLimit<TResult>(numberOfExecutions, perTimeSpan, null);
	}

	public static RateLimitPolicy<TResult> RateLimit<TResult>(int numberOfExecutions, TimeSpan perTimeSpan, Func<TimeSpan, Context, TResult>? retryAfterFactory)
	{
		return RateLimit(numberOfExecutions, perTimeSpan, 1, retryAfterFactory);
	}

	public static RateLimitPolicy<TResult> RateLimit<TResult>(int numberOfExecutions, TimeSpan perTimeSpan, int maxBurst)
	{
		return RateLimit<TResult>(numberOfExecutions, perTimeSpan, maxBurst, null);
	}

	public static RateLimitPolicy<TResult> RateLimit<TResult>(int numberOfExecutions, TimeSpan perTimeSpan, int maxBurst, Func<TimeSpan, Context, TResult>? retryAfterFactory)
	{
		if (numberOfExecutions < 1)
		{
			throw new ArgumentOutOfRangeException("numberOfExecutions", numberOfExecutions, "numberOfExecutions per timespan must be an integer greater than or equal to 1.");
		}
		if (perTimeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "perTimeSpan must be a positive timespan.");
		}
		if (maxBurst < 1)
		{
			throw new ArgumentOutOfRangeException("maxBurst", maxBurst, "maxBurst must be an integer greater than or equal to 1.");
		}
		TimeSpan timeSpan = TimeSpan.FromTicks(perTimeSpan.Ticks / numberOfExecutions);
		if (timeSpan <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("perTimeSpan", perTimeSpan, "The number of executions per timespan must be positive.");
		}
		return new RateLimitPolicy<TResult>(new LockFreeTokenBucketRateLimiter(timeSpan, maxBurst), retryAfterFactory);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(int seconds)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(int seconds, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(int seconds, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(int seconds, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return TimeoutAsync((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return TimeoutAsync((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync((Context _) => timeout, TimeoutStrategy.Optimistic, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync((Context _) => timeout, timeoutStrategy, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync((Context _) => timeout, timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync((Context _) => timeout, timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync((Context _) => timeoutProvider(), timeoutStrategy, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync((Context _) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync((Context _) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider)
	{
		return TimeoutAsync(timeoutProvider, TimeoutStrategy.Optimistic, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		return TimeoutAsync(timeoutProvider, timeoutStrategy, EmptyHandlerAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		return TimeoutAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		return TimeoutAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		if (onTimeoutAsync == null)
		{
			throw new ArgumentNullException("onTimeoutAsync");
		}
		return TimeoutAsync(timeoutProvider, timeoutStrategy, (Context ctx, TimeSpan timeout, Task task, Exception _) => onTimeoutAsync(ctx, timeout, task));
	}

	public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		if (onTimeoutAsync == null)
		{
			throw new ArgumentNullException("onTimeoutAsync");
		}
		return new AsyncTimeoutPolicy(timeoutProvider, timeoutStrategy, onTimeoutAsync);
	}

	private static Task EmptyHandlerAsync(Context context, TimeSpan timeout, Task task, Exception exception)
	{
		return TaskHelper.EmptyTask;
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return TimeoutAsync<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return TimeoutAsync<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return TimeoutAsync<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync<TResult>((Context _) => timeout, TimeoutStrategy.Optimistic, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync<TResult>((Context _) => timeout, timeoutStrategy, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync<TResult>((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeout <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("timeout");
		}
		return TimeoutAsync<TResult>((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return TimeoutAsync<TResult>((Context _) => timeout, timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeout <= TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException("timeout");
		}
		return TimeoutAsync<TResult>((Context _) => timeout, timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync<TResult>((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync<TResult>((Context _) => timeoutProvider(), timeoutStrategy, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync<TResult>((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync<TResult>((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync<TResult>((Context _) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return TimeoutAsync<TResult>((Context _) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider)
	{
		return TimeoutAsync<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		return TimeoutAsync<TResult>(timeoutProvider, timeoutStrategy, EmptyHandlerOfT<TResult>);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		return TimeoutAsync<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		return TimeoutAsync<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
	{
		if (onTimeoutAsync == null)
		{
			throw new ArgumentNullException("onTimeoutAsync");
		}
		return TimeoutAsync<TResult>(timeoutProvider, timeoutStrategy, (Context ctx, TimeSpan timeout, Task task, Exception _) => onTimeoutAsync(ctx, timeout, task));
	}

	public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		if (onTimeoutAsync == null)
		{
			throw new ArgumentNullException("onTimeoutAsync");
		}
		return new AsyncTimeoutPolicy<TResult>(timeoutProvider, timeoutStrategy, onTimeoutAsync);
	}

	private static Task EmptyHandlerOfT<T>(Context context, TimeSpan timeout, Task action, Exception exception)
	{
		return Task.FromResult(default(T));
	}

	public static TimeoutPolicy Timeout(int seconds)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(int seconds, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(int seconds, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(int seconds, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return Timeout((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy Timeout(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return Timeout((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy Timeout(TimeSpan timeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout((Context _) => timeout, TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout((Context _) => timeout, timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(TimeSpan timeout, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(TimeSpan timeout, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout((Context _) => timeout, timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy Timeout(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout((Context _) => timeout, timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout((Context _) => timeoutProvider(), timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout((Context _) => timeoutProvider(), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout((Context _) => timeoutProvider(), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider)
	{
		return Timeout(timeoutProvider, TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		return Timeout(timeoutProvider, timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
	{
		return Timeout(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		return Timeout(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		if (onTimeout == null)
		{
			throw new ArgumentNullException("onTimeout");
		}
		return Timeout(timeoutProvider, timeoutStrategy, delegate(Context ctx, TimeSpan timeout, Task task, Exception _)
		{
			onTimeout(ctx, timeout, task);
		});
	}

	public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		if (onTimeout == null)
		{
			throw new ArgumentNullException("onTimeout");
		}
		return new TimeoutPolicy(timeoutProvider, timeoutStrategy, onTimeout);
	}

	private static void EmptyHandler(Context context, TimeSpan timeout, Task task, Exception exception)
	{
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return Timeout<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateSecondsTimeout(seconds);
		return Timeout<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (seconds <= 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		return Timeout<TResult>((Context _) => TimeSpan.FromSeconds((double)seconds), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout<TResult>((Context _) => timeout, TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout<TResult>((Context _) => timeout, timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout<TResult>((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout<TResult>((Context _) => timeout, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout<TResult>((Context _) => timeout, timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		TimeoutValidator.ValidateTimeSpanTimeout(timeout);
		return Timeout<TResult>((Context _) => timeout, timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout<TResult>((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout<TResult>((Context _) => timeoutProvider(), timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout<TResult>((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout<TResult>((Context _) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout<TResult>((Context _) => timeoutProvider(), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		return Timeout<TResult>((Context _) => timeoutProvider(), timeoutStrategy, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider)
	{
		return Timeout<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
	{
		return Timeout<TResult>(timeoutProvider, timeoutStrategy, EmptyHandler);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
	{
		return Timeout<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		return Timeout<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
	{
		if (onTimeout == null)
		{
			throw new ArgumentNullException("onTimeout");
		}
		return Timeout<TResult>(timeoutProvider, timeoutStrategy, delegate(Context ctx, TimeSpan timeout, Task task, Exception _)
		{
			onTimeout(ctx, timeout, task);
		});
	}

	public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		if (timeoutProvider == null)
		{
			throw new ArgumentNullException("timeoutProvider");
		}
		if (onTimeout == null)
		{
			throw new ArgumentNullException("onTimeout");
		}
		return new TimeoutPolicy<TResult>(timeoutProvider, timeoutStrategy, onTimeout);
	}

	public static AsyncPolicyWrap WrapAsync(params IAsyncPolicy[] policies)
	{
		if (policies == null)
		{
			throw new ArgumentNullException("policies");
		}
		int num = policies.Length;
		if (num >= 2)
		{
			if (num == 2)
			{
				return new AsyncPolicyWrap((AsyncPolicy)policies[0], policies[1]);
			}
			return WrapAsync(policies[0], WrapAsync(policies.Skip(1).ToArray()));
		}
		throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
	}

	public static AsyncPolicyWrap<TResult> WrapAsync<TResult>(params IAsyncPolicy<TResult>[] policies)
	{
		if (policies == null)
		{
			throw new ArgumentNullException("policies");
		}
		int num = policies.Length;
		if (num >= 2)
		{
			if (num == 2)
			{
				return new AsyncPolicyWrap<TResult>((AsyncPolicy<TResult>)policies[0], policies[1]);
			}
			return WrapAsync<TResult>(policies[0], WrapAsync(policies.Skip(1).ToArray()));
		}
		throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
	}

	public PolicyWrap Wrap(ISyncPolicy innerPolicy)
	{
		if (innerPolicy == null)
		{
			throw new ArgumentNullException("innerPolicy");
		}
		return new PolicyWrap(this, innerPolicy);
	}

	public PolicyWrap<TResult> Wrap<TResult>(ISyncPolicy<TResult> innerPolicy)
	{
		if (innerPolicy == null)
		{
			throw new ArgumentNullException("innerPolicy");
		}
		return new PolicyWrap<TResult>(this, innerPolicy);
	}

	public static PolicyWrap Wrap(params ISyncPolicy[] policies)
	{
		if (policies == null)
		{
			throw new ArgumentNullException("policies");
		}
		int num = policies.Length;
		if (num >= 2)
		{
			if (num == 2)
			{
				return new PolicyWrap((Policy)policies[0], policies[1]);
			}
			return Wrap(policies[0], Wrap(policies.Skip(1).ToArray()));
		}
		throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
	}

	public static PolicyWrap<TResult> Wrap<TResult>(params ISyncPolicy<TResult>[] policies)
	{
		if (policies == null)
		{
			throw new ArgumentNullException("policies");
		}
		int num = policies.Length;
		if (num >= 2)
		{
			if (num == 2)
			{
				return new PolicyWrap<TResult>((Policy<TResult>)policies[0], policies[1]);
			}
			return Wrap<TResult>(policies[0], Wrap(policies.Skip(1).ToArray()));
		}
		throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
	}
}
public abstract class Policy<TResult> : PolicyBase<TResult>, ISyncPolicy<TResult>, IsPolicy
{
	public Policy<TResult> WithPolicyKey(string policyKey)
	{
		if (policyKeyInternal != null)
		{
			throw PolicyBase.PolicyKeyMustBeImmutableException("policyKey");
		}
		policyKeyInternal = policyKey;
		return this;
	}

	ISyncPolicy<TResult> ISyncPolicy<TResult>.WithPolicyKey(string policyKey)
	{
		return WithPolicyKey(policyKey);
	}

	public static PolicyBuilder<TResult> Handle<TException>() where TException : Exception
	{
		return new PolicyBuilder<TResult>((Exception exception) => (!(exception is TException)) ? null : exception);
	}

	public static PolicyBuilder<TResult> Handle<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
	{
		return new PolicyBuilder<TResult>((Exception exception) => (!(exception is TException arg) || !exceptionPredicate(arg)) ? null : exception);
	}

	public static PolicyBuilder<TResult> HandleInner<TException>() where TException : Exception
	{
		return new PolicyBuilder<TResult>(PolicyBuilder.HandleInner((Exception ex) => ex is TException));
	}

	public static PolicyBuilder<TResult> HandleInner<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
	{
		return new PolicyBuilder<TResult>(PolicyBuilder.HandleInner((Exception ex) => ex is TException arg && exceptionPredicate(arg)));
	}

	public static PolicyBuilder<TResult> HandleResult(Func<TResult, bool> resultPredicate)
	{
		return new PolicyBuilder<TResult>(resultPredicate);
	}

	public static PolicyBuilder<TResult> HandleResult(TResult result)
	{
		return HandleResult((TResult r) => EqualityComparer<TResult>.Default.Equals(r, result));
	}

	protected abstract TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);

	private protected Policy(ExceptionPredicates exceptionPredicates, ResultPredicates<TResult> resultPredicates)
		: base(exceptionPredicates, resultPredicates)
	{
	}

	protected Policy(PolicyBuilder<TResult>? policyBuilder = null)
		: base(policyBuilder)
	{
	}

	[DebuggerStepThrough]
	public TResult Execute(Func<TResult> action)
	{
		return Execute((Context _, CancellationToken _) => action(), new Context(), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute(Func<Context, TResult> action, IDictionary<string, object> contextData)
	{
		return Execute((Context ctx, CancellationToken _) => action(ctx), new Context(contextData), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute(Func<Context, TResult> action, Context context)
	{
		return Execute((Context ctx, CancellationToken _) => action(ctx), context, DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
	{
		return Execute((Context _, CancellationToken ct) => action(ct), new Context(), cancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
	{
		return Execute(action, new Context(contextData), cancellationToken);
	}

	[DebuggerStepThrough]
	public TResult Execute(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
		try
		{
			return Implementation(action, context, cancellationToken);
		}
		finally
		{
			PolicyBase.RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
		}
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture(Func<TResult> action)
	{
		return ExecuteAndCapture((Context _, CancellationToken _) => action(), new Context(), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture(Func<Context, TResult> action, IDictionary<string, object> contextData)
	{
		return ExecuteAndCapture((Context ctx, CancellationToken _) => action(ctx), new Context(contextData), DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture(Func<Context, TResult> action, Context context)
	{
		return ExecuteAndCapture((Context ctx, CancellationToken _) => action(ctx), context, DefaultCancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
	{
		return ExecuteAndCapture((Context _, CancellationToken ct) => action(ct), new Context(), cancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
	{
		return ExecuteAndCapture(action, new Context(contextData), cancellationToken);
	}

	[DebuggerStepThrough]
	public PolicyResult<TResult> ExecuteAndCapture(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		try
		{
			TResult val = Execute(action, context, cancellationToken);
			if (base.ResultPredicates.AnyMatch(val))
			{
				return PolicyResult<TResult>.Failure(val, context);
			}
			return PolicyResult<TResult>.Successful(val, context);
		}
		catch (Exception exception)
		{
			return PolicyResult<TResult>.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
		}
	}

	public PolicyWrap<TResult> Wrap(ISyncPolicy innerPolicy)
	{
		if (innerPolicy == null)
		{
			throw new ArgumentNullException("innerPolicy");
		}
		return new PolicyWrap<TResult>(this, innerPolicy);
	}

	public PolicyWrap<TResult> Wrap(ISyncPolicy<TResult> innerPolicy)
	{
		if (innerPolicy == null)
		{
			throw new ArgumentNullException("innerPolicy");
		}
		return new PolicyWrap<TResult>(this, innerPolicy);
	}
}
