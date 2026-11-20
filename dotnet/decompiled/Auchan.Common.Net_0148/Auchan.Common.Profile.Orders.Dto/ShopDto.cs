using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record ShopDto
{
	[JsonProperty("name")]
	public string Name { get; init; } = "";

	[JsonProperty("address_string")]
	public string Address { get; init; } = "";

	[JsonProperty("pickup_description")]
	public string? PickupDescription { get; init; }

	[JsonProperty("pickup_photo_urls")]
	public IReadOnlyList<string>? PickupPhotoUrls { get; init; }

	[JsonProperty("collect_order")]
	public bool? CollectOrder { get; init; }
}
