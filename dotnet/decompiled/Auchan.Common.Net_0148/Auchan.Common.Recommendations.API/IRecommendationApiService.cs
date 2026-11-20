using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.API;

public interface IRecommendationApiService
{
	Task<Result<RecommendationList, DomainError>> Personal(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> LatestByCategoryPath(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> Related(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> Alternatives(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> AnalogsOutOfStockProducts(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> Search(string searchPhrase, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PopularInCategory(IReadOnlyList<string> categoryIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PopularInCategoryByPath(IReadOnlyList<string> categoryPaths, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> SaleByPopularInCategoryByPath(IReadOnlyList<string> categoryPaths, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PersonalViewed(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PersonalOrdered(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> SortItemsInCategory(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> LatestInInterestedCategories(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PopularInInterestedCategories(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PersonalCompositeForCategoryByCategoryPath(string categoryPath, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> PopularByInterestedPropertiesByCategoryPath(string categoryPath, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> GetAnyPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> GetCategoryPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, string categoryPath, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> GetProductGroupPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, IReadOnlyList<long> allProductsInCartGimaIds, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> GetProductPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, long productGimaId, CancellationToken token = default(CancellationToken));

	Task<Result<RecommendationList, DomainError>> CrossSellForLargeBaskets(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken));
}
