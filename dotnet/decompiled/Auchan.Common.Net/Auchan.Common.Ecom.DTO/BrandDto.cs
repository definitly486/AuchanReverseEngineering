using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class BrandDto
{
	[JsonProperty("name")]
	public string? Name { get; init; }

	[JsonProperty("code")]
	public string? Code { get; init; }
}
