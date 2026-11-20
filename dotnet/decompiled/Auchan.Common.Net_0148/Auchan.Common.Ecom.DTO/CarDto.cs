using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CarDto
{
	[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
	public int? Id { get; set; }

	[JsonProperty("car_number")]
	public string CarNumber { get; set; } = string.Empty;

	[JsonProperty("car_mark")]
	public string CarMark { get; set; } = string.Empty;

	[JsonProperty("car_color")]
	public string CarColor { get; set; } = string.Empty;

	[JsonProperty("default")]
	public bool Default { get; set; }
}
