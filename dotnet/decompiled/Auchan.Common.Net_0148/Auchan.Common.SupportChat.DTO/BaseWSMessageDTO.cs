using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public record BaseWSMessageDTO
{
	[JsonProperty("event")]
	[JsonConverter(typeof(EnumMemberJsonConverter<WSMessageEventType>))]
	public required WSMessageEventType Event { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected BaseWSMessageDTO(BaseWSMessageDTO original)
	{
		Event = original.Event;
	}

	public BaseWSMessageDTO()
	{
	}
}
