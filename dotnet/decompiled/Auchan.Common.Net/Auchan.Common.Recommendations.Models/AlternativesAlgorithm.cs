using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class AlternativesAlgorithm : AbstractAlgorithm<AlternativesArgument>
{
	public override string Name => "Альтернативные товары";

	public AlternativesAlgorithm(ICache cache, AlternativesArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static AlternativesAlgorithm Create(IResolver resolver, AlternativesArgument argument)
	{
		return resolver.Resolve<AlternativesAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.Alternatives(base.Argument.ProductIds, base.Argument.BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		if (base.Argument.ProductIds.Count == 1)
		{
			return $"alternatives_{base.Argument.ProductIds[0]}_{activeStore.Id}";
		}
		return null;
	}
}
