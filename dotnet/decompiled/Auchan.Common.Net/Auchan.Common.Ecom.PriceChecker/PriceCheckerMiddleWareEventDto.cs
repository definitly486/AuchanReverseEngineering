using Newtonsoft.Json;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceCheckerMiddleWareEventDto
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("value")]
	public ValueDto ValueDto { get; set; }
}
