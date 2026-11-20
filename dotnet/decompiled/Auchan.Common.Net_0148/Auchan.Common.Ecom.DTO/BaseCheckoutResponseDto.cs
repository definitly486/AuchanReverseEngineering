using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class BaseCheckoutResponseDto
{
	[JsonProperty("errorCode")]
	public string Error { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }
}
