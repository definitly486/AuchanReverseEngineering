using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.Component;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;

public class LoyaltyCardReattachPlasticCardViewModel : ScreenViewModel
{
	private readonly IUserContext _userContext;

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly IInfoMessageService _infoMessageService;

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	private ProfileModel? _profileModel;

	private readonly AttachCardInfoViewModelComponent _cardInfoComponent = new AttachCardInfoViewModelComponent();

	private readonly Subject<Unit> _signUpSubject = new Subject<Unit>();

	private readonly Subject<LoyaltyCardReattachPlasticCardNavigationParameter> _showSuccessfullyReattached = new Subject<LoyaltyCardReattachPlasticCardNavigationParameter>();

	private LoyaltyCardReattachPlasticCardNavigationParameter _reattachNavigationParameter;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorSubTitle_003Ek__BackingField;

	public string ScreenTitle => "Укажите данные карты";

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public string CloseButtonTitle => "Закрыть";

	public string ErrorTitle => "Добавить пластиковую карту";

	public string ErrorSubTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorSubTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorSubTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorSubTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorSubTitle");
			}
		}
	} = "Что-то пошло не так...";

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	public bool IsSubtitleVisible => _reattachNavigationParameter.ReattachType == LoyaltyCardReattachType.ReattachVirtual;

	public string Subtitle => "Добавьте пластиковую карту к\nвиртуальной — это удобно!";

	public string CardNumberTitle => _cardInfoComponent.CardNumberTitle;

	public string CardNumberText
	{
		get
		{
			return _cardInfoComponent.CardNumberText;
		}
		set
		{
			if (!string.Equals(CardNumberText, value, StringComparison.Ordinal))
			{
				_cardInfoComponent.CardNumberText = value;
				RaisePropertyChanged("CardNumberText");
			}
		}
	}

	public string CardNumberValidationHint => _cardInfoComponent.CardNumberValidationHint;

	public bool IsCardNumberValid => _cardInfoComponent.IsCardNumberValid;

	public string CardCvcTitle => _cardInfoComponent.CardCvcTitle;

	public string CardCvcText
	{
		get
		{
			return _cardInfoComponent.CardCvcText;
		}
		set
		{
			if (!string.Equals(CardCvcText, value, StringComparison.Ordinal))
			{
				_cardInfoComponent.CardCvcText = value;
				RaisePropertyChanged("IsSignUpButtonEnabled");
				RaisePropertyChanged("CardCvcText");
			}
		}
	}

	public string CardCvcValidationHint => _cardInfoComponent.CardCvcValidationHint;

	public bool IsCardCvcValid => _cardInfoComponent.IsCardCvcValid;

	public string CardCvcHintPopupTitle => _cardInfoComponent.CardCvcHintPopupTitle;

	public bool IsSignUpButtonEnabled
	{
		get
		{
			if (IsCardNumberValid && IsCardCvcValid && _cardInfoComponent.IsCardNumberEntered)
			{
				return _cardInfoComponent.IsCardCvcEntered;
			}
			return false;
		}
	}

	public string SignUpButtonTitle => "Активировать";

	public IObservable<LoyaltyCardReattachPlasticCardNavigationParameter> ShowSuccessfullyReattachedCommand => _showSuccessfullyReattached.Debounce();

	public string LoyaltyCardNumberMask => "[0000] [0000] [0000] [0]";

	public int LoyaltyCardCvcLength => 3;

	public LoyaltyCardReattachPlasticCardViewModel(LoyaltyCardReattachPlasticCardNavigationParameter reattachNavigationParameter, IUserContext userContext, ILoyaltyCardManager loyaltyCardManager, IInfoMessageService infoMessageService, ILoyaltyManager loyaltyManager, UrlNavigationHandler urlNavigationHandler)
	{
		_userContext = userContext;
		_loyaltyCardManager = loyaltyCardManager;
		_infoMessageService = infoMessageService;
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
		_reattachNavigationParameter = reattachNavigationParameter;
	}

	protected override async Task Start()
	{
		await base.Start();
		_signUpSubject.PerformDebouncingTask(SignUpAsync).Subscribe().AddTo(base.CloseDisposable);
		_profileModel = _userContext.Profile;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		AppAnalytics.AppMetrica.OpenLoyaltyAddCard();
	}

	public void OnFinishCardNumberInput()
	{
		_cardInfoComponent.OnFinishCardNumberInput();
		RaisePropertyChanged("IsCardNumberValid");
		RaisePropertyChanged("CardNumberText");
		RaisePropertyChanged("IsSignUpButtonEnabled");
	}

	public void OnFinishCardCvcInput()
	{
		_cardInfoComponent.OnFinishCardCvcInput();
		RaisePropertyChanged("IsCardCvcValid");
		RaisePropertyChanged("CardCvcText");
		RaisePropertyChanged("IsSignUpButtonEnabled");
	}

	public void SignUp()
	{
		_signUpSubject.OnNext(Unit.Default);
	}

	private async Task SignUpAsync()
	{
		State = VisualState.InProgress;
		if (_profileModel == null)
		{
			State = VisualState.Default;
		}
		else if (await PerformReattachCallAsync())
		{
			await Task.WhenAll<Result<LoyaltyCardEntity, DomainError>>(_loyaltyManager.GetBalanceAsync(), _loyaltyCardManager.GetLoyaltyCard(CancellationToken.None, forceUpdate: true));
			_userContext.LoyaltyCard = _cardInfoComponent.Entity;
			_showSuccessfullyReattached.OnNext(_reattachNavigationParameter);
		}
	}

	private async Task<bool> PerformReattachCallAsync()
	{
		Result<Unit, DomainError> result = await _loyaltyCardManager.BlockAndReissueCardAsync(CardNumberText, CardCvcText);
		if (result.IsSuccess)
		{
			return true;
		}
		if (result.Error is CardMergeError { ErrorType: not CardMergeError.Type.Default } cardMergeError)
		{
			_infoMessageService.ShowSnackbar(cardMergeError.Message ?? "");
			State = VisualState.Default;
			return false;
		}
		State = VisualState.Error;
		return false;
	}

	public void HandleLink(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}
}
