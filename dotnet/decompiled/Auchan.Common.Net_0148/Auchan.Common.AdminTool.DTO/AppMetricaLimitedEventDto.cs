using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class AppMetricaLimitedEventDto
{
	[JsonProperty("event")]
	public string Event { get; set; }

	[JsonProperty("limit")]
	public int Limit { get; set; }
}
