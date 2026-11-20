using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record CategoryCodeDto
{
	[JsonProperty("id")]
	public long Id { get; init; }

	[JsonProperty("name")]
	public string? Name { get; init; }

	[JsonProperty("code")]
	public string? Code { get; init; }
}
