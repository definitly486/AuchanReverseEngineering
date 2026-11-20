using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class InformerDto
{
	[JsonProperty("type")]
	public string InformerType { get; set; } = string.Empty;

	[JsonProperty("value")]
	public string Value { get; set; } = string.Empty;

	[JsonProperty("additional_link")]
	public string AdditionalLink { get; set; } = string.Empty;
}
