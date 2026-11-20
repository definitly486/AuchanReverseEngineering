using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductResultFilterMultiItemDTO
{
	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty("code")]
	public string Code { get; set; } = string.Empty;

	[JsonProperty("disabled")]
	public bool? Disabled { get; set; }

	[JsonProperty("forActive")]
	public bool IsForActive { get; set; }

	[JsonProperty("counter")]
	public int Counter { get; set; }
}
