using System;
using System.Reactive;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.Navigation;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;

public class LoyaltyCardReattachedViewModel : ScreenViewModel
{
	private readonly LoyaltyCardReattachPlasticCardNavigationParameter _reattachNavigationParameter;

	private readonly Subject<Unit> _continueSubject = new Subject<Unit>();

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	public VisualState State => _reattachNavigationParameter.State;

	public LoyaltyCardReattachType ReattachType => _reattachNavigationParameter.ReattachType;

	public bool HasSubtitle
	{
		get
		{
			if (_reattachNavigationParameter.ReattachType != LoyaltyCardReattachType.ReattachPlastic)
			{
				return _reattachNavigationParameter.ReattachType == LoyaltyCardReattachType.ReattachVirtual;
			}
			return true;
		}
	}

	public string Title => ReattachType switch
	{
		LoyaltyCardReattachType.AfterBlock => "Мы перевыпустили вашу карту АШАН и сохранили ваши баллы!", 
		LoyaltyCardReattachType.ReattachPlastic => "Отлично, ваша новая карта готова!", 
		LoyaltyCardReattachType.ReattachVirtual => "Ура! Пластиковая карта активирована!", 
		LoyaltyCardReattachType.BlockAndReatach => "Мы перевыпустили вашу карту АШАН и сохранили ваши баллы!", 
		LoyaltyCardReattachType.None => "Мы перевыпустили вашу карту АШАН и сохранили ваши баллы!", 
		_ => "Мы перевыпустили вашу карту АШАН и сохранили ваши баллы!", 
	};

	public string Subtitle => ReattachType switch
	{
		LoyaltyCardReattachType.ReattachPlastic => "Все ваши баллы успешно перенесены", 
		LoyaltyCardReattachType.ReattachVirtual => "Показывайте на кассе QR-код на карте или в приложении. Вдвойне удобно!", 
		_ => string.Empty, 
	};

	public string ContinueButtonText => "Продолжить";

	public string ErrorTitle => "Заблокировать карту";

	public string ErrorSubTitle => _reattachNavigationParameter.CustomMessage;

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	public IObservable<Unit> ContinueCommand => _continueSubject.Debounce();

	public LoyaltyCardReattachedViewModel(LoyaltyCardReattachPlasticCardNavigationParameter reattachNavigationParameter, ILoyaltyManager loyaltyManager, UrlNavigationHandler urlNavigationHandler)
	{
		_reattachNavigationParameter = reattachNavigationParameter;
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
	}

	public void OnContinueSelected()
	{
		_continueSubject.OnNext(Unit.Default);
	}

	public void HandleUrl(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}
}
