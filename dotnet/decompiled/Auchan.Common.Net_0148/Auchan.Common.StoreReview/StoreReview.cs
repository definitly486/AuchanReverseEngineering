using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Plugin.StoreReview;

namespace Auchan.Common.StoreReview;

public class StoreReview
{
	private bool _customerFlagsRequestWasSuccess;

	private bool _dialogIsNowShowing;

	private Task _init;

	private readonly IInfoMessageService _infoMessageService;

	private readonly CustomerFlagService _customerFlagService;

	private readonly INavigationService _navigationService;

	public bool IsRatingPopupNeeded
	{
		get
		{
			return PreferencesEx.GetBool("IsRatingPopupNeeded", "UserContextPreferences") == true;
		}
		set
		{
			PreferencesEx.SetBool("IsRatingPopupNeeded", value, "UserContextPreferences");
		}
	}

	public bool? IsFirstPurchaseApp
	{
		get
		{
			return PreferencesEx.GetBool("IsFirstPurchaseApp", "UserContextPreferences");
		}
		set
		{
			PreferencesEx.SetBool("IsFirstPurchaseApp", value.Value, "UserContextPreferences");
		}
	}

	public StoreReview(IInfoMessageService infoMessageService, CustomerFlagService customerFlagService, INavigationService navigationService, IUserContext userContext)
	{
		_infoMessageService = infoMessageService;
		_customerFlagService = customerFlagService;
		_navigationService = navigationService;
		_init = (userContext.Authorized ? CheckStoreReviewAsync() : Task.CompletedTask);
		userContext.AfterLoggedIn += () => _init = CheckStoreReviewAsync();
	}

	private async Task CheckStoreReviewAsync()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		Result<CustomerFlags, DomainError> result = await _customerFlagService.GetCustomerFlags();
		_customerFlagsRequestWasSuccess = result.IsSuccess;
		IsRatingPopupNeeded = result.IsSuccess && result.Value.IsRatingPopupNeeded;
		IsFirstPurchaseApp = result.IsSuccess && result.Value.IsFirstPurchaseApp;
	}

	public async Task RequestReviewIfNeeded()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		await _init;
		if (_customerFlagsRequestWasSuccess && IsRatingPopupNeeded && !_dialogIsNowShowing)
		{
			_dialogIsNowShowing = true;
			AlertButton alertButton = await _infoMessageService.ShowDialogAsync("Вам нравится приложение?", "Благодаря вашим оценкам мы улучшаем приложение", new AlertButton[2]
			{
				new AlertButton
				{
					Title = "Да",
					Type = ActionType.Positive
				},
				new AlertButton
				{
					Title = "Нет",
					Type = ActionType.Negative
				}
			});
			_dialogIsNowShowing = false;
			if ((object)alertButton != null && alertButton.Type == ActionType.Positive)
			{
				await OnPositive();
			}
			else if ((object)alertButton == null || alertButton.Type != ActionType.Negative)
			{
				await OnNothing();
			}
			else
			{
				await OnNegative();
			}
		}
	}

	private async Task OnPositive()
	{
		if ((await _customerFlagService.UpdateCustomerFlags(new UpdateCustomerFlagsRequestDto
		{
			IsRatingInitiated = true
		})).IsSuccess)
		{
			IsRatingPopupNeeded = false;
			if (CrossStoreReview.IsSupported)
			{
				bool testMode = false;
				CrossStoreReview.Current.RequestReview(testMode).SafeFireAndForget((Action<Exception>)null, false);
			}
			AppAnalytics.AppMetrica.TrackEvent("gotostore");
		}
	}

	private async Task OnNegative()
	{
		AppAnalytics.AppMetrica.TrackEvent("gotofos");
		if ((await _customerFlagService.UpdateCustomerFlags(new UpdateCustomerFlagsRequestDto
		{
			IsRatingInitiated = false
		})).IsSuccess)
		{
			IsRatingPopupNeeded = false;
		}
		_navigationService.NavigateTo(typeof(DynamicFeedbackViewModel), new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory, null, "Онлайн-магазин", "Ошибка на сайте/в приложении"));
	}

	private async Task OnNothing()
	{
		if ((await _customerFlagService.UpdateCustomerFlags(new UpdateCustomerFlagsRequestDto
		{
			IsRatingInitiated = false
		})).IsSuccess)
		{
			IsRatingPopupNeeded = false;
		}
	}

	public void DoNotihing()
	{
	}
}
