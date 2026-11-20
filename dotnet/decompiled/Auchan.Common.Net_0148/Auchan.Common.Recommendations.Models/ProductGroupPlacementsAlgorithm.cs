using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using Auchan.Common.Recommendations.API.DTO;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

internal sealed class ProductGroupPlacementsAlgorithm : AbstractAlgorithm<ProductGroupPlacementsArgument>
{
	public override string Name => "ProductGroupPlacementsAlgorithm";

	public ProductGroupPlacementsAlgorithm(ICache cache, ProductGroupPlacementsArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static ProductGroupPlacementsAlgorithm Create(IResolver resolver, ProductGroupPlacementsArgument argument)
	{
		return resolver.Resolve<ProductGroupPlacementsAlgorithm>(new object[1] { argument });
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"{Name}_{activeStore.Id}_{base.Argument.PlacementId}";
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		PlacementId placementId = base.Argument.PlacementId;
		string blockId = BlockId;
		List<long> list = new List<long>();
		list.AddRange(base.Argument.GimaIds.Take(30));
		return apiService.GetProductGroupPlacementsAsync(placementId, blockId, RecomendationAnalyticActionsTag.ProductPlacements, new _003C_003Ez__ReadOnlyList<long>(list), token);
	}
}
