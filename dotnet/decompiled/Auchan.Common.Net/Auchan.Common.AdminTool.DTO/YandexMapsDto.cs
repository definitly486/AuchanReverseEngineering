using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class YandexMapsDto
{
	[JsonProperty("apiKey")]
	public string ApiKey { get; set; }
}
