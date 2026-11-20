using Newtonsoft.Json;

namespace Auchan.Common.Reviews;

public class UploadImagesResponseDto
{
	[JsonProperty("data")]
	public DataDto? Data { get; set; }
}
