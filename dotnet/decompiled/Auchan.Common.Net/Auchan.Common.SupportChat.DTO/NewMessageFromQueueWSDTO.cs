using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed record NewMessageFromQueueWSDTO : BaseWSMessageDTO
{
	[JsonProperty("data")]
	[JsonConverter(typeof(WSDataDTOJsonConverter))]
	public required WSDataDTO Data { get; init; }

	[JsonProperty("Meta")]
	public required MessageReceivedMetaWSDTO Meta { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private NewMessageFromQueueWSDTO(NewMessageFromQueueWSDTO original)
		: base(original)
	{
		Data = original.Data;
		Meta = original.Meta;
	}

	public NewMessageFromQueueWSDTO()
	{
	}
}
