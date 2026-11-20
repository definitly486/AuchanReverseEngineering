using Newtonsoft.Json;

namespace Auchan.Common.Addresses.DTO;

public class SuggestionDto
{
	[JsonProperty("value")]
	public string AddressLine { get; set; }

	[JsonProperty("unrestricted_value")]
	public string AddressFullLine { get; set; }

	[JsonProperty("data")]
	public AddressDto Address { get; set; }
}
