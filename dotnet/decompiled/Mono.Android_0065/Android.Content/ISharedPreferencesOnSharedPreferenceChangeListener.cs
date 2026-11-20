using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/SharedPreferences$OnSharedPreferenceChangeListener", "", "Android.Content.ISharedPreferencesOnSharedPreferenceChangeListenerInvoker")]
public interface ISharedPreferencesOnSharedPreferenceChangeListener : IJavaObject, IDisposable, IJavaPeerable
{
	void OnSharedPreferenceChanged(ISharedPreferences? sharedPreferences, string? key);
}
