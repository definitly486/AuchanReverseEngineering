using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record SelfPickupPointInfoDto
{
	[JsonProperty("text")]
	public string Description { get; init; } = "";

	[JsonProperty("schema_url")]
	public string? ImageUrl { get; init; }

	[JsonProperty("position")]
	public int Position { get; init; }
}
