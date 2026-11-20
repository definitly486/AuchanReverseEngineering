using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record UpdateAddressDto
{
	[JsonProperty("id")]
	public long Id { get; init; }

	[JsonProperty("flat")]
	public string Flat { get; init; } = "";

	[JsonProperty("floor")]
	public string Floor { get; init; } = "";

	[JsonProperty("porch")]
	public string Porch { get; init; } = "";

	[JsonProperty("intercom")]
	public string Intercom { get; init; } = "";
}
