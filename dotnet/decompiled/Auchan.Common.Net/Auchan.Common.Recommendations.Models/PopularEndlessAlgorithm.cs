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

public sealed class PopularEndlessAlgorithm : AbstractEndlessAlgorithm<PopularEndlessArgument>
{
	public override string Name => "Популярные товары для главного экрана";

	public override bool IsNeedToShowAllProducts => true;

	public PopularEndlessAlgorithm(Lazy<IRecommendationsGimaIdCache> recommendationsGimaIdCache, IMemoryCache memoryCache, PopularEndlessArgument argument)
		: base(recommendationsGimaIdCache, memoryCache, argument)
	{
	}

	public static PopularEndlessAlgorithm Create(IResolver resolver, PopularEndlessArgument argument)
	{
		return resolver.Resolve<PopularEndlessAlgorithm>(new object[1] { argument });
	}

	public override async Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		Result<RecommendationList, DomainError>[] obj = await Task.WhenAll<Result<RecommendationList, DomainError>>(apiService.PopularInInterestedCategories(base.Argument.PersonalizedBlockId, RecomendationAnalyticActionsTag.Generic, token), apiService.SortItemsInCategory(base.Argument.GenericBlockId, RecomendationAnalyticActionsTag.Popular, token));
		Result<RecommendationList, DomainError> result = obj[0];
		Result<RecommendationList, DomainError> result2 = obj[1];
		Result<RecommendationList, DomainError> result3 = result;
		if (result3.TryGetValue(out var value) && result2.TryGetValue(out var value2))
		{
			return value.MergeWith(value2);
		}
		if (result3.IsSuccess)
		{
			return result3;
		}
		return result2;
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"popular_{activeStore.Id}";
	}
}
