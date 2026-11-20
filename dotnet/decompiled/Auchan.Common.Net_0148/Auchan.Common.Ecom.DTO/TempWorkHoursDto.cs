using System;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class TempWorkHoursDto
{
	[JsonProperty("date")]
	public DateTime? Date { get; set; }

	[JsonProperty("is_closed")]
	public bool IsClosed { get; set; }

	[JsonProperty("open")]
	public string? Open { get; set; }

	[JsonProperty("close")]
	public string? Close { get; set; }

	[JsonProperty("is_around_the_clock")]
	public bool IsAroundTheClock { get; set; }
}
