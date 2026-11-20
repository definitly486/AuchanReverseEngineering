using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CheckoutSegmentPointsBaseResponseDto
{
	[JsonProperty("errors", Required = Required.Default)]
	public List<CheckoutSegmentResponseErrorDto>? Errors { get; set; }
}
