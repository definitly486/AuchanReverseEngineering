using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Reviews;

public class CheckAddingDataDto
{
	[JsonProperty("result")]
	[JsonConverter(typeof(StringEnumConverter))]
	public CheckAddingStatus? Result { get; set; }
}
