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

public class PersonalViewedEndlessAlgorithm : AbstractEndlessAlgorithm<AlgorithmArgument>
{
	public override string Name => "Вы смотрели";

	public PersonalViewedEndlessAlgorithm(Lazy<IRecommendationsGimaIdCache> recommendationsGimaIdCache, IMemoryCache memoryCache, AlgorithmArgument argument)
		: base(recommendationsGimaIdCache, memoryCache, argument)
	{
	}

	public static PersonalViewedEndlessAlgorithm Create(IResolver resolver, AlgorithmArgument argument)
	{
		return resolver.Resolve<PersonalViewedEndlessAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.PersonalViewed(BlockId, RecomendationAnalyticActionsTag.Generic, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"personal_viewed_{activeStore.Id}";
	}
}
