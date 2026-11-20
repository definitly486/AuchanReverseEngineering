using System;
using System.Globalization;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Cache;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Analytics.Loymax;

public class LastFirebasePushTokenContainer
{
	private const string PushTokenCacheKey = "PushTokenCacheKey_0";

	private const string PushTokenLastSuccessfulSendDateKey = "PushTokenLastSuccessfulSendDateKey_0";

	private readonly ICache _cache;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly ILogService _logService;

	private string? _token;

	public bool PushTokenIsSuccessfulSentToLoymax
	{
		get
		{
			int? smartcommPushTokenUpdateInterval = _adminContext.Value.AppConfig.SmartcommPushTokenUpdateInterval;
			if (!smartcommPushTokenUpdateInterval.HasValue)
			{
				_logService.LogInfo("LastFirebasePushTokenContainer", "[Push problem] Токен неотправлен: не задан SmartcommPushTokenUpdateInterval", LogType.Notification, SystemType.MobileApp);
				return false;
			}
			DateTime? dateTime = LastSuccessfulSendDate();
			if (!dateTime.HasValue)
			{
				_logService.LogInfo("LastFirebasePushTokenContainer", "[Push problem] Токен неотправлен: нет даты последней отправки", LogType.Notification, SystemType.MobileApp);
				return false;
			}
			TimeSpan timeSpan = DateTime.UtcNow - dateTime.Value;
			TimeSpan timeSpan2 = TimeSpan.FromDays(smartcommPushTokenUpdateInterval.Value);
			bool flag = timeSpan < timeSpan2;
			_logService.LogInfo("LastFirebasePushTokenContainer", $"[Push problem 1] dontSyncPushToken={flag}, прошло {timeSpan}, порог {timeSpan2}", LogType.Notification, SystemType.MobileApp);
			return flag;
		}
		set
		{
			if (value)
			{
				SetLastSuccessfulSendDate(DateTime.UtcNow);
			}
			else
			{
				ClearLastSuccessfulSendDate();
			}
		}
	}

	public LastFirebasePushTokenContainer(ICache cache, Lazy<IAdminContext> adminContext, ILogService logService)
	{
		_cache = cache;
		_adminContext = adminContext;
		_logService = logService;
	}

	public async Task UpdateToken(string token)
	{
		if ((await GetSavedToken()).Equals(token))
		{
			_logService.LogInfo("LastFirebasePushTokenContainer", "[Push problem 1] Токен не изменился, пропускаем", LogType.Notification, SystemType.MobileApp);
			return;
		}
		_logService.LogInfo("LastFirebasePushTokenContainer", "[Push problem 1] Новый токен, сохраняем: " + token, LogType.Notification, SystemType.MobileApp);
		await _cache.SaveSecure("PushTokenCacheKey_0", token);
		PushTokenIsSuccessfulSentToLoymax = false;
	}

	public async Task<bool> PushTokenIsSuccessfullySentAsync()
	{
		await _adminContext.Value.WaitForAppConfig().ConfigureAwait(continueOnCapturedContext: false);
		return PushTokenIsSuccessfulSentToLoymax;
	}

	public async Task<string> GetSavedToken()
	{
		return (await _cache.TryGetSecure<string>("PushTokenCacheKey_0")) ?? string.Empty;
	}

	private DateTime? LastSuccessfulSendDate()
	{
		string text = PreferencesEx.Get<string>("PushTokenLastSuccessfulSendDateKey_0");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
		{
			return result;
		}
		return null;
	}

	private static void SetLastSuccessfulSendDate(DateTime dateUtc)
	{
		PreferencesEx.Set("PushTokenLastSuccessfulSendDateKey_0", dateUtc.ToString(CultureInfo.InvariantCulture));
	}

	private static void ClearLastSuccessfulSendDate()
	{
		Preferences.Remove("PushTokenLastSuccessfulSendDateKey_0");
	}
}
