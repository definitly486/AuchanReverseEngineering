using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/SharedPreferences$OnSharedPreferenceChangeListener", "", "Android.Content.ISharedPreferencesOnSharedPreferenceChangeListenerInvoker")]
public interface ISharedPreferencesOnSharedPreferenceChangeListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onSharedPreferenceChanged", "(Landroid/content/SharedPreferences;Ljava/lang/String;)V", "GetOnSharedPreferenceChanged_Landroid_content_SharedPreferences_Ljava_lang_String_Handler:Android.Content.ISharedPreferencesOnSharedPreferenceChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnSharedPreferenceChanged(ISharedPreferences? sharedPreferences, string? key);
}
