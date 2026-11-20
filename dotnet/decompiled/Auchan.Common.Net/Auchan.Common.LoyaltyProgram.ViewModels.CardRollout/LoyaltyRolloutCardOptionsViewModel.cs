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
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;

public class LoyaltyRolloutCardOptionsViewModel : ScreenViewModel
{
	private readonly IInfoMessageService _infoMessageService;

	private readonly ILoyaltyPersonalizedGreetingsManager _loyaltyPersonalizedGreetingsManager;

	private readonly IUserContext _userContext;

	private readonly SignUpViewModel.Parameter _parameter;

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly Subject<SignUpViewModel.Parameter> _navigateToSignUp = new Subject<SignUpViewModel.Parameter>();

	private readonly Subject<LoyaltyCardReattachPlasticCardNavigationParameter> _navigateToReattachPlasticCard = new Subject<LoyaltyCardReattachPlasticCardNavigationParameter>();

	private readonly Subject<LoyaltyCardReattachPlasticCardNavigationParameter> _showSuccessfullyReattached = new Subject<LoyaltyCardReattachPlasticCardNavigationParameter>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CLoymaxErrorText_003Ek__BackingField;

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
	}

	private string LoymaxErrorText
	{
		[CompilerGenerated]
		get
		{
			return _003CLoymaxErrorText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CLoymaxErrorText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CLoymaxErrorText_003Ek__BackingField = value;
				RaisePropertyChanged("LoymaxErrorText");
			}
		}
	} = "Упс! Что-то пошло не так.";

	public string ScreenTitle => "Карта АШАН";

	public string DoYouHaveACardMessage => "У вас уже есть\nпластиковая карта АШАН?";

	public string ActivatePlasticCardButtonText => "Да";

	public string CreateVirtualCardButtonText => "Нет";

	public bool ItRolloutCardOptionsDialog => _parameter.ReattachType == LoyaltyCardReattachType.BlockAndReatach;

	public IObservable<SignUpViewModel.Parameter> GoToPersonalProfileCommand => _navigateToSignUp.Debounce();

	public IObservable<LoyaltyCardReattachPlasticCardNavigationParameter> GoToReattachPlasticCardCommand => _navigateToReattachPlasticCard.Debounce();

	public UICommand NavigateToAuthorizationCommand { get; } = new UICommand();

	public IObservable<LoyaltyCardReattachPlasticCardNavigationParameter> ShowSuccessfullyReattachedCommand => _showSuccessfullyReattached.Debounce();

	protected override string ScreenName => "loyality_new_card_activation_screen";

	public LoyaltyRolloutCardOptionsViewModel(SignUpViewModel.Parameter parameter, ILoyaltyCardManager loyaltyCardManager, IInfoMessageService infoMessageService, ILoyaltyPersonalizedGreetingsManager loyaltyPersonalizedGreetingsManager, IUserContext userContext, ILoyaltyManager loyaltyManager)
	{
		_parameter = parameter;
		_loyaltyCardManager = loyaltyCardManager;
		_infoMessageService = infoMessageService;
		_loyaltyPersonalizedGreetingsManager = loyaltyPersonalizedGreetingsManager;
		_userContext = userContext;
		_loyaltyManager = loyaltyManager;
	}

	protected override async Task Start()
	{
		await base.Start();
		_loyaltyPersonalizedGreetingsManager.TrySetupGreetingForOldUsers();
	}

	public async void OnActivatePlastic()
	{
		_parameter.CardRolloutType = LoyaltyCardRolloutType.Plastic;
		if (_parameter.ReattachType == LoyaltyCardReattachType.BlockAndReatach)
		{
			_navigateToReattachPlasticCard.OnNext(new LoyaltyCardReattachPlasticCardNavigationParameter
			{
				ReattachType = LoyaltyCardReattachType.AfterBlock
			});
		}
		else
		{
			await RemindToReviewDateOfBirthIfNeededAsync();
			_navigateToSignUp.OnNext(_parameter);
		}
	}

	public void GoToAuthorization()
	{
		Logout();
		NavigateToAuthorizationCommand.Trigger();
	}

	public async void OnCreateVirtual()
	{
		AppAnalytics.AppMetrica.СreateLoyaltyVirtualCard();
		_parameter.CardRolloutType = LoyaltyCardRolloutType.Virtual;
		if (_parameter.ReattachType == LoyaltyCardReattachType.BlockAndReatach || _parameter.ReattachType == LoyaltyCardReattachType.AfterBlock)
		{
			Result<Unit, DomainError> result = await BlockAndReissueVirtualCardAsync();
			if (result.IsFailure && result.Error is CardMergeError { ErrorType: CardMergeError.Type.CardMergeFailed } cardMergeError)
			{
				_infoMessageService.ShowSnackbar(cardMergeError.Message ?? "");
				return;
			}
		}
		if (_parameter.ReattachType == LoyaltyCardReattachType.BlockAndReatach)
		{
			_showSuccessfullyReattached.OnNext(new LoyaltyCardReattachPlasticCardNavigationParameter
			{
				ReattachType = _parameter.ReattachType,
				State = State,
				CustomMessage = LoymaxErrorText
			});
		}
		else
		{
			await RemindToReviewDateOfBirthIfNeededAsync();
			_navigateToSignUp.OnNext(_parameter);
		}
	}

	private Task RemindToReviewDateOfBirthIfNeededAsync()
	{
		if (string.IsNullOrEmpty(_userContext.Profile?.FirstName))
		{
			return Task.CompletedTask;
		}
		ProfileModel? profile = _userContext.Profile;
		if (profile == null || !profile.Birthday.HasValue)
		{
			return Task.CompletedTask;
		}
		return _infoMessageService.ShowDialogAsync("Проверьте дату рождения", "Вы сможете изменить ее только\nодин раз во время регистрации", new AlertButton[1]
		{
			new AlertButton
			{
				Title = "OK",
				Type = ActionType.Positive
			}
		});
	}

	public void Logout()
	{
		_userContext.LogOut();
	}

	private async Task<Result<Unit, DomainError>> BlockAndReissueVirtualCardAsync()
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _loyaltyCardManager.BlockAndReissueCardAsync();
		if (!result.IsSuccess)
		{
			State = VisualState.Error;
			return result;
		}
		await Task.WhenAll<Result<LoyaltyCardEntity, DomainError>>(_loyaltyManager.GetBalanceAsync(), _loyaltyCardManager.GetLoyaltyCard(CancellationToken.None, forceUpdate: true));
		State = VisualState.Default;
		return result;
	}
}
