using System;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class CollectibleDto
{
	[JsonProperty("active")]
	public bool Active { get; set; }

	[JsonProperty("is_for_employees")]
	public bool? IsForEmployees { get; set; }

	[JsonProperty("is_for_segment")]
	public bool? IsForSegment { get; set; }

	[JsonProperty("user_segment_code")]
	public string UserSegmentCode { get; set; } = string.Empty;

	[JsonProperty("start_date")]
	public DateTime StartDate { get; set; }

	[JsonProperty("end_date")]
	public DateTime EndDate { get; set; }
}
