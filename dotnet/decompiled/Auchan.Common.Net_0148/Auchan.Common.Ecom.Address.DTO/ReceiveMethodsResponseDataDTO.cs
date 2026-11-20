using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Address.DTO;

public class ReceiveMethodsResponseDataDTO
{
	[JsonProperty("purchase_method")]
	public bool IsReceiveMethodSet { get; set; }

	[JsonProperty("shop")]
	public ReceiveMethodsResponseShopDTO Store { get; set; }

	[JsonProperty("receiveMethods")]
	public List<ReceiveMethodsResponseReceiveMethodDTO> ReceiveMethods { get; set; }

	[JsonProperty("confines")]
	public ReceiveMethodsResponseConfinesDTO Confines { get; set; }
}
