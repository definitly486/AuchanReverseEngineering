using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Recommendations.API.Requests;
using Refit;

namespace Auchan.Common.Recommendations.API;

internal interface ITrackingApi
{
	[Post("/view")]
	Task<HttpResponseMessage> ViewProduct([Body] ProductTrackingRequest request, CancellationToken token = default(CancellationToken));

	[Post("/addToBasket")]
	Task<HttpResponseMessage> AddToCart([Body] ProductTrackingRequest request, CancellationToken token = default(CancellationToken));

	[Post("/order")]
	Task<HttpResponseMessage> Order([Body] OrderTrackingRequest request, CancellationToken token = default(CancellationToken));

	[Post("/categoryView")]
	Task<HttpResponseMessage> ViewCategory([Body] CategoryViewTrackingRequest request, CancellationToken token = default(CancellationToken));

	[Post("/categoryViewByCategoryPath")]
	Task<HttpResponseMessage> ViewCategoryByPath([Body] CategoryViewByPathTrackingRequest request, CancellationToken token = default(CancellationToken));

	[Post("/search")]
	Task<HttpResponseMessage> Search([Body] SearchTrackingRequest request, CancellationToken token = default(CancellationToken));

	[Post("/visitorEvents")]
	Task<HttpResponseMessage> BatchUpload([Body] IList<BatchItemRequest> body, CancellationToken token = default(CancellationToken));

	[Post("/recomTap")]
	Task<HttpResponseMessage> RecommendationTap([Body] RecomItemInteractionRequest body, CancellationToken token = default(CancellationToken));

	[Post("/recomAddToBasket")]
	Task<HttpResponseMessage> RecommendationAddedToBasket([Body] RecomItemInteractionRequest body, CancellationToken token = default(CancellationToken));

	[Post("/recomBlockViewed")]
	Task<HttpResponseMessage> RecommendationBlockViewed([Body] RecomBlockViewedRequest body, CancellationToken token = default(CancellationToken));

	[Post("/setCustomer")]
	Task<HttpResponseMessage> SetCustomer([Body] CustomerInfoRequest customerInfo, CancellationToken token = default(CancellationToken));

	[Post("/impressionContentViewed")]
	Task<HttpResponseMessage> ProductPlacementViewed([Body] ProductPlacementTrackingRequest body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/impressionContentClicked")]
	Task<HttpResponseMessage> ProductPlacementClicked([Body] ProductPlacementTrackingRequest body, CancellationToken cancellationToken = default(CancellationToken));
}
