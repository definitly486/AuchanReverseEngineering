using Auchan.Common.Ecom.AddressStoreSelection;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.DTO;

public class ReceiveMethodsResponseReceiveMethodDTO
{
	[JsonProperty("method_id")]
	public ReceivingMethod ReceiveMethod { get; set; }

	[JsonProperty("applied")]
	public bool IsSelectedMethod { get; set; }

	[JsonProperty("is_available")]
	public bool IsAvailable { get; set; } = true;

	[JsonProperty("delivery_info")]
	public ReceiveMethodsResponseDeliveryInfoDTO DeliveryInfo { get; set; }
}
