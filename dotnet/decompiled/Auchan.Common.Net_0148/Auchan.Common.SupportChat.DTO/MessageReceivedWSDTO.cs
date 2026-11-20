using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed record MessageReceivedWSDTO : BaseWSMessageDTO
{
	[JsonProperty("code")]
	public required int Code { get; init; }

	[JsonProperty("data")]
	public required object Data { get; init; }

	[JsonProperty("meta")]
	public required MessageReceivedMetaWSDTO Meta { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private MessageReceivedWSDTO(MessageReceivedWSDTO original)
		: base(original)
	{
		Code = original.Code;
		Data = original.Data;
		Meta = original.Meta;
	}

	public MessageReceivedWSDTO()
	{
	}
}
