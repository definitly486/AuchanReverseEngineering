using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Refit;

namespace Auchan.Common.Reviews;

public interface IReviewsEcomApi
{
	[Get("/reviews/check-adding")]
	Task<CheckAddingResponseDto> CheckAdding([Header("X-Token-CMD")] string accessToken, [Query][AliasAs("gima_id")] int gimaId, [Query][AliasAs("channel")] string channel, CancellationToken token = default(CancellationToken));

	[Multipart("----MyGreatBoundary")]
	[Post("/reviews/upload-images")]
	Task<UploadImagesResponseDto> UploadImages([Header("X-Token-CMD")] string accessToken, [AliasAs("files[]")] IEnumerable<StreamPart> streams, CancellationToken token = default(CancellationToken));

	[Post("/reviews/create")]
	Task<AddReviewResponseDto> Create([Header("X-Token-CMD")] string accessToken, [Body] ReviewCreateRequestDto body, CancellationToken token = default(CancellationToken));

	[Get("/reviews/form-settings")]
	Task<ReviewFormSettingsResponseDto> FormSettings([Header("X-Token-CMD")] string accessToken, [Query][AliasAs("gima_id")] int? gimaId, CancellationToken token = default(CancellationToken));

	[Post("/reviews/reviews")]
	Task<ReviewsResponseDto> ProductReviews([Body] ReviewsRequestBodyDto data, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/reviews/products")]
	Task<UnreviewedProductsResponseDto> Products([Header("X-Token-CMD")] string accessToken, [Body] UnreviewedProductsRequestBodyDto body, CancellationToken token = default(CancellationToken));

	[Post("/reviews/user-reviews")]
	Task<ReviewsResponseDto> UserReviews([Header("X-Token-CMD")] string accessToken, [Body] ReviewsRequestBodyDto data, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/reviews/popup-checking")]
	Task<ProductsPopupResponseDto> CheckIfPopupNeeded([Header("X-Token-CMD")] string accessToken, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/reviews/products:hide")]
	Task<string> HideProductFromUnreviewed([Header("X-Token-CMD")] string accessToken, [Body] HideFromUnreviewedRequestBodyDto body, CancellationToken token = default(CancellationToken));
}
