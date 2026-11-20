using Newtonsoft.Json;

namespace Auchan.Common.Reviews;

public class CheckAddingResponseDto
{
	[JsonProperty("data")]
	public CheckAddingDataDto? Data { get; set; }
}
