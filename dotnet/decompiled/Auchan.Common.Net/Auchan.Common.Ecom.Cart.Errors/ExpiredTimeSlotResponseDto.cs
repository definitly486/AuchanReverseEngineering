using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Cart.Errors;

public class ExpiredTimeSlotResponseDto
{
	[JsonProperty("errors")]
	public List<ExpiredErrorDto> Errors { get; set; }
}
