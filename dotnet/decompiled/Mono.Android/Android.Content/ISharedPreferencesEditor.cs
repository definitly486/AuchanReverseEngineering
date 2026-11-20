using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/SharedPreferences$Editor", "", "Android.Content.ISharedPreferencesEditorInvoker")]
public interface ISharedPreferencesEditor : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("apply", "()V", "GetApplyHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Apply();

	[Register("clear", "()Landroid/content/SharedPreferences$Editor;", "GetClearHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? Clear();

	[Register("commit", "()Z", "GetCommitHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Commit();

	[Register("putBoolean", "(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;", "GetPutBoolean_Ljava_lang_String_ZHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? PutBoolean(string? key, bool value);

	[Register("putFloat", "(Ljava/lang/String;F)Landroid/content/SharedPreferences$Editor;", "GetPutFloat_Ljava_lang_String_FHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? PutFloat(string? key, float value);

	[Register("putInt", "(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;", "GetPutInt_Ljava_lang_String_IHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? PutInt(string? key, int value);

	[Register("putLong", "(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;", "GetPutLong_Ljava_lang_String_JHandler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? PutLong(string? key, long value);

	[Register("putString", "(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;", "GetPutString_Ljava_lang_String_Ljava_lang_String_Handler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? PutString(string? key, string? value);

	[Register("putStringSet", "(Ljava/lang/String;Ljava/util/Set;)Landroid/content/SharedPreferences$Editor;", "GetPutStringSet_Ljava_lang_String_Ljava_util_Set_Handler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? PutStringSet(string? key, ICollection<string>? values);

	[Register("remove", "(Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;", "GetRemove_Ljava_lang_String_Handler:Android.Content.ISharedPreferencesEditorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISharedPreferencesEditor? Remove(string? key);
}
