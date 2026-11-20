using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

internal sealed class AnyPlacementAlgorithm : AbstractAlgorithm<ProductPlacementArgument>
{
	public override string Name => "AnyPlacementAlgorithm";

	public AnyPlacementAlgorithm(ICache cache, ProductPlacementArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static AnyPlacementAlgorithm Create(IResolver resolver, ProductPlacementArgument argument)
	{
		return resolver.Resolve<AnyPlacementAlgorithm>(new object[1] { argument });
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"{Name}_{activeStore.Id}_{base.Argument.PlacementId}";
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.GetAnyPlacementsAsync(base.Argument.PlacementId, base.Argument.BlockId, RecomendationAnalyticActionsTag.ProductPlacements, token);
	}
}
