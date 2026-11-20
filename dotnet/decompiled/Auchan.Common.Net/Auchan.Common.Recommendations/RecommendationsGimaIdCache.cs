using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Ecom;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Recommendations;

internal sealed class RecommendationsGimaIdCache : IRecommendationsGimaIdCache
{
	private Dictionary<IAlgorithm, RecommendationList> _responseCache = new Dictionary<IAlgorithm, RecommendationList>();

	public RecommendationsGimaIdCache(IEcomContext ecomContext)
	{
		ecomContext.AfterAddressSet += delegate
		{
			Clear();
			return Task.CompletedTask;
		};
	}

	public int Count(IAlgorithm algorithm)
	{
		if (_responseCache.ContainsKey(algorithm))
		{
			return _responseCache[algorithm].Items.Count();
		}
		return 0;
	}

	public void Clear(IAlgorithm algorithm)
	{
		_responseCache.Remove(algorithm);
	}

	public void Clear()
	{
		_responseCache.Clear();
	}

	public bool TryGetCachedRecommendationResponse(IAlgorithm algorithm, [NotNullWhen(true)] out RecommendationList? response)
	{
		if (_responseCache.ContainsKey(algorithm) && _responseCache[algorithm].Items.Any() && _responseCache[algorithm].CacheTime > TimeSpan.Zero)
		{
			response = _responseCache[algorithm];
			return true;
		}
		response = null;
		return false;
	}

	public void Cache(IAlgorithm algorithm, RecommendationList response)
	{
		_responseCache[algorithm] = response;
	}
}
