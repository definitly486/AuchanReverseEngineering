using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Auchan.Common.Reviews.Api.Ecom.Dto.Enums;
using Auchan.Common.Reviews.Model;
using CSharpFunctionalExtensions;
using Refit;

namespace Auchan.Common.Reviews;

public class ReviewsEcomService
{
	private readonly IRequestExecutor _requestExecutor;

	private readonly IReviewsEcomApi _reviewsEcomApi;

	public ReviewsEcomService(IReviewsEcomApi reviewsEcomApi, IRequestExecutor requestExecutor)
	{
		_reviewsEcomApi = reviewsEcomApi;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<CheckAddingResponseDto, DomainError>> CheckAdding(int gimaId, string channel)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.CheckAdding(accessToken.Token, gimaId, channel))).Map((CheckAddingResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<UploadImagesResponseDto, DomainError>> UploadImages(IEnumerable<StreamPart> streamParts)
	{
		return (await _requestExecutor.ExecuteWithTokenAndCustomTimeout((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.UploadImages(accessToken, streamParts), 60)).Map((UploadImagesResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<AddReviewResponseDto, DomainError>> Create(ReviewCreateRequestDto addReviewRequestDto)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.Create(accessToken.Token, addReviewRequestDto))).Map((AddReviewResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ReviewFormSettingsDataDto, DomainError>> GetFormSettings(int? gimaId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.FormSettings(accessToken.Token, gimaId, cancellationToken))).Map((ReviewFormSettingsResponseDto dto) => dto.GetPayload() ?? new ReviewFormSettingsDataDto(), (ServiceError err) => err.ToBaseDomainError());
	}

	public Task<Result<ReviewList, DomainError>> GetProductReviewsAsync(string? productCode, string? gimaId)
	{
		ReviewsRequestBodyDto body = new ReviewsRequestBodyDto
		{
			Code = productCode,
			GimaId = gimaId,
			ImagesFirst = false,
			Pagination = new OffsetPaginationDto
			{
				Limit = 100
			}
		};
		return GetProductReviewsAsync(body);
	}

	public Task<Result<ReviewList, DomainError>> GetProductReviewsAsync(string? productCode, string? gimaId, bool imageFirst, ReviewSortField sortBy, ReviewSortDirection sortDirection)
	{
		ReviewsRequestBodyDto body = new ReviewsRequestBodyDto
		{
			Code = productCode,
			GimaId = gimaId,
			ImagesFirst = imageFirst,
			Sort = new ReviewsRequestBodyDto.SortDto
			{
				Field = (ReviewSortFieldDto)sortBy,
				Direction = (ReviewSortDirectionDto)sortDirection
			},
			Pagination = new OffsetPaginationDto
			{
				Limit = 100
			}
		};
		return GetProductReviewsAsync(body);
	}

	private async Task<Result<ReviewList, DomainError>> GetProductReviewsAsync(ReviewsRequestBodyDto body)
	{
		return (await _requestExecutor.Execute((CancellationToken cancellationToken) => _reviewsEcomApi.ProductReviews(body, cancellationToken))).Map((ReviewsResponseDto dto) => dto.Map(body), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<bool, DomainError>> CheckShouldDisplayMyReviewsAsync()
	{
		UnreviewedProductsRequestBodyDto body = new UnreviewedProductsRequestBodyDto
		{
			Pagination = new OffsetPaginationDto
			{
				Limit = 0
			}
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.Products(accessToken.Token, body))).Map((UnreviewedProductsResponseDto dto) => dto.Data?.MyReviewsSectionVisible == true, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<(IReadOnlyList<UnreviewedProductItemViewModel>, int), DomainError>> GetUnreviewedProductsAsync(int offset, int limit)
	{
		UnreviewedProductsRequestBodyDto body = new UnreviewedProductsRequestBodyDto
		{
			Pagination = new OffsetPaginationDto
			{
				Limit = limit,
				Offset = offset
			}
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.Products(accessToken.Token, body))).Map((UnreviewedProductsResponseDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<(IReadOnlyList<Review>, int), DomainError>> GetUserReviewsAsync(int offset, int limit)
	{
		ReviewsRequestBodyDto body = new ReviewsRequestBodyDto
		{
			Pagination = new OffsetPaginationDto
			{
				Limit = limit,
				Offset = offset
			}
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.UserReviews(accessToken.Token, body))).Map(delegate(ReviewsResponseDto dto)
		{
			ReviewList reviewList = dto.Map(body);
			return (Reviews: reviewList.Reviews, Count: reviewList.Count);
		}, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<bool, DomainError>> CheckIfPopupNeeded()
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.CheckIfPopupNeeded(accessToken, cancellationToken))).Map((ProductsPopupResponseDto dto) => dto.Data?.PopupNeeded == true, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<string, DomainError>> HideProductFromUnreviewed(string gimaId)
	{
		HideFromUnreviewedRequestBodyDto body = new HideFromUnreviewedRequestBodyDto
		{
			GimaId = gimaId
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _reviewsEcomApi.HideProductFromUnreviewed(accessToken, body, cancellationToken))).Map((string dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
