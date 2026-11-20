using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackCitiesResponse
{
	[JsonProperty("cities")]
	public List<City>? Cities { get; set; }

	public static FeedbackCitiesResponse? FromJson(string json)
	{
		return JsonConvert.DeserializeObject<FeedbackCitiesResponse>(json, CitiesConverter.Settings);
	}
}
