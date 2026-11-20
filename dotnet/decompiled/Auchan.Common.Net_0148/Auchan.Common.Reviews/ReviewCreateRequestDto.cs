using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Reviews;

public class ReviewCreateRequestDto
{
	[JsonProperty("gima_id")]
	public int? GimaId { get; set; }

	[JsonProperty("channel")]
	[JsonConverter(typeof(StringEnumConverter))]
	public Channel? Channel { get; set; }

	[JsonProperty("rate")]
	public int? Rate { get; set; }

	[JsonProperty("review")]
	public string? Review { get; set; }

	[JsonProperty("images")]
	public IEnumerable<int>? Images { get; set; }

	[JsonProperty("agreement_time")]
	public string? AgreementTime { get; set; }

	[JsonProperty("trigger_word_ids")]
	public IEnumerable<int>? TriggerWordIds { get; set; }

	[JsonProperty("manufacturer")]
	public string? Manufacturer { get; set; }

	[JsonProperty("product_production_date")]
	public string? ProductProductionDate { get; set; }
}
