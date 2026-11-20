using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed class PossibleOrderCancellationReasonsDto
{
	[JsonProperty("possible_reasons_for_cancellation")]
	public List<CancellationReasonDto> Reasons { get; set; }
}
