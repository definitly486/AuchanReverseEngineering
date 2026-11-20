using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class DescriptionDto
{
	[JsonProperty("content")]
	public string? Content { get; init; }
}
