using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class PersonalAlgorithm : AbstractAlgorithm<AlgorithmArgument>
{
	public override string Name => "Персональные рекомендации";

	public PersonalAlgorithm(ICache cache, AlgorithmArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static PersonalAlgorithm Create(IResolver resolver, AlgorithmArgument argument)
	{
		return resolver.Resolve<PersonalAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.Personal(BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"personal_{activeStore.Id}";
	}
}
