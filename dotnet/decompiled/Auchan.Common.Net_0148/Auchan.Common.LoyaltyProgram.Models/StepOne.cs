using System.Collections.Generic;

namespace Auchan.Common.LoyaltyProgram.Models;

public class StepOne
{
	public bool IsEnabled { get; set; }

	public int TimesToShowCount { get; set; }

	public List<string>? LoyaltyPopupTexts { get; set; }

	public List<string>? AuchanPayPopupTexts { get; set; }
}
