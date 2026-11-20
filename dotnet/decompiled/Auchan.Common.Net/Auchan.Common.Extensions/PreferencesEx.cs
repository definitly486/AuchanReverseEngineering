using System;
using System.Diagnostics.CodeAnalysis;
using Auchan.Common.Common;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace Auchan.Common.Extensions;

public static class PreferencesEx
{
	public static T? Get<T>(string key, string? sharedName = null) where T : class
	{
		string text = ((sharedName == null) ? Preferences.Get(key, null) : Preferences.Get(key, null, sharedName));
		if (text == null)
		{
			return null;
		}
		T result = null;
		if (text.TryParseJson<TimedPreference<T>>(out var result2))
		{
			if (result2.Expiration > DateTime.UtcNow)
			{
				return result2.Value;
			}
			Preferences.Clear(key);
		}
		else
		{
			text.TryParseJson<T>(out result);
		}
		return result;
	}

	public static T? GetStruct<T>(string key, string? sharedName = null) where T : struct
	{
		string text = ((sharedName == null) ? Preferences.Get(key, null) : Preferences.Get(key, null, sharedName));
		if (text == null)
		{
			return null;
		}
		T? result = null;
		if (text.TryParseJson<TimedPreference<T>>(out var result2))
		{
			if (result2.Expiration > DateTime.UtcNow)
			{
				result = result2.Value;
			}
			else
			{
				Preferences.Clear(key);
			}
		}
		else
		{
			text.TryParseJson<T?>(out result);
		}
		return result;
	}

	[return: NotNullIfNotNull("value")]
	[return: MaybeNull]
	public static T Set<T>(string key, [AllowNull] T value, string? sharedName = null)
	{
		string value2 = JsonConvert.SerializeObject(value);
		if (sharedName == null)
		{
			Preferences.Set(key, value2);
		}
		else
		{
			Preferences.Set(key, value2, sharedName);
		}
		return value;
	}

	public static T Set<T>(string key, T value, TimeSpan lifeSpan, string? sharedName = null)
	{
		string value2 = JsonConvert.SerializeObject(new TimedPreference<T>(value, lifeSpan));
		if (sharedName == null)
		{
			Preferences.Set(key, value2);
		}
		else
		{
			Preferences.Set(key, value2, sharedName);
		}
		return value;
	}

	public static T GetEnum<T>(string key, T defaulValue, string? sharedName = null) where T : Enum
	{
		int num = ((sharedName == null) ? Preferences.Get(key, int.MinValue) : Preferences.Get(key, int.MinValue, sharedName));
		if (num == int.MinValue)
		{
			return defaulValue;
		}
		return (T)(object)num;
	}

	public static T SetEnum<T>(string key, T value, string? sharedName = null) where T : Enum
	{
		int value2 = Convert.ToInt32(value);
		if (sharedName == null)
		{
			Preferences.Set(key, value2);
		}
		else
		{
			Preferences.Set(key, value2, sharedName);
		}
		return value;
	}

	public static bool? GetBool(string key, string? sharedName = null)
	{
		if (!bool.TryParse((sharedName == null) ? Get<string>(key) : Get<string>(key, sharedName), out var result))
		{
			return null;
		}
		return result;
	}

	public static bool SetBool(string key, bool value, string? sharedName = null)
	{
		string value2 = JsonConvert.SerializeObject(value.ToString());
		if (sharedName == null)
		{
			Preferences.Set(key, value2);
		}
		else
		{
			Preferences.Set(key, value2, sharedName);
		}
		return value;
	}
}
