using System;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public abstract class TrackingRequest
{
	[JsonProperty("link", Required = Required.Always)]
	public required Link Link { get; init; }

	[JsonProperty("timestamp", Required = Required.Always)]
	[JsonConverter(typeof(Iso8601DateTimeConverter))]
	public required DateTime Timestamp { get; init; }
}
