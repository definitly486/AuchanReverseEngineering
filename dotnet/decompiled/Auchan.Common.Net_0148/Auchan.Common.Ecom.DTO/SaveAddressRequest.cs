using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class SaveAddressRequest
{
	[JsonProperty("address_string", NullValueHandling = NullValueHandling.Ignore)]
	public string? AddressString { get; init; }

	[JsonProperty("address_id", NullValueHandling = NullValueHandling.Ignore)]
	public long? AddressId { get; init; }

	[JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
	public string? Uri { get; init; }

	[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
	public string? Name { get; init; }

	[JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
	public string? Comment { get; init; }
}
