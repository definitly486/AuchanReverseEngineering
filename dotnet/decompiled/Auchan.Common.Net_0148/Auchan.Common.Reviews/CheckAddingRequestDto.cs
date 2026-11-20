using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Reviews;

public class CheckAddingRequestDto
{
	[JsonProperty("gima_id")]
	public int? GimaId { get; set; }

	[JsonProperty("channel")]
	[JsonConverter(typeof(StringEnumConverter))]
	public Channel? Channel { get; set; }
}
