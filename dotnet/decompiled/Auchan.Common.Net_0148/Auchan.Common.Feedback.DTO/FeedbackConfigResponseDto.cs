using Newtonsoft.Json;

namespace Auchan.Common.Feedback.DTO;

public sealed class FeedbackConfigResponseDto
{
	[JsonProperty("categories")]
	public FeedbackCategory[] Categories { get; set; }

	[JsonProperty("cities")]
	public FeedbackCity[] Cities { get; set; }

	public FeedbackConfigResponseDto(FeedbackCategory[] categories, FeedbackCity[] cities)
	{
		Categories = categories;
		Cities = cities;
	}
}
