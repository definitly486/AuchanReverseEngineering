using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Recommendations.API.DTO;
using Refit;

namespace Auchan.Common.Recommendations.API;

internal interface IProductPlacementsApi
{
	[Get("/anyPlacements/{placementId}/impressions")]
	Task<HttpResponseMessage> GetAnyPlacementsAsync(PlacementId placementId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/productGroupPlacements/{placementId}/impressions")]
	Task<HttpResponseMessage> GetProductGroupPlacementsAsync(PlacementId placementId, [AliasAs("productIds")] IReadOnlyList<long> productGimaIdsInTheCart, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/categoryPlacements/{placementId}/impressions")]
	Task<HttpResponseMessage> GetCategoryPlacementsAsync(PlacementId placementId, [AliasAs("categoryPath")] string categoryPath, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/productPlacements/{placementId}/impressions")]
	Task<HttpResponseMessage> GetProductPlacementsAsync(PlacementId placementId, [AliasAs("productId")] long productGimaId, CancellationToken cancellationToken = default(CancellationToken));
}
