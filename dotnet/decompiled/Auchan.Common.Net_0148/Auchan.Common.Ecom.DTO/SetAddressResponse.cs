using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class SetAddressResponse
{
	[JsonProperty("data")]
	public SavedAddressDto? Address { get; init; }
}
