using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class SubscriptionsListDto
{
	[JsonProperty("subscribes")]
	public List<SubscriptionTypeDto> SubscriptionTypes { get; set; }

	[JsonProperty("communication_types")]
	public List<SubscriptionCommunicationDto> SubscriptionCommunicationTypes { get; set; }
}
