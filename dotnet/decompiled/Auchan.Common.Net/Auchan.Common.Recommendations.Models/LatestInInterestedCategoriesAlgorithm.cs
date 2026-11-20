using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.Models;

public sealed class LatestInInterestedCategoriesAlgorithm : AbstractAlgorithm<AlgorithmArgument>
{
	private const string CACHE_KEY_PREFIX = "F04DBD4D-8B99-4078-9E34-BBE68193C75B-";

	public override string Name => "LatestInInterestedCategoriesAlgorithm";

	public LatestInInterestedCategoriesAlgorithm(ICache cache, AlgorithmArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return "F04DBD4D-8B99-4078-9E34-BBE68193C75B-" + activeStore.Id;
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.LatestInInterestedCategories(BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}
}
