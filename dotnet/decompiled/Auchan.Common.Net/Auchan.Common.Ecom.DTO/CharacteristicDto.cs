using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CharacteristicDto
{
	[JsonProperty("id")]
	public int Id { get; init; }

	[JsonProperty("title")]
	public string? Title { get; init; }

	[JsonProperty("value")]
	public string? Value { get; init; }
}
