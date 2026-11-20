using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public class BasePromotionMessageDTO
{
	[JsonProperty]
	public string Id { get; set; }

	[JsonProperty]
	[JsonConverter(typeof(EnumMemberJsonConverter<PromotionMessageType>))]
	public PromotionMessageType Type { get; set; }

	public BasePromotionMessageDTO(string id, PromotionMessageType type)
	{
		Id = id;
		Type = type;
	}
}
