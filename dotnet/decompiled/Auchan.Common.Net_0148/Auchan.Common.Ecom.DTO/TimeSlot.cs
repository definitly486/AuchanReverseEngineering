using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class TimeSlot
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("from")]
	public string From { get; set; }

	[JsonProperty("to")]
	public string To { get; set; }
}
