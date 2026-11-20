using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Loymax.DTO;

public sealed class LoymaxPushesRequestDto
{
	[JsonProperty("push_id")]
	public required string PushId { get; init; }

	[JsonProperty("type")]
	public required string Type { get; init; }

	[JsonProperty("device")]
	public required string Device { get; init; }

	[JsonProperty("is_deleted")]
	public required bool IsDeleted { get; init; }
}
