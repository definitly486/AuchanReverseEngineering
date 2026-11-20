using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.API.Requests;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.API;

internal interface ITrackingApiService
{
	Task<Result<Unit, DomainError>> ViewProduct(ProductTrackingRequest request, CancellationToken token);

	Task<Result<Unit, DomainError>> AddToCart(ProductTrackingRequest request, CancellationToken token);

	Task<Result<Unit, DomainError>> Order(OrderTrackingRequest request, CancellationToken token);

	Task<Result<Unit, DomainError>> ViewCategory(CategoryViewTrackingRequest request, CancellationToken token);

	Task<Result<Unit, DomainError>> ViewCategoryByPath(CategoryViewByPathTrackingRequest request, CancellationToken token);

	Task<Result<Unit, DomainError>> Search(SearchTrackingRequest request, CancellationToken token);

	Task<Result<Unit, DomainError>> BatchUpload(IList<BatchItemRequest> request, CancellationToken token);

	Task<Result<Unit, DomainError>> RecommendationTap(RecomItemInteractionRequest request, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> RecommendationAddedToBasket(RecomItemInteractionRequest request, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> RecommendationBlockViewed(RecomBlockViewedRequest request, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> SetCustomer(CustomerInfoRequest customerInfo, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> ProductPlacementViewed(ProductPlacementTrackingRequest request, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> ProductPlacementClicked(ProductPlacementTrackingRequest request, CancellationToken token = default(CancellationToken));
}
