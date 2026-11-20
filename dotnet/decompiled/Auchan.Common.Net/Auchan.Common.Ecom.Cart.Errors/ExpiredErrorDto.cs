using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Cart.Errors;

public class ExpiredErrorDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("message")]
	public string? Message { get; set; }
}
