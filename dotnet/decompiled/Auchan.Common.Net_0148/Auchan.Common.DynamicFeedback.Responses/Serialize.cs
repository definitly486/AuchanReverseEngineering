using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public static class Serialize
{
	public static string? ToJson(this FeedbackCitiesResponse self)
	{
		return JsonConvert.SerializeObject(self, CitiesConverter.Settings);
	}
}
