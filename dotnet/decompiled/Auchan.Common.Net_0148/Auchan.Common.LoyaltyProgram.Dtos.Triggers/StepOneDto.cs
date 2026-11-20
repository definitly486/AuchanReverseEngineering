using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos.Triggers;

public class StepOneDto
{
	[JsonProperty("enabled")]
	public bool IsEnabled { get; set; }

	[JsonProperty("show_count")]
	public int TimesToShowCount { get; set; }

	[JsonProperty("loyalty_popup_texts")]
	public List<string>? LoyaltyPopupTexts { get; set; }

	[JsonProperty("auchan_pay_popup_texts")]
	public List<string>? AuchanPayPopupTexts { get; set; }
}
