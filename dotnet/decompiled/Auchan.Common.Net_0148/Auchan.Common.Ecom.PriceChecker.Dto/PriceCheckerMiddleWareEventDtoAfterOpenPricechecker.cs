using Newtonsoft.Json;

namespace Auchan.Common.Ecom.PriceChecker.Dto;

public class PriceCheckerMiddleWareEventDtoAfterOpenPricechecker
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("value")]
	public ValueAfterOpenPricecheckerDto ValueDto { get; set; }
}
