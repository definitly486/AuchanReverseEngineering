using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

internal sealed record VkTokenRequestDto
{
	[JsonProperty("code")]
	public required string Code { get; init; }

	[JsonProperty("code_verifier")]
	public required string CodeVerifier { get; init; }

	[JsonProperty("device_id")]
	public required string DeviceId { get; init; }

	[JsonProperty("state")]
	public required string State { get; init; }

	[JsonProperty("session_id")]
	public required string SessionId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private VkTokenRequestDto(VkTokenRequestDto original)
	{
		Code = original.Code;
		CodeVerifier = original.CodeVerifier;
		DeviceId = original.DeviceId;
		State = original.State;
		SessionId = original.SessionId;
	}

	public VkTokenRequestDto()
	{
	}
}
