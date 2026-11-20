using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed record NewMessageWSDTO : BaseWSMessageDTO
{
	[JsonProperty("data")]
	[JsonConverter(typeof(WSDataDTOJsonConverter))]
	public required WSDataDTO Data { get; init; }

	[JsonProperty("Meta")]
	public required MessageReceivedMetaWSDTO Meta { get; set; }

	public NewMessageFromQueueWSDTO ToNewMessageFromQueueWSDTO()
	{
		return new NewMessageFromQueueWSDTO
		{
			Event = base.Event,
			Data = Data,
			Meta = Meta
		};
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private NewMessageWSDTO(NewMessageWSDTO original)
		: base(original)
	{
		Data = original.Data;
		Meta = original.Meta;
	}

	public NewMessageWSDTO()
	{
	}
}
