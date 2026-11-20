using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class Sum
{
	[JsonProperty("value")]
	public decimal Value { get; init; }

	[JsonProperty("currency")]
	public string? Currency { get; init; }
}
