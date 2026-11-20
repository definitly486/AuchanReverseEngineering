using System;
using System.Reactive;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;

public class LoyaltyPointsReceivedViewModel : ScreenViewModel
{
	private readonly LoyaltyPointsReceivedNavigationParameter _navigationParameter;

	private readonly Subject<Unit> _continueCommandSubject = new Subject<Unit>();

	public string OperationTitle => $"Вы получили {_navigationParameter.Amount} {_navigationParameter.Amount.GetLoyaltyPointsDeclined(_navigationParameter.PointType)}\nот отправителя +{_navigationParameter.Sender.GetPhoneNumberFormatted(withDashes: false, obscured: true)}";

	public string CurrentBalanceLabel => $"У вас осталось {_navigationParameter.AvailableAmount} {_navigationParameter.AvailableAmount.GetLoyaltyPointsDeclined(_navigationParameter.PointType)} на счете. {((_navigationParameter.PointType == LoyaltyPointType.Points) ? "Баллы" : "Марки")} можно не только переводить, но и тратить";

	public string ContinueButtonText => "Продолжить";

	public IObservable<Unit> ContinueCommand => _continueCommandSubject.Debounce();

	public LoyaltyPointsReceivedViewModel(LoyaltyPointsReceivedNavigationParameter navigationParameter)
	{
		_navigationParameter = navigationParameter;
	}

	public void OnContinueButtonSelected()
	{
		_continueCommandSubject.OnNext(Unit.Default);
	}
}
