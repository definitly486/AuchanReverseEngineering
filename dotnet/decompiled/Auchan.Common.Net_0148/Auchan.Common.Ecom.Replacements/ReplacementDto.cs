using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Replacements;

public class ReplacementDto
{
	[JsonProperty("replacement_method_id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("replacement_method", Required = Required.Always)]
	public string Name { get; set; }

	[JsonProperty("default_value", Required = Required.Always)]
	public bool IsDefault { get; set; }
}
