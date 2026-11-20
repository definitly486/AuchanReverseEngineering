using System;
using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class Discount
{
	[JsonProperty("id")]
	public long? Id { get; set; }

	[JsonProperty("change")]
	public long? Change { get; set; }

	[JsonProperty("size")]
	public long? Size { get; set; }

	[JsonProperty("value")]
	public long? Value { get; set; }

	[JsonProperty("value_type")]
	public long? ValueType { get; set; }

	[JsonProperty("date_start")]
	public DateTimeOffset? DateStart { get; set; }

	[JsonProperty("date_end")]
	public DateTimeOffset? DateEnd { get; set; }
}
