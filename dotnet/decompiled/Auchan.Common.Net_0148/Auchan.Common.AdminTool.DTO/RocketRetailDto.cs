using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class RocketRetailDto
{
	[JsonProperty("apiKey")]
	public string ApiKey { get; set; }

	[JsonProperty("partnerId")]
	public string PartnerId { get; set; }
}
