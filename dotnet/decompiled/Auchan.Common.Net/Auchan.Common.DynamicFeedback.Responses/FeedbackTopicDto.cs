using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackTopicDto
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("category_id")]
	public long CategoryId { get; set; }

	[JsonProperty("service_crm_id")]
	public Guid ServiceCrmId { get; set; }

	[JsonProperty("service_quality_hint")]
	public string? ServiceQualityHint { get; set; }

	[JsonProperty("case_topic_name")]
	public string? CaseTopicName { get; set; }

	[JsonProperty("topic_feedback_form")]
	public long TopicFeedbackForm { get; set; }

	[JsonProperty("fields")]
	public List<FeedbackFieldDto>? Fields { get; set; }
}
