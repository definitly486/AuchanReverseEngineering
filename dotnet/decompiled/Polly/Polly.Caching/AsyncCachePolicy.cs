using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Caching;

public class AsyncCachePolicy : AsyncPolicy
{
	private readonly IAsyncCacheProvider _asyncCacheProvider;

	private readonly ITtlStrategy _ttlStrategy;

	private readonly Func<Context, string> _cacheKeyStrategy;

	private readonly Action<Context, string> _onCacheGet;

	private readonly Action<Context, string> _onCacheMiss;

	private readonly Action<Context, string> _onCachePut;

	private readonly Action<Context, string, Exception>? _onCacheGetError;

	private readonly Action<Context, string, Exception>? _onCachePutError;

	internal AsyncCachePolicy(IAsyncCacheProvider asyncCacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
	{
		_asyncCacheProvider = asyncCacheProvider;
		_ttlStrategy = ttlStrategy;
		_cacheKeyStrategy = cacheKeyStrategy;
		_onCacheGet = onCacheGet;
		_onCachePut = onCachePut;
		_onCacheMiss = onCacheMiss;
		_onCacheGetError = onCacheGetError;
		_onCachePutError = onCachePutError;
	}

	protected override Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return action(context, cancellationToken);
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncCacheEngine.ImplementationAsync(_asyncCacheProvider.AsyncFor<TResult>(), _ttlStrategy.For<TResult>(), _cacheKeyStrategy, action, context, continueOnCapturedContext, _onCacheGet, _onCacheMiss, _onCachePut, _onCacheGetError, _onCachePutError, cancellationToken);
	}
}
public class AsyncCachePolicy<TResult> : AsyncPolicy<TResult>
{
	private readonly ITtlStrategy<TResult> _ttlStrategy;

	private readonly Func<Context, string> _cacheKeyStrategy;

	private readonly Action<Context, string> _onCacheGet;

	private readonly Action<Context, string> _onCacheMiss;

	private readonly Action<Context, string> _onCachePut;

	private readonly Action<Context, string, Exception>? _onCacheGetError;

	private readonly Action<Context, string, Exception>? _onCachePutError;

	private readonly IAsyncCacheProvider<TResult> _asyncCacheProvider;

	internal AsyncCachePolicy(IAsyncCacheProvider<TResult> asyncCacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception>? onCacheGetError, Action<Context, string, Exception>? onCachePutError)
		: base((PolicyBuilder<TResult>?)null)
	{
		_asyncCacheProvider = asyncCacheProvider;
		_ttlStrategy = ttlStrategy;
		_cacheKeyStrategy = cacheKeyStrategy;
		_onCacheGet = onCacheGet;
		_onCachePut = onCachePut;
		_onCacheMiss = onCacheMiss;
		_onCacheGetError = onCacheGetError;
		_onCachePutError = onCachePutError;
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncCacheEngine.ImplementationAsync(_asyncCacheProvider, _ttlStrategy, _cacheKeyStrategy, action, context, continueOnCapturedContext, _onCacheGet, _onCacheMiss, _onCachePut, _onCacheGetError, _onCachePutError, cancellationToken);
	}
}
