using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class RequestRedirectDto
{
	[JsonProperty("redirectFrom")]
	public string RedirectFrom { get; set; } = string.Empty;

	[JsonProperty("redirectTo")]
	public string RedirectTo { get; set; } = string.Empty;
}
