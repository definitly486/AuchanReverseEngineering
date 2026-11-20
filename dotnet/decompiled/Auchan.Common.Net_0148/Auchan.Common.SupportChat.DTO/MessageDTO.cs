using System;
using Auchan.Common.SupportChat.Models;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class MessageDTO
{
	[JsonProperty("messageId")]
	public Guid MessageId { get; set; }

	[JsonProperty("clientId")]
	public string ClientId { get; set; }

	[JsonProperty("sender")]
	public MessageSenderDTO Sender { get; set; }

	[JsonProperty("message")]
	public MessageContentDTO Message { get; set; }

	public MessageDTO(Guid id, string name, string message, string cmdId, MessageType type = MessageType.Text, UploadFileResult? upload = null)
	{
		MessageId = id;
		ClientId = cmdId;
		Sender = new MessageSenderDTO(cmdId, name);
		Message = new MessageContentDTO(message, type, upload?.ToAttachment());
	}
}
