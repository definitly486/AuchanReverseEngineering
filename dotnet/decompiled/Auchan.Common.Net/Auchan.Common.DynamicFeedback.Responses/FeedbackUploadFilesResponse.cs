using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class FeedbackUploadFilesResponse
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("name")]
	public string? Name { get; set; }

	[JsonProperty("url")]
	public string? Url { get; set; }

	[JsonProperty("size")]
	public long Size { get; set; }

	[JsonProperty("extension")]
	public string? Extension { get; set; }

	public static FeedbackUploadFilesResponse? FromJson(string json)
	{
		return JsonConvert.DeserializeObject<FeedbackUploadFilesResponse>(json, UploadFulesConverter.Settings);
	}
}
