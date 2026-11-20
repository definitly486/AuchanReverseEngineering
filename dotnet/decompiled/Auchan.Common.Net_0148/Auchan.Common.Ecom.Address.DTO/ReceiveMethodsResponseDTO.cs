using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.DTO;

public class ReceiveMethodsResponseDTO
{
	[JsonProperty("data")]
	public ReceiveMethodsResponseDataDTO Data { get; set; }
}
