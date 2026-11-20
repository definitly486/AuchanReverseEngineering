using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.Models;

public sealed class LatestByCategoryPathAlgorithm : AbstractAlgorithm<AlgorithmArgument>
{
	public override string Name => "LatestByCategoryPathAlgorithm";

	public LatestByCategoryPathAlgorithm(ICache cache, AlgorithmArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.LatestByCategoryPath(BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return $"novelty_{activeStore.Id}";
	}

	public override IReadOnlyList<Product> MapProducts(IReadOnlyList<Product> products)
	{
		return products.Where((Product x) => x.IsNew).ToImmutableList();
	}
}
