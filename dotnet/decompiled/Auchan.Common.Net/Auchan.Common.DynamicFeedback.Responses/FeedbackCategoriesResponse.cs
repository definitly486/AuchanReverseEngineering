using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackCategoriesResponse
{
	[JsonProperty("service_welcome_text")]
	public string? ServiceWelcomeText { get; set; }

	[JsonProperty("categories")]
	public List<FeedbackCategoryDto>? Categories { get; set; }

	public static FeedbackCategoriesResponse FromJson(string json)
	{
		return JsonConvert.DeserializeObject<FeedbackCategoriesResponse>(json, CategoriesConverter.Settings);
	}
}
