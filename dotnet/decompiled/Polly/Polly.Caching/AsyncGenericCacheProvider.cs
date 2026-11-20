using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Caching;

internal sealed class AsyncGenericCacheProvider<TCacheFormat> : IAsyncCacheProvider<TCacheFormat>
{
	private readonly IAsyncCacheProvider _wrappedCacheProvider;

	internal AsyncGenericCacheProvider(IAsyncCacheProvider nonGenericCacheProvider)
	{
		_wrappedCacheProvider = nonGenericCacheProvider ?? throw new ArgumentNullException("nonGenericCacheProvider");
	}

	async Task<(bool, TCacheFormat?)> IAsyncCacheProvider<TCacheFormat>.TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		(bool, object) obj = await _wrappedCacheProvider.TryGetAsync(key, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		bool item = obj.Item1;
		object item2 = obj.Item2;
		TCacheFormat item3 = default(TCacheFormat);
		if (item)
		{
			item3 = (TCacheFormat)item2;
		}
		return (item, item3);
	}

	Task IAsyncCacheProvider<TCacheFormat>.PutAsync(string key, TCacheFormat? value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		return _wrappedCacheProvider.PutAsync(key, value, ttl, cancellationToken, continueOnCapturedContext);
	}
}
