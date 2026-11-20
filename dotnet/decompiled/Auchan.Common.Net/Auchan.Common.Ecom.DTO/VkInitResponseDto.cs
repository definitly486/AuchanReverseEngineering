using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record VkInitResponseDto
{
	[JsonProperty("state", Required = Required.Always)]
	public required string State { get; init; }

	[JsonProperty("session_id", Required = Required.Always)]
	public required string SessionId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private VkInitResponseDto(VkInitResponseDto original)
	{
		State = original.State;
		SessionId = original.SessionId;
	}

	public VkInitResponseDto()
	{
	}
}
