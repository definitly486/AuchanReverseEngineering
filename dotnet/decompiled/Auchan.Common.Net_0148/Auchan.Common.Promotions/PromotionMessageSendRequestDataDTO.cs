using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public class PromotionMessageSendRequestDataDTO
{
	[JsonProperty]
	public string Method { get; set; }

	[JsonProperty]
	public string Url { get; set; }

	[JsonProperty]
	public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

	[JsonProperty]
	public string Body { get; set; }

	public PromotionMessageSendRequestDataDTO(string method, string url, Dictionary<string, string> headers, string body)
	{
		Method = method;
		Url = url;
		Headers = headers;
		Body = body;
	}
}
