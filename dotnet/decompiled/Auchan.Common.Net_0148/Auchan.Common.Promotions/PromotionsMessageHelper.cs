using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public static class PromotionsMessageHelper
{
	public static string GetResponseMessage(string id, string statusCode, string content)
	{
		return JsonConvert.SerializeObject(new PromotionMessageSendRequestResultDTO(id, PromotionMessageType.SendRequestResult, new PromotionMessageSendRequestResultDataDTO(statusCode, content)));
	}

	public static PromotionMessageSendRequestDTO? GetSendRequestDTO(string message)
	{
		try
		{
			return JsonConvert.DeserializeObject<PromotionMessageSendRequestDTO>(message);
		}
		catch (JsonException)
		{
		}
		return null;
	}
}
