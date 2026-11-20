using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class SubscriptionCommunicationDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("communication")]
	public string Title { get; set; }
}
