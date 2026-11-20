using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.Models;

public abstract class AbstractEndlessAlgorithm<T> : AbstractAlgorithm<T>, IAbstractEndlessAlgorithm, IAlgorithm where T : AlgorithmArgument
{
	protected readonly Lazy<IRecommendationsGimaIdCache> _recommendationsGimaIdCache;

	public int ProductsOffset { get; protected set; }

	public bool LoadedAll { get; protected set; }

	public bool LoadingFailed { get; set; }

	public AbstractEndlessAlgorithm(Lazy<IRecommendationsGimaIdCache> recommendationsGimaIdCache, IMemoryCache memoryCache, T argument)
		: base((IGenericCache)memoryCache, argument)
	{
		_recommendationsGimaIdCache = recommendationsGimaIdCache;
		LoadedAll = false;
		LoadingFailed = false;
		ProductsOffset = 0;
	}

	public override void AddProductsOffset(int offset)
	{
		ProductsOffset += offset;
	}

	public override bool TrySetLoadedAll()
	{
		int num = _recommendationsGimaIdCache.Value.Count(this);
		return LoadedAll = num == 0 || (num > 0 && ProductsOffset + base.ToSkip >= num);
	}

	public override IReadOnlyList<RecommendationList.Item> MapResponseItems(IReadOnlyList<RecommendationList.Item> items)
	{
		return items.Skip(ProductsOffset + base.ToSkip).TakeSafe(25).ToImmutableList();
	}

	public override async Task<Result<RecommendationList, DomainError>> GetProductIds(IRecommendationService recommendationService)
	{
		IRecommendationsGimaIdCache rpc = _recommendationsGimaIdCache.Value;
		if (rpc.TryGetCachedRecommendationResponse(this, out RecommendationList response))
		{
			return response;
		}
		Result<RecommendationList, DomainError> result = await recommendationService.Get(this);
		if (result.TryGetError(out var error))
		{
			return error;
		}
		RecommendationList value = result.Value;
		rpc.Cache(this, value);
		return result.Value;
	}

	public override void Reset(Store activeStore)
	{
		ProductsOffset = 0;
		LoadedAll = false;
		LoadingFailed = false;
		_recommendationsGimaIdCache.Value.Clear(this);
		string cacheKey = GetCacheKey(activeStore);
		if (cacheKey != null)
		{
			base.Cache.Remove(cacheKey);
		}
	}
}
