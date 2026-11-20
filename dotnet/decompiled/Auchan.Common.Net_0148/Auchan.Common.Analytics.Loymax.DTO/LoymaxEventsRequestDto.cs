using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Loymax.DTO;

public sealed class LoymaxEventsRequestDto
{
	public sealed class EventDto
	{
		[JsonProperty("type")]
		public required string Type { get; init; }

		[JsonProperty("message_id")]
		public required string MessageId { get; init; }
	}

	[JsonProperty("events")]
	public required IReadOnlyList<EventDto> Events { get; init; }
}
