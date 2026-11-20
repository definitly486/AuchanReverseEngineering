using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackRespondResponse
{
	[JsonProperty("case_number")]
	public string? CaseNumber { get; set; }

	[JsonProperty("description")]
	public string? Description { get; set; }

	[JsonProperty("informer_text")]
	public string? InformerText { get; set; }
}
