using Auchan.Common.SupportChat.DTO;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.SupportChat;

public static class WSMessageJsonConverter
{
	public static BaseWSMessageDTO Deserialize(string json)
	{
		JToken jToken = JToken.Parse(json);
		BaseWSMessageDTO baseWSMessageDTO = jToken.ToObject<BaseWSMessageDTO>();
		BaseWSMessageDTO baseWSMessageDTO2 = new ErrorWSMessageDTO
		{
			Event = WSMessageEventType.Unknown,
			Error = "Could not deserialize message",
			JsonMessage = jToken.ToString()
		};
		if (baseWSMessageDTO == null)
		{
			return baseWSMessageDTO2;
		}
		switch (baseWSMessageDTO.Event)
		{
		case WSMessageEventType.MessageReceived:
			return jToken.ToObject<MessageReceivedWSDTO>() ?? baseWSMessageDTO2;
		case WSMessageEventType.NewMessage:
		{
			BaseWSMessageDTO baseWSMessageDTO3 = jToken.ToObject<NewMessageWSDTO>() ?? baseWSMessageDTO2;
			if (baseWSMessageDTO3 is NewMessageWSDTO newMessageWSDTO)
			{
				return newMessageWSDTO.ToNewMessageFromQueueWSDTO();
			}
			return baseWSMessageDTO3;
		}
		case WSMessageEventType.NewMessageFromQueue:
			return jToken.ToObject<NewMessageFromQueueWSDTO>() ?? baseWSMessageDTO2;
		default:
			return baseWSMessageDTO;
		}
	}
}
