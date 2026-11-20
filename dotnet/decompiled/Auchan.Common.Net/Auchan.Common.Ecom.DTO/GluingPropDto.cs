using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class GluingPropDto
{
	[JsonProperty("name")]
	public string Name { get; init; } = "";

	[JsonProperty("code")]
	public string Code { get; init; } = "";

	[JsonProperty("value")]
	public string Value { get; init; } = "";

	[JsonProperty("sort")]
	public int SortOrder { get; init; }
}
