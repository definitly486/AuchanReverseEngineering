using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Auchan.Common.Reviews.Api.Ecom.Dto.Enums;

namespace Auchan.Common.Reviews.Model;

public static class ReviewMapper
{
	public static Rate Map(this RateDto rateDto)
	{
		return new Rate
		{
			Rating = Math.Round(rateDto.Rating.GetValueOrDefault(), 1),
			Rate1 = rateDto.Rate1,
			Rate2 = rateDto.Rate2,
			Rate3 = rateDto.Rate3,
			Rate4 = rateDto.Rate4,
			Rate5 = rateDto.Rate5,
			ReviewsCount = rateDto.ReviewsCount
		};
	}

	public static IReadOnlyList<ReviewImage> Map(this IReadOnlyList<ReviewsResponseDto.ImageDto>? list)
	{
		if (list == null || !list.Any())
		{
			return Array.Empty<ReviewImage>();
		}
		return list.Select((ReviewsResponseDto.ImageDto img) => new ReviewImage
		{
			Url = img.Url,
			ThumbnailUrl = img.ThumbnailUrl
		}).ToImmutableList();
	}

	public static IReadOnlyList<ReviewComment> Map(this IReadOnlyList<ReviewsResponseDto.CommentDto>? list)
	{
		if (list == null || !list.Any())
		{
			return Array.Empty<ReviewComment>();
		}
		return list.Select((ReviewsResponseDto.CommentDto c) => new ReviewComment
		{
			Id = c.Id,
			Author = c.Author,
			CreatedAt = c.CreatedAt,
			Text = (c.Text ?? "")
		}).ToImmutableList();
	}

	public static Review Map(this ReviewsResponseDto.ReviewDto review)
	{
		return new Review
		{
			Id = review.Id,
			ExternalId = review.ExternalId,
			CreatedAt = review.CreatedAt,
			UserName = review.UserName,
			Rate = review.Rate,
			Text = (review.Text ?? ""),
			Images = review.Images.Map(),
			Comments = review.Comments.Map(),
			Status = review.Status,
			ProductTitle = review.ProductTitle,
			ProductImage = review.ProductImage,
			TitleOfTriggerWords = (review.TitleOfTriggerWords ?? ""),
			TriggerWords = review.TriggerWords.Map()
		};
	}

	public static ReviewList Map(this ReviewsResponseDto response, ReviewsRequestBodyDto request)
	{
		if (response.Data?.Reviews == null || !response.Data.Reviews.Any())
		{
			return ReviewList.Empty;
		}
		return new ReviewList
		{
			Reviews = response.Data.Reviews.Select((ReviewsResponseDto.ReviewDto dto) => dto.Map()).ToImmutableList(),
			Count = response.Data.Count,
			HasImages = (response.Data.HasImages == true),
			SortDirection = (response.Data.Sort?.Direction ?? request.Sort?.Direction ?? ReviewSortDirectionDto.Descend).Map(),
			SortField = (response.Data.Sort?.Field ?? request.Sort?.Field ?? ReviewSortFieldDto.Rate).Map()
		};
	}

	public static ReviewSortDirection Map(this ReviewSortDirectionDto @this)
	{
		return (ReviewSortDirection)@this;
	}

	public static ReviewSortField Map(this ReviewSortFieldDto @this)
	{
		return (ReviewSortField)@this;
	}

	public static (IReadOnlyList<UnreviewedProductItemViewModel>, int) Map(this UnreviewedProductsResponseDto response)
	{
		int valueOrDefault = (response.Data?.Count).GetValueOrDefault();
		if (response.Data == null)
		{
			return (new List<UnreviewedProductItemViewModel>(), 0);
		}
		if (response.Data.Products == null || response.Data.Products.Count == 0)
		{
			return (new List<UnreviewedProductItemViewModel>(), valueOrDefault);
		}
		IEnumerable<UnreviewedProductDto> source = response.Data.Products.Where((UnreviewedProductDto p) => !string.IsNullOrEmpty(p.Code) || !string.IsNullOrEmpty(p.GimaId));
		if (source.Count() == 0)
		{
			return (new List<UnreviewedProductItemViewModel>(), valueOrDefault);
		}
		return (source.Select((UnreviewedProductDto p) => new UnreviewedProductItemViewModel(new UnreviewedProduct(p.Code, p.GimaId, p.Title, p.ImageUrl, p.ReviewRewardSticker?.Map()))).ToList(), valueOrDefault);
	}

	public static IReadOnlyList<TriggerWord> Map(this IReadOnlyList<ReviewsResponseDto.TriggerWordDto>? @this)
	{
		if (@this == null)
		{
			return ImmutableList<TriggerWord>.Empty;
		}
		return @this.Select((ReviewsResponseDto.TriggerWordDto i) => new TriggerWord
		{
			Id = i.Id,
			Content = i.Name
		}).ToImmutableList();
	}
}
