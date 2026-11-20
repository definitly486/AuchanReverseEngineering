using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public class FeedbackChannelsResponse
{
	[JsonProperty("preferred_communication_methods")]
	public List<PreferredCommunicationMethod>? CommunicationMethods { get; set; }

	public static FeedbackChannelsResponse? FromJson(string json)
	{
		return JsonConvert.DeserializeObject<FeedbackChannelsResponse>(json, ChannelsConverter.Settings);
	}
}
