using Auchan.Common.Helpers;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;

public class LoyaltyPointsSentToCharityViewModel : BaseLoyaltyPointsSentSuccessViewModel
{
	private readonly LoyaltyPointsSentToCharityNavigationParameter _navigationParameter;

	public string OperationTitle => $"Вы перевели {_navigationParameter.Amount} {_navigationParameter.Amount.GetLoyaltyPointsDeclined(LoyaltyPointType.Points)} в благотворительный фонд АШАН!";

	public string Description => "Спасибо, что делаете добро!" + "\n\n" + CurrentBalanceLabel;

	private string ThanksForCharityLabel => "Спасибо, что делаете добро!";

	private string CurrentBalanceLabel => GetCurrentBalanceString();

	protected override string ScreenName => "loyality_transfer_success_screen";

	public LoyaltyPointsSentToCharityViewModel(LoyaltyPointsSentToCharityNavigationParameter navigationParameter, ILoyaltyManager loyaltyManager)
		: base(loyaltyManager)
	{
		_navigationParameter = navigationParameter;
	}

	private string GetCurrentBalanceString()
	{
		int availableAmount = _navigationParameter.AvailableAmount;
		return $"У вас {GrammarHelper.DeclineNoun(availableAmount, new string[3] { "остался", "осталось", "осталось" })} {availableAmount} {availableAmount.GetLoyaltyPointsDeclined(LoyaltyPointType.Points)} на счете, {GrammarHelper.DeclineNoun(availableAmount, new string[3] { "доступный", "доступных", "доступных" })} для перевода";
	}
}
