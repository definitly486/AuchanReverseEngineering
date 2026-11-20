using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;

public class LoyaltyCardReattachPlasticCardNavigationParameter
{
	public LoyaltyCardReattachType ReattachType { get; set; }

	public VisualState State { get; set; } = VisualState.Default;

	public string CustomMessage { get; set; } = "";
}
