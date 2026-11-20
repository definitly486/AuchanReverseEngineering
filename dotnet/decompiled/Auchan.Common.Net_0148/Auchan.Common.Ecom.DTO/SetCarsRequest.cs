using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class SetCarsRequest
{
	[JsonProperty("data")]
	public List<CarDto> Cars { get; }

	public SetCarsRequest(List<CarDto> cars)
	{
		Cars = cars;
	}
}
