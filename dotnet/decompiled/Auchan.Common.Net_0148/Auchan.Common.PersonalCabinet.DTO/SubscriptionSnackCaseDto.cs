using System;
using Auchan.Common.Recommendations.API;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class SubscriptionSnackCaseDto
{
	[JsonProperty("id")]
	public int? Id { get; set; }

	[JsonProperty("comm_type")]
	public SubscriptionCommunicationDto CommunicationType { get; set; }

	[JsonProperty("subscribe_type")]
	public SubscriptionTypeDto Type { get; set; }

	[JsonProperty("date_start")]
	[JsonConverter(typeof(Iso8601DateTimeConverterType2))]
	public DateTime StartDate { get; set; }

	[JsonProperty("date_end")]
	[JsonConverter(typeof(Iso8601DateTimeConverterType2))]
	public DateTime? EndDate { get; set; }
}
