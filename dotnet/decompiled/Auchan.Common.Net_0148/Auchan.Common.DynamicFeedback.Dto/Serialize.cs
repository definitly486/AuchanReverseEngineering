using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public static class Serialize
{
	public static string ToJson(this FeedbackRespondDto self)
	{
		return JsonConvert.SerializeObject(self, RespondDtoConverter.Settings);
	}
}
