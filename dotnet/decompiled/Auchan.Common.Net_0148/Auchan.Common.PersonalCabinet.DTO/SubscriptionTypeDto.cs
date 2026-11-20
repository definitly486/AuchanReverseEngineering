using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class SubscriptionTypeDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("subscribe_name")]
	public string Title { get; set; }
}
