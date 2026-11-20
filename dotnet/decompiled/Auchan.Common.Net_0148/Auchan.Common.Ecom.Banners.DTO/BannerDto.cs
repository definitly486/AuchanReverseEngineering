using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Banners.DTO;

internal sealed class BannerDto
{
	public sealed class NavigatedDto
	{
		[JsonProperty("url")]
		public string? Url { get; init; }

		[JsonProperty("deeplink")]
		public string? Deeplink { get; init; }

		[JsonProperty("category_id")]
		public long? CategoryId { get; init; }

		[JsonProperty("category_code")]
		public string? CategoryCode { get; init; }

		[JsonProperty("category_name")]
		public string? CategoryName { get; init; }

		[JsonProperty("product_code")]
		public string? ProductCode { get; init; }

		[JsonProperty("native")]
		public string? Native { get; init; }
	}

	public sealed class PromoContentDto
	{
		[JsonProperty("title")]
		public string? Title { get; init; }

		[JsonProperty("description")]
		public string? Description { get; init; }

		[JsonProperty("link_text")]
		public string? LinkText { get; init; }

		[JsonProperty("link")]
		public string? Link { get; init; }
	}

	[JsonProperty("id")]
	public required int Id { get; init; }

	[JsonProperty("name")]
	public required string Name { get; init; }

	[JsonProperty("type")]
	public required BannerTypeDto Type { get; init; }

	[JsonProperty("rank")]
	public int Priority { get; init; } = int.MaxValue;

	[JsonProperty("mob_image")]
	public string? Image { get; init; }

	[JsonProperty("animation")]
	public string? Animation { get; init; }

	[JsonProperty("short_picture")]
	public string? ShortPicture { get; init; }

	[JsonProperty("carousel_picture")]
	public string? CarouselPicture { get; init; }

	[JsonProperty("navigated_to")]
	public NavigatedDto? NavigateTo { get; init; }

	[JsonProperty("promo_content")]
	public PromoContentDto? PromoContent { get; init; }

	[JsonProperty("categories")]
	public IReadOnlyList<long>? Categories { get; init; }

	[JsonProperty("brand_id")]
	public long BrandId { get; init; }
}
