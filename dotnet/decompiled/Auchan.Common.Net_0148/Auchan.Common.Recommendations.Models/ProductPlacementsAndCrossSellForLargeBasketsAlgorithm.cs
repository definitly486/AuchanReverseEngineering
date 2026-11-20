using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

internal sealed class ProductPlacementsAndCrossSellForLargeBasketsAlgorithm : AbstractAlgorithm<ProductPlacementsAndCrossSellForLargeBasketsArgument>
{
	public override string Name => "ProductPlacementsAndCrossSellForLargeBasketsAlgorithm";

	public ProductPlacementsAndCrossSellForLargeBasketsAlgorithm(ICache cache, ProductPlacementsAndCrossSellForLargeBasketsArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static ProductPlacementsAndCrossSellForLargeBasketsAlgorithm Create(IResolver resolver, ProductPlacementsAndCrossSellForLargeBasketsArgument argument)
	{
		return resolver.Resolve<ProductPlacementsAndCrossSellForLargeBasketsAlgorithm>(new object[1] { argument });
	}

	public override async Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		Task<Result<RecommendationList, DomainError>> task = apiService.CrossSellForLargeBaskets(new global::_003C_003Ez__ReadOnlySingleElementList<string>(base.Argument.ProductGimaId.ToString()), BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
		Task<Result<RecommendationList, DomainError>> productPlacementsAsync = apiService.GetProductPlacementsAsync(base.Argument.PlacementId, BlockId, RecomendationAnalyticActionsTag.ProductPlacements, base.Argument.ProductGimaId, token);
		Result<RecommendationList, DomainError>[] obj = await Task.WhenAll<Result<RecommendationList, DomainError>>(task, productPlacementsAsync);
		Result<RecommendationList, DomainError> result = obj[0];
		Result<RecommendationList, DomainError> result2 = obj[1];
		Result<RecommendationList, DomainError> result3 = result;
		if (result3.TryGetValue(out var value) && result2.TryGetValue(out var value2))
		{
			return value2.MergeWith(value);
		}
		if (result2.IsSuccess)
		{
			return result2;
		}
		return result3;
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return null;
	}
}
