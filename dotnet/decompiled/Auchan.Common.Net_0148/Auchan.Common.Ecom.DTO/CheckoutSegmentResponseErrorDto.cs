using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutSegmentResponseErrorDto
{
	[JsonProperty("code")]
	public string Code { get; set; }
}
