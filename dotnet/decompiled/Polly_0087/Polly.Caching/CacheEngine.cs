using System;
using System.Diagnostics;
using System.Threading;

namespace Polly.Caching;

internal static class CacheEngine
{
	[DebuggerDisableUserUnhandledExceptions]
	internal static TResult Implementation<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Func<Context, CancellationToken, TResult> action, Context context, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		string text = cacheKeyStrategy(context);
		if (text == null)
		{
			return action(context, cancellationToken);
		}
		bool flag;
		TResult result;
		try
		{
			(flag, result) = cacheProvider.TryGet(text);
		}
		catch (Exception arg)
		{
			flag = false;
			result = default(TResult);
			onCacheGetError?.Invoke(context, text, arg);
		}
		if (flag)
		{
			onCacheGet(context, text);
			return result;
		}
		onCacheMiss(context, text);
		TResult val = action(context, cancellationToken);
		Ttl ttl = ttlStrategy.GetTtl(context, val);
		if (ttl.Timespan > TimeSpan.Zero)
		{
			try
			{
				cacheProvider.Put(text, val, ttl);
				onCachePut(context, text);
			}
			catch (Exception arg2)
			{
				onCachePutError?.Invoke(context, text, arg2);
			}
		}
		return val;
	}
}
