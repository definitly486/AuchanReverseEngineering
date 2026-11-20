using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public class PromotionMessageSendRequestResultDTO : BasePromotionMessageDTO
{
	[JsonProperty("data")]
	public PromotionMessageSendRequestResultDataDTO Data { get; set; }

	public PromotionMessageSendRequestResultDTO(string id, PromotionMessageType type, PromotionMessageSendRequestResultDataDTO data)
		: base(id, type)
	{
		Data = data;
	}
}
