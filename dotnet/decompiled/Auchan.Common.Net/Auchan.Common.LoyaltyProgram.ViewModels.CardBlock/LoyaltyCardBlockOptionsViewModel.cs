using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Interactors;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardBlock;

public class LoyaltyCardBlockOptionsViewModel : ScreenViewModel
{
	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IUserContext _userContext;

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly ILogoutService _logoutService;

	private readonly LogoutInteractor _logoutInteractor;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	private readonly Subject<Unit> _closeSubject = new Subject<Unit>();

	private readonly Subject<LoyaltyCardReattachPlasticCardNavigationParameter> _navigateToReattach = new Subject<LoyaltyCardReattachPlasticCardNavigationParameter>();

	private readonly Subject<Unit> _blockSubject = new Subject<Unit>();

	private readonly Subject<Unit> _blockReissueSubject = new Subject<Unit>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

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

	public IObservable<Unit> CloseCommand => _closeSubject;

	public string ScreenTitle => "Блокировка карты";

	public string ErrorTitle => "Заблокировать карту";

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	public string PerformBlockButtonText => "Заблокировать карту";

	public string PerformBlockAndReissueButtonText => "Заблокировать и создать новую";

	private LoyaltyCardEntity? LoyaltyCard => _userContext.LoyaltyCard;

	public IObservable<LoyaltyCardReattachPlasticCardNavigationParameter> GoToReattachPlasticCardCommand => _navigateToReattach.Debounce();

	public LoyaltyCardBlockOptionsViewModel(ILoyaltyCardManager loyaltyCardManager, IInfoMessageService infoMessageService, IUserContext userContext, ILogoutService logoutService, LogoutInteractor logoutInteractor, ILoyaltyManager loyaltyManager, UrlNavigationHandler urlNavigationHandler)
	{
		_loyaltyCardManager = loyaltyCardManager;
		_infoMessageService = infoMessageService;
		_userContext = userContext;
		_logoutService = logoutService;
		_logoutInteractor = logoutInteractor;
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
	}

	protected override async Task Start()
	{
		await base.Start();
		_blockSubject.PerformDebouncingTask(OnPerformBlockButtonSelectedAsync).Subscribe().AddTo(base.CloseDisposable);
		_blockReissueSubject.PerformDebouncingTask(OnPerformBlockAndReissueButtonSelectedAsync).Subscribe().AddTo(base.CloseDisposable);
	}

	public void OnPerformBlockButtonSelected()
	{
		_blockSubject.OnNext(Unit.Default);
	}

	public void OnPerformBlockAndReissueButtonSelected()
	{
		_blockReissueSubject.OnNext(Unit.Default);
	}

	private async Task OnPerformBlockButtonSelectedAsync()
	{
		if (await GetIsUserAgreedToBlockAsync())
		{
			State = VisualState.InProgress;
			if ((await _loyaltyCardManager.BlockCardAsync()).IsFailure)
			{
				ShowCardBlockError();
				State = VisualState.Error;
				return;
			}
			State = VisualState.Default;
			await ShowCardBlockedMessageAsync();
			_closeSubject.OnNext(Unit.Default);
			await Task.Delay(2000);
			ProcessLogoutResult(await _logoutInteractor.Logout(fromAll: true));
			ProcessLogoutResult(await _logoutInteractor.Logout());
			await _logoutService.LogoutAsync();
		}
	}

	private async Task OnPerformBlockAndReissueButtonSelectedAsync()
	{
		if (await GetIsUserAgreedToReissueAsync())
		{
			_navigateToReattach.OnNext(new LoyaltyCardReattachPlasticCardNavigationParameter
			{
				ReattachType = LoyaltyCardReattachType.ReattachVirtual
			});
			RaisePropertyChanged("LoyaltyCard");
		}
	}

	private Task<bool> GetIsUserAgreedToBlockAsync()
	{
		return GetIsUserAgreedToPerformAnActionAsync("Уверены, что хотите заблокировать карту?", "Если вы заблокируете карту - вы не сможете пользоваться приложением: программой лояльности, доставкой, самостоятельным сканированием. Мы сохраним ваши данные и будем ждать возвращения");
	}

	private Task<bool> GetIsUserAgreedToReissueAsync()
	{
		return GetIsUserAgreedToPerformAnActionAsync("Уверены, что хотите заблокировать текущую карту и создать новую?", "Ваши баллы мы сохраним и перенесем на счет новой карты АШАН");
	}

	private void ShowCardBlockError()
	{
		_infoMessageService.ShowSnackbar("Произошла ошибка во время блокировки карты.");
	}

	private async Task<bool> GetIsUserAgreedToPerformAnActionAsync(string title, string message)
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync(title, message, new AlertButton[2]
		{
			new AlertButton
			{
				Title = "Нет",
				Type = ActionType.Negative
			},
			new AlertButton
			{
				Title = "Да",
				Type = ActionType.Positive
			}
		});
		if ((object)obj == null || obj.Type != ActionType.Positive)
		{
			return false;
		}
		return true;
	}

	private Task ShowCardBlockedMessageAsync()
	{
		return _infoMessageService.ShowDialogAsync("Ваша карта успешно заблокирована.", string.Empty, new AlertButton[1]
		{
			new AlertButton
			{
				Title = "OK",
				Type = ActionType.Positive
			}
		});
	}

	private void ProcessLogoutResult(Result<Unit, DomainError> result)
	{
		State = VisualState.Default;
		if (result.IsFailure)
		{
			_infoMessageService.ShowCommonError();
		}
	}

	public void HandleLink(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}
}
