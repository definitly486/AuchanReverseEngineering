using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.SupportChat.DTO;

public class MessageContentDTO
{
	[JsonProperty("type")]
	[JsonConverter(typeof(StringEnumConverter))]
	public MessageType Type { get; set; }

	[JsonProperty("text")]
	public string Text { get; set; }

	[JsonProperty("attachment")]
	public AttachmentDto? Attachment { get; set; }

	public MessageContentDTO(string text, MessageType type, AttachmentDto? attachment)
	{
		Text = text;
		Type = type;
		Attachment = attachment;
	}
}
