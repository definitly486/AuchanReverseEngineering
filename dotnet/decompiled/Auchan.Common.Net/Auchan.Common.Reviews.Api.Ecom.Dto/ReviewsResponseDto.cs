using System;
using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.Reviews.Api.Ecom.Dto.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public sealed class ReviewsResponseDto
{
	public sealed class DataDto
	{
		[JsonProperty("qnt")]
		public int Count { get; init; }

		[JsonProperty("reviews")]
		public IReadOnlyList<ReviewDto>? Reviews { get; init; }

		[JsonProperty("has_images")]
		public bool? HasImages { get; init; }

		[JsonProperty("sort")]
		public required SortDto? Sort { get; init; }
	}

	public sealed class ReviewDto
	{
		[JsonProperty("id")]
		public int Id { get; init; }

		[JsonProperty("external_id")]
		public string? ExternalId { get; init; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; init; }

		[JsonProperty("user_name")]
		public string? UserName { get; init; }

		[JsonProperty("rate")]
		public int Rate { get; init; }

		[JsonProperty("text")]
		public string? Text { get; init; }

		[JsonProperty("images")]
		public IReadOnlyList<ImageDto>? Images { get; init; }

		[JsonProperty("comments")]
		public IReadOnlyList<CommentDto>? Comments { get; init; }

		[JsonProperty("status_id")]
		public ReviewStatus Status { get; init; } = ReviewStatus.Published;

		[JsonProperty("title")]
		public string? ProductTitle { get; init; }

		[JsonProperty("image")]
		public string? ProductImage { get; init; }

		[JsonProperty("title_trigger_words")]
		public string? TitleOfTriggerWords { get; init; }

		[JsonProperty("trigger_words")]
		public IReadOnlyList<TriggerWordDto>? TriggerWords { get; init; }
	}

	public sealed class ImageDto
	{
		[JsonProperty("url")]
		public string? Url { get; init; }

		[JsonProperty("thumbnail_url")]
		public string? ThumbnailUrl { get; init; }
	}

	public sealed class CommentDto
	{
		[JsonProperty("id")]
		public int Id { get; init; }

		[JsonProperty("author")]
		public string? Author { get; init; }

		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; init; }

		[JsonProperty("text")]
		public string? Text { get; init; }
	}

	public sealed class SortDto
	{
		[JsonProperty("field")]
		[JsonConverter(typeof(EnumMemberJsonConverter<ReviewSortFieldDto>))]
		public required ReviewSortFieldDto Field { get; init; }

		[JsonProperty("direction")]
		[JsonConverter(typeof(EnumMemberJsonConverter<ReviewSortDirectionDto>))]
		public required ReviewSortDirectionDto Direction { get; init; }
	}

	public sealed class TriggerWordDto
	{
		[JsonProperty("id")]
		public int Id { get; init; }

		[JsonProperty("name")]
		public required string Name { get; init; } = "";
	}

	[JsonProperty("data")]
	public required DataDto? Data { get; init; }

	[JsonProperty("meta")]
	public required OffsetPaginationMetaDto? Meta { get; init; }
}
