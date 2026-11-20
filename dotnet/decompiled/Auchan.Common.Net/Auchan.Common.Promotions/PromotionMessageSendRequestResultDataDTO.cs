using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public class PromotionMessageSendRequestResultDataDTO
{
	[JsonProperty]
	public string StatusCode { get; set; }

	[JsonProperty]
	public string Content { get; set; }

	public PromotionMessageSendRequestResultDataDTO(string statusCode, string content)
	{
		StatusCode = statusCode;
		Content = content;
	}
}
