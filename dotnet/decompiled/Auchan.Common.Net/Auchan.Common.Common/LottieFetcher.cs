using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Cache;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Common;

internal sealed class LottieFetcher : ILottieFetcher
{
	private readonly ICache _cache;

	public LottieFetcher(ICache cache)
	{
		_cache = cache;
	}

	public async Task<Stream?> FetchStreamAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
	{
		Result<byte[], Exception> result = await _cache.DownloadFrom(url, fetchAlways: true);
		if (result.IsSuccess)
		{
			return new MemoryStream(result.Value);
		}
		return null;
	}

	public Task RemoveFromCache(string url)
	{
		return _cache.Remove(url);
	}
}
