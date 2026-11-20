using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class TimeWorkDto
{
	[JsonProperty("workdays", Required = Required.Always)]
	public WorkHoursDto Workdays { get; set; }

	[JsonProperty("weekends", Required = Required.Always)]
	public WorkHoursDto Weekends { get; set; }
}
