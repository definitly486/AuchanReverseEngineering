using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;

public class LoyaltyPointsSentToNumberViewModel : BaseLoyaltyPointsSentSuccessViewModel
{
	private readonly LoyaltyPointsSentToNumberNavigationParameter _navigationParameter;

	public LoyaltyPointType PointType => _navigationParameter.PointType;

	public string PhoneNumber => _navigationParameter.PhoneNumber;

	public string OperationTitle => $"Вы перевели {_navigationParameter.Amount} {_navigationParameter.Amount.GetLoyaltyPointsDeclinedAccusative(_navigationParameter.PointType)} получателю с номером телефона {PhoneNumber}";

	public string CurrentBalanceLabel => "Баланс будет обновлен в течении 5 минут";

	protected override string ScreenName => "loyality_transfer_success_screen";

	public LoyaltyPointsSentToNumberViewModel(LoyaltyPointsSentToNumberNavigationParameter navigationParameter, ILoyaltyManager loyaltyManager)
		: base(loyaltyManager)
	{
		_navigationParameter = navigationParameter;
	}
}
