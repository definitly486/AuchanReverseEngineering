using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class PersonalOrderedAlgorithm : AbstractAlgorithm<AlgorithmArgument>
{
	public override string Name => "Персональные рекомендации";

	public PersonalOrderedAlgorithm(ICache cache, AlgorithmArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static PersonalOrderedAlgorithm Create(IResolver resolver, AlgorithmArgument argument)
	{
		return resolver.Resolve<PersonalOrderedAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.PersonalOrdered(BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"personal_ordered_{activeStore.Id}";
	}
}
