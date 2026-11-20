using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/SharedPreferences", "", "Android.Content.ISharedPreferencesInvoker")]
public interface ISharedPreferences : IJavaObject, IDisposable, IJavaPeerable
{
	IDictionary<string, object>? All
	{
		[Register("getAll", "()Ljava/util/Map;", "GetGetAllHandler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("contains", "(Ljava/lang/String;)Z", "GetContains_Ljava_lang_String_Handler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Contains(string? key);

	[Register("edit", "()Landroid/content/SharedPreferences$Editor;", "GetEditHandler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? Edit();

	[Register("getBoolean", "(Ljava/lang/String;Z)Z", "GetGetBoolean_Ljava_lang_String_ZHandler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool GetBoolean(string? key, bool defValue);

	[Register("getFloat", "(Ljava/lang/String;F)F", "GetGetFloat_Ljava_lang_String_FHandler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	float GetFloat(string? key, float defValue);

	[Register("getInt", "(Ljava/lang/String;I)I", "GetGetInt_Ljava_lang_String_IHandler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetInt(string? key, int defValue);

	[Register("getLong", "(Ljava/lang/String;J)J", "GetGetLong_Ljava_lang_String_JHandler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	long GetLong(string? key, long defValue);

	[Register("getString", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetGetString_Ljava_lang_String_Ljava_lang_String_Handler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetString(string? key, string? defValue);

	[Register("getStringSet", "(Ljava/lang/String;Ljava/util/Set;)Ljava/util/Set;", "GetGetStringSet_Ljava_lang_String_Ljava_util_Set_Handler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ICollection<string>? GetStringSet(string? key, ICollection<string>? defValues);

	[Register("registerOnSharedPreferenceChangeListener", "(Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;)V", "GetRegisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_Handler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RegisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener? listener);

	[Register("unregisterOnSharedPreferenceChangeListener", "(Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;)V", "GetUnregisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_Handler:Android.Content.ISharedPreferencesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void UnregisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener? listener);
}
