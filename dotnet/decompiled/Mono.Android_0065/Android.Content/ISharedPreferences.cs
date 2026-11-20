using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/SharedPreferences", "", "Android.Content.ISharedPreferencesInvoker")]
public interface ISharedPreferences : IJavaObject, IDisposable, IJavaPeerable
{
	IDictionary<string, object>? All { get; }

	bool Contains(string? key);

	ISharedPreferencesEditor? Edit();

	bool GetBoolean(string? key, bool defValue);

	float GetFloat(string? key, float defValue);

	int GetInt(string? key, int defValue);

	long GetLong(string? key, long defValue);

	string? GetString(string? key, string? defValue);

	ICollection<string>? GetStringSet(string? key, ICollection<string>? defValues);

	void RegisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener? listener);

	void UnregisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener? listener);
}
