using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CarsResponse
{
	[JsonProperty("data")]
	public List<CarDto> Cars { get; set; }
}
