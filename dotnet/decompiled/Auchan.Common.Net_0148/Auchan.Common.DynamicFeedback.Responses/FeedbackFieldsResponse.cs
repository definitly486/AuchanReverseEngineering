using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackFieldsResponse
{
	[JsonProperty("fields")]
	public List<FeedbackFieldDto>? Fields { get; set; }

	[JsonProperty("service_quality_hint")]
	public string? ServiceQualityHint { get; set; }

	public static FeedbackFieldsResponse? FromJson(string json)
	{
		return JsonConvert.DeserializeObject<FeedbackFieldsResponse>(json, FieldsConverter.Settings);
	}
}
