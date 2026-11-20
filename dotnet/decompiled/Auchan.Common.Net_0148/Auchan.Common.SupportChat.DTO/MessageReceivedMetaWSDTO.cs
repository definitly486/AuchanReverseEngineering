using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed record MessageReceivedMetaWSDTO
{
	[JsonProperty("messageId")]
	public required Guid MessageId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private MessageReceivedMetaWSDTO(MessageReceivedMetaWSDTO original)
	{
		MessageId = original.MessageId;
	}

	public MessageReceivedMetaWSDTO()
	{
	}
}
