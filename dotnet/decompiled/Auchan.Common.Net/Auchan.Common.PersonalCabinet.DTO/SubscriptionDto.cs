using System;
using Auchan.Common.Recommendations.API;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class SubscriptionDto
{
	[JsonProperty("id")]
	public int? Id { get; set; }

	[JsonProperty("commType")]
	public SubscriptionCommunicationDto CommunicationType { get; set; }

	[JsonProperty("subscribeType")]
	public SubscriptionTypeDto Type { get; set; }

	[JsonProperty("dateStart")]
	[JsonConverter(typeof(Iso8601DateTimeConverterType2))]
	public DateTime StartDate { get; set; }

	[JsonProperty("dateEnd")]
	[JsonConverter(typeof(Iso8601DateTimeConverterType2))]
	public DateTime? EndDate { get; set; }
}
