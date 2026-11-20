using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class AttributeDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("value")]
	public string? Value { get; set; }
}
