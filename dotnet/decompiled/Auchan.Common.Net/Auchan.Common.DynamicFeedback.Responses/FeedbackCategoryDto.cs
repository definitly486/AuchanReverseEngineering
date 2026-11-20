using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackCategoryDto
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("case_category_name")]
	public string? CaseCategoryName { get; set; }

	[JsonProperty("category_feedback_form")]
	public long CategoryFeedbackForm { get; set; }

	[JsonProperty("topics")]
	public List<FeedbackTopicDto>? Topics { get; set; }
}
