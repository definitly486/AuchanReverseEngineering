using System;
using System.Globalization;
using Auchan.Common.Extensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.PersonalCabinet.Authorization.Managers;

public class PinRetryFreezeManager
{
	private const string REQUEST_PIN_FREEZE_TIME_CACHE_KEY = "REQUEST_PIN_FREEZE_TIME_CACHE_KEY";

	private const string PIN_REQUEST_COUNT_CACHE_KEY = "PIN_REQUEST_COUNT_CACHE_KEY";

	private const string PHONE_FOR_PIN_REQUEST_CACHE_KEY = "PHONE_FOR_PIN_REQUEST_CACHE_KEY";

	private int PinRequestCount
	{
		get
		{
			return Preferences.Get("PIN_REQUEST_COUNT_CACHE_KEY", 0);
		}
		set
		{
			Preferences.Set("PIN_REQUEST_COUNT_CACHE_KEY", value);
		}
	}

	private DateTime? PinRequestFreezeDateTime
	{
		get
		{
			string text = PreferencesEx.Get<string>("REQUEST_PIN_FREEZE_TIME_CACHE_KEY");
			if (text != null)
			{
				return Convert.ToDateTime(text);
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				PreferencesEx.Set("REQUEST_PIN_FREEZE_TIME_CACHE_KEY", value.Value.ToString(CultureInfo.CurrentCulture));
			}
			else
			{
				Preferences.Remove("REQUEST_PIN_FREEZE_TIME_CACHE_KEY");
			}
		}
	}

	private bool HasOneHourPassedSinceFreezing
	{
		get
		{
			if (PinRequestFreezeDateTime.HasValue)
			{
				DateTime utcNow = DateTime.UtcNow;
				DateTime? pinRequestFreezeDateTime = PinRequestFreezeDateTime;
				return utcNow - pinRequestFreezeDateTime >= TimeSpan.FromHours(1);
			}
			return false;
		}
	}

	private bool NoMorePinRequestIteration => PinRequestCount >= 5;

	private void RemoveInfoAboutFreezeFromPreferences()
	{
		Preferences.Remove("REQUEST_PIN_FREEZE_TIME_CACHE_KEY");
		Preferences.Remove("PIN_REQUEST_COUNT_CACHE_KEY");
		Preferences.Remove("PHONE_FOR_PIN_REQUEST_CACHE_KEY");
	}

	public void CheckAndUpdatePhone(string newPhone)
	{
		string text = PreferencesEx.Get<string>("PHONE_FOR_PIN_REQUEST_CACHE_KEY");
		if (text != null && !text.Equals(newPhone))
		{
			RemoveInfoAboutFreezeFromPreferences();
		}
		PreferencesEx.Set("PHONE_FOR_PIN_REQUEST_CACHE_KEY", newPhone);
	}

	public int GetSecondsToRetry()
	{
		int num = ((!NoMorePinRequestIteration) ? 60 : 900);
		DateTime? pinRequestFreezeDateTime = PinRequestFreezeDateTime;
		if (!pinRequestFreezeDateTime.HasValue)
		{
			return num;
		}
		int num2 = num - (int)(DateTime.UtcNow - pinRequestFreezeDateTime.Value).TotalSeconds;
		if (num2 <= 0)
		{
			return 0;
		}
		return num2;
	}

	public bool IsPinSendingBlocked()
	{
		int num = ((!NoMorePinRequestIteration) ? 60 : 900);
		DateTime? pinRequestFreezeDateTime = PinRequestFreezeDateTime;
		if (!pinRequestFreezeDateTime.HasValue)
		{
			return false;
		}
		int num2 = num - (int)(DateTime.UtcNow - pinRequestFreezeDateTime.Value).TotalSeconds;
		if (num2 > 0)
		{
			return num2 < num;
		}
		return false;
	}

	public void PinRequestCountWasIncreased()
	{
		if (HasOneHourPassedSinceFreezing || NoMorePinRequestIteration)
		{
			RemoveInfoAboutFreezeFromPreferences();
		}
		PinRequestCount++;
		PinRequestFreezeDateTime = DateTime.UtcNow;
	}
}
