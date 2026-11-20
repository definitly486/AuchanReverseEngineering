using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class WorkHoursDto
{
	[JsonProperty("open")]
	public string? Open { get; set; }

	[JsonProperty("close")]
	public string? Close { get; set; }

	[JsonProperty("is_around_the_clock")]
	public bool IsAroundTheClock { get; set; }
}
