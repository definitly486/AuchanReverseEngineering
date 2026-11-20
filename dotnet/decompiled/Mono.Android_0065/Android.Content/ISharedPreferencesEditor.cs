using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/SharedPreferences$Editor", "", "Android.Content.ISharedPreferencesEditorInvoker")]
public interface ISharedPreferencesEditor : IJavaObject, IDisposable, IJavaPeerable
{
	void Apply();

	ISharedPreferencesEditor? Clear();

	bool Commit();

	ISharedPreferencesEditor? PutBoolean(string? key, bool value);

	ISharedPreferencesEditor? PutFloat(string? key, float value);

	ISharedPreferencesEditor? PutInt(string? key, int value);

	ISharedPreferencesEditor? PutLong(string? key, long value);

	ISharedPreferencesEditor? PutString(string? key, string? value);

	ISharedPreferencesEditor? PutStringSet(string? key, ICollection<string>? values);

	ISharedPreferencesEditor? Remove(string? key);
}
