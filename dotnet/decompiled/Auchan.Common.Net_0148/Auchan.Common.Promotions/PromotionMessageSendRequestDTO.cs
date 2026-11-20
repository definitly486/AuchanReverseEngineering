using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public class PromotionMessageSendRequestDTO : BasePromotionMessageDTO
{
	[JsonProperty("data")]
	public PromotionMessageSendRequestDataDTO Data { get; set; }

	public PromotionMessageSendRequestDTO(string id, PromotionMessageType type, PromotionMessageSendRequestDataDTO data)
		: base(id, type)
	{
		Data = data;
	}
}
