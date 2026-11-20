using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Recommendations.API;

public interface IRecommendationApi
{
	[Get("/partnerRecommendations/personalComposite/")]
	Task<HttpResponseMessage> PersonalRecommendations(CancellationToken token = default(CancellationToken));

	[Get("/categoryRecommendations/latestByCategoryPath")]
	Task<HttpResponseMessage> LatestByCategoryPath([Query(CollectionFormat.Multi)][AliasAs("categoryPaths")] IReadOnlyList<string> categoryPaths, CancellationToken token = default(CancellationToken));

	[Get("/partnerRecommendations/latestInInterestedCategories")]
	Task<HttpResponseMessage> LatestInInterestedCategories(CancellationToken token = default(CancellationToken));

	[Get("/partnerRecommendations/personalViewed")]
	Task<HttpResponseMessage> PersonalViewed(CancellationToken token = default(CancellationToken));

	[Get("/partnerRecommendations/personalOrdered")]
	Task<HttpResponseMessage> PersonalOrdered(CancellationToken token = default(CancellationToken));

	[Get("/productRecommendations/relatedWithoutCurrentCategory/")]
	Task<HttpResponseMessage> Related([AliasAs("productIds")] IReadOnlyList<string> productIds, CancellationToken token = default(CancellationToken));

	[Get("/productRecommendations/crosssellForLargeBaskets/")]
	Task<HttpResponseMessage> CrossSellForLargeBaskets([AliasAs("productIds")] IReadOnlyList<string> productIds, CancellationToken token = default(CancellationToken));

	[Get("/productRecommendations/alternatives/")]
	Task<HttpResponseMessage> Alternatives([Query(",")] IReadOnlyList<string> productIds, CancellationToken token = default(CancellationToken));

	[Get("/productRecommendations/analogsForOutOfStockProducts")]
	Task<HttpResponseMessage> AnalogsOutOfStockProducts([Query(",")] IReadOnlyList<string> productIds, CancellationToken token = default(CancellationToken));

	[Get("/categoryRecommendations/sortItemsInCategory")]
	Task<HttpResponseMessage> SortItemsInCategory([AliasAs("categoryid")] string categoryId, CancellationToken token = default(CancellationToken));

	[Get("/partnerRecommendations/popularInInterestedCategories")]
	Task<HttpResponseMessage> PopularInInterestedCategories(CancellationToken token = default(CancellationToken));

	[Get("/categoryRecommendations/popular/")]
	Task<HttpResponseMessage> PopularInCategory([Query(",")] IReadOnlyList<string> categoryIds, CancellationToken token = default(CancellationToken));

	[Get("/categoryRecommendations/popularByCategoryPath/")]
	Task<HttpResponseMessage> PopularInCategoryByPath([Query("&")] IReadOnlyList<string> categoryPaths, CancellationToken token = default(CancellationToken));

	[Get("/categoryRecommendations/saleByPopularByCategoryPath/")]
	Task<HttpResponseMessage> SaleByPopularInCategoryByPath([Query] IReadOnlyList<string> categoryPaths, CancellationToken token = default(CancellationToken));

	[Get("/searchRecommendations/searchWithNeuralNetworks/")]
	Task<HttpResponseMessage> Search([AliasAs("searchPhrase")] string searchPhrase, CancellationToken token = default(CancellationToken));

	[Get("/partnerRecommendations/personalCompositeForCategoryByCategoryPath")]
	Task<HttpResponseMessage> PersonalCompositeForCategoryByCategoryPath([AliasAs("categoryPaths")] string categoryPaths, CancellationToken token = default(CancellationToken));

	[Get("/categoryRecommendations/popularByInterestedPropertiesByCategoryPath")]
	Task<HttpResponseMessage> PopularByInterestedPropertiesByCategoryPath([AliasAs("categoryPaths")] string categoryPaths, CancellationToken token = default(CancellationToken));
}
