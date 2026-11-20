using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.Loymax.DTO;
using Auchan.Common.Analytics.Loymax.Models;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Analytics.Loymax;

public class LoymaxPushTokenService
{
	private readonly string FirebaseMessageIdCacheKey = "FirebaseMessageIdCacheKey";

	private readonly LoymaxService _loymaxService;

	private readonly LastFirebasePushTokenContainer _lastFirebasePushTokenContainer;

	private readonly IDeviceService _deviceService;

	private readonly IUserContext _userContext;

	private readonly ILogService _logService;

	private LoyaltyEnrollmentModel? _loyaltyEnrollmentModel;

	private bool UserRegistered
	{
		get
		{
			return PreferencesEx.GetBool("UserRegistered") == true;
		}
		set
		{
			PreferencesEx.SetBool("UserRegistered", value);
		}
	}

	private int? LoyaltyIdFromEnrollment
	{
		get
		{
			return PreferencesEx.GetStruct<int>("LoyaltyIdFromEnrollment");
		}
		set
		{
			if (!value.HasValue)
			{
				Preferences.Remove("LoyaltyIdFromEnrollment");
			}
			else
			{
				PreferencesEx.Set("LoyaltyIdFromEnrollment", value.Value);
			}
		}
	}

	public string VirtualCardNumber => _loyaltyEnrollmentModel?.VirtualCardNumber ?? string.Empty;

	public string CardNumber => _loyaltyEnrollmentModel?.CardNumber ?? string.Empty;

	public LoymaxPushTokenService(LastFirebasePushTokenContainer lastFirebasePushTokenContainer, IDeviceService deviceService, LoymaxService loymaxService, IUserContext userContext, ILogService logService)
	{
		_loymaxService = loymaxService;
		_userContext = userContext;
		_lastFirebasePushTokenContainer = lastFirebasePushTokenContainer;
		_deviceService = deviceService;
		_logService = logService;
		_userContext.AfterLoggedOut += delegate
		{
			UserRegistered = false;
			LoyaltyIdFromEnrollment = null;
			return Task.CompletedTask;
		};
		_userContext.AfterLoggedIn += () => SetPushToken();
	}

	public void SaveEnrollmentResult(Result<LoyaltyEnrollmentModel, DomainError> enrollResult, bool wantToReceiveSuggestions)
	{
		if (enrollResult.IsSuccess)
		{
			_loyaltyEnrollmentModel = enrollResult.Value;
		}
		if (enrollResult.IsSuccess && wantToReceiveSuggestions)
		{
			LoyaltyIdFromEnrollment = enrollResult.Value.LoyaltyId;
		}
	}

	public void RegisterUserInLoymaxOnSubscriptionChange()
	{
		RegisterUserInLoymax().SafeFireAndForget((Action<Exception>)null, false);
	}

	public async Task SetPushToken()
	{
		ProfileModel profile = _userContext.Profile;
		if (profile == null)
		{
			_logService.LogError("LoymaxPushTokenService", "[Push problem] Нет профиля, регистрацию токена пропускаем", LogType.Notification, SystemType.MobileApp);
			return;
		}
		if (profile.LoymaxLoyaltyId == null || string.IsNullOrWhiteSpace(profile.LoymaxLoyaltyId))
		{
			int? loyaltyIdFromEnrollment = LoyaltyIdFromEnrollment;
			if (!loyaltyIdFromEnrollment.HasValue)
			{
				_logService.LogError("LoymaxPushTokenService", "[Push problem] Нет loyaltyId, регистрацию токена пропускаем", LogType.Notification, SystemType.MobileApp);
				return;
			}
			_ = loyaltyIdFromEnrollment.Value;
		}
		else
		{
			Convert.ToInt32(profile.LoymaxLoyaltyId);
		}
		if (profile.Subscribes.Any((SubscriptionModel x) => x.CommunicationType.Title == "mobile_push"))
		{
			if (!UserRegistered && (await RegisterUserInLoymax()).IsSuccess)
			{
				await SendPushClickedEventIfNeeded();
				return;
			}
			if (await _lastFirebasePushTokenContainer.PushTokenIsSuccessfullySentAsync())
			{
				await SendPushClickedEventIfNeeded();
				return;
			}
			await RegisterDevice();
			await SendPushClickedEventIfNeeded();
		}
		else
		{
			_logService.LogError("LoymaxPushTokenService", "[Push problem 1] Нет подписки MobilePush, токен не отправлен", LogType.Notification, SystemType.MobileApp);
		}
	}

	public void OnPushClicked(string? firebaseMessageId)
	{
		PreferencesEx.Set(FirebaseMessageIdCacheKey, firebaseMessageId);
		SendPushClickedEventIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task SendPushClickedEventIfNeeded()
	{
		string text = PreferencesEx.Get<string>(FirebaseMessageIdCacheKey);
		if (!string.IsNullOrWhiteSpace(text) && (await _loymaxService.CommunicationEvents(new global::_003C_003Ez__ReadOnlySingleElementList<Event>(new Event
		{
			Type = "open",
			MessageId = text
		}))).IsSuccess)
		{
			PreferencesEx.Set(FirebaseMessageIdCacheKey, string.Empty);
		}
	}

	private async Task<Result<Unit, DomainError>> RegisterUserInLoymax()
	{
		Result<Unit, DomainError> result = await RegisterDevice();
		if (result.IsSuccess)
		{
			_logService.LogInfo("LoymaxPushTokenService", "[Push problem 1] Токен отправлен, пользователь зарегистрирован в Loymax", LogType.Notification, SystemType.MobileApp);
			UserRegistered = true;
		}
		return result;
	}

	private async Task<Result<Unit, DomainError>> RegisterDevice()
	{
		string text = await _lastFirebasePushTokenContainer.GetSavedToken();
		if (string.IsNullOrWhiteSpace(text))
		{
			_logService.LogError("LoymaxPushTokenService", "[Push problem] Пустой push-токен, устройство не зарегистрировано", LogType.Notification, SystemType.MobileApp);
			return Result.Failure<Unit, DomainError>(new NoDataError());
		}
		_ = string.Empty;
		_ = 1;
		string pushServiceType = "gms";
		if (false)
		{
		}
		if (_deviceService.IsHuawei)
		{
			pushServiceType = "hms";
		}
		Result<LoymaxResponseDto, DomainError> result = await _loymaxService.CommunicationPushes(text, "push", pushServiceType, isDeleted: false);
		if (result.IsSuccess)
		{
			_logService.LogInfo("LoymaxPushTokenService", "[Push problem 1] Токен отправлен на сервер Loymax (" + pushServiceType + ")", LogType.Notification, SystemType.MobileApp);
			_lastFirebasePushTokenContainer.PushTokenIsSuccessfulSentToLoymax = true;
			return Unit.Default;
		}
		_logService.LogError("LoymaxPushTokenService", $"[Push problem] Сервер Loymax не принял токен: {result.Error}", LogType.Notification, SystemType.MobileApp);
		return result.Error;
	}
}
