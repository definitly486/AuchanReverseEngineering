using Auchan.Common.Reviews.Api.Ecom.Dto.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public sealed class ReviewsRequestBodyDto
{
	public sealed class SortDto
	{
		[JsonProperty("field")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ReviewSortFieldDto Field { get; init; }

		[JsonProperty("direction")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ReviewSortDirectionDto Direction { get; init; }
	}

	[JsonProperty("gima_id", NullValueHandling = NullValueHandling.Ignore)]
	public string? GimaId { get; init; }

	[JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
	public string? Code { get; init; }

	[JsonProperty("images_first")]
	public bool ImagesFirst { get; init; }

	[JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
	public SortDto? Sort { get; init; }

	[JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
	public OffsetPaginationDto? Pagination { get; init; }
}
