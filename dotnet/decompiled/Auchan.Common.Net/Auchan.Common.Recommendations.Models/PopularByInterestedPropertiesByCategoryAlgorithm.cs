using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class PopularByInterestedPropertiesByCategoryAlgorithm : AbstractAlgorithm<PopularByInterestedPropertiesByCategoryArgument>
{
	private static readonly TimeSpan CACHE_TIME = TimeSpan.FromMinutes(15L);

	public override string Name => "PopularByInterestedPropertiesByCategoryAlgorithm";

	public override TimeSpan MaxCacheTime => CACHE_TIME;

	public PopularByInterestedPropertiesByCategoryAlgorithm(ICache cache, PopularByInterestedPropertiesByCategoryArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static PopularByInterestedPropertiesByCategoryAlgorithm Create(IResolver resolver, PopularByInterestedPropertiesByCategoryArgument argument)
	{
		return resolver.Resolve<PopularByInterestedPropertiesByCategoryAlgorithm>(new object[1] { argument });
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"{Name}_{activeStore.Id}_{base.Argument.CategoryPath}";
	}

	public override async Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		Result<RecommendationList, DomainError> result = await apiService.PopularByInterestedPropertiesByCategoryPath(base.Argument.CategoryPath, BlockId, RecomendationAnalyticActionsTag.Generic, token);
		if (result.TryGetValue(out var value))
		{
			value.CacheTime = CACHE_TIME;
			return value;
		}
		return result;
	}
}
