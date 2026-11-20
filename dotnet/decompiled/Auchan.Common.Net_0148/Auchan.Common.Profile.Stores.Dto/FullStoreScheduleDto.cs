using Newtonsoft.Json;

namespace Auchan.Common.Profile.Stores.Dto;

public class FullStoreScheduleDto
{
	[JsonProperty("weekdays")]
	public string Weekdays { get; set; }

	[JsonProperty("open_time")]
	public string OpenTime { get; set; }

	[JsonProperty("close_time")]
	public string CloseTime { get; set; }

	[JsonProperty("is_around_the_clock")]
	public bool IsAroundTheClock { get; set; }
}
