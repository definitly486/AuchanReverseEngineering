using System;
using System.Reactive;
using System.Reactive.Subjects;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;

public class BaseLoyaltyPointsSentSuccessViewModel : ScreenViewModel
{
	private readonly ILoyaltyManager _loyaltyManager;

	private readonly Subject<Unit> _closeCommandSubject = new Subject<Unit>();

	public string TitleLabel => "Перевод выполнен успешно";

	public virtual string ContinueButtonText => "Продолжить";

	public IObservable<Unit> CloseCommand => _closeCommandSubject.Debounce();

	public BaseLoyaltyPointsSentSuccessViewModel(ILoyaltyManager loyaltyManager)
	{
		_loyaltyManager = loyaltyManager;
	}

	public void OnCloseButtonSelected()
	{
		_loyaltyManager.GetBalanceAsync().SafeFireAndForget((Action<Exception>)null, false);
		_closeCommandSubject.OnNext(Unit.Default);
	}
}
