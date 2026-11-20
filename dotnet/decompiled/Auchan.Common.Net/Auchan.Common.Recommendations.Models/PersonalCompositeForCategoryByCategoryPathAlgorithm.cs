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

public sealed class PersonalCompositeForCategoryByCategoryPathAlgorithm : AbstractAlgorithm<PersonalCompositeForCategoryByCategoryPathArgument>
{
	private static readonly TimeSpan CACHE_TIME = TimeSpan.FromMinutes(15L);

	public override string Name => "PersonalCompositeForCategoryByCategoryPathAlgorithm";

	public override TimeSpan MaxCacheTime => CACHE_TIME;

	public PersonalCompositeForCategoryByCategoryPathAlgorithm(ICache cache, PersonalCompositeForCategoryByCategoryPathArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static PersonalCompositeForCategoryByCategoryPathAlgorithm Create(IResolver resolver, PersonalCompositeForCategoryByCategoryPathArgument argument)
	{
		return resolver.Resolve<PersonalCompositeForCategoryByCategoryPathAlgorithm>(new object[1] { argument });
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"{Name}_{activeStore.Id}_{base.Argument.CategoryPath}";
	}

	public override async Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		Result<RecommendationList, DomainError> result = await apiService.PersonalCompositeForCategoryByCategoryPath(base.Argument.CategoryPath, BlockId, RecomendationAnalyticActionsTag.Generic, token);
		if (result.TryGetValue(out var value))
		{
			value.CacheTime = CACHE_TIME;
			return value;
		}
		return result;
	}
}
