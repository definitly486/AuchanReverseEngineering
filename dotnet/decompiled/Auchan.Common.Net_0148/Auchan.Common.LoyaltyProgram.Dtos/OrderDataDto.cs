using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class OrderDataDto
{
	[JsonProperty("number")]
	public string? Number { get; set; }
}
