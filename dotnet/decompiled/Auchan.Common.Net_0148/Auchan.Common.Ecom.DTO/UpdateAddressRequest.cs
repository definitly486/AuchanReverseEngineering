using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class UpdateAddressRequest
{
	[JsonProperty("address")]
	public required UpdateAddressDto Address { get; init; }

	[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
	public string? Name { get; init; }

	[JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
	public string? Comment { get; init; }
}
