using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Java.Lang;

namespace Android.Runtime;

public static class CharSequence
{
	[return: NotNullIfNotNull("val")]
	public static ICharSequence[]? ArrayFromStringArray(string[]? val)
	{
		if (val == null)
		{
			return null;
		}
		ICharSequence[] array = new ICharSequence[val.Length];
		for (int i = 0; i < val.Length; i++)
		{
			array[i] = new Java.Lang.String(val[i]);
		}
		return array;
	}

	[return: NotNullIfNotNull("val")]
	public static string[]? ArrayToStringArray(ICharSequence[]? val)
	{
		if (val == null)
		{
			return null;
		}
		string[] array = new string[val.Length];
		for (int i = 0; i < val.Length; i++)
		{
			array[i] = val[i].ToString();
		}
		return array;
	}

	public static nint ToLocalJniHandle(string? value)
	{
		return JNIEnv.NewString(value);
	}

	public static nint ToLocalJniHandle(ICharSequence? value)
	{
		if (value != null)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		return IntPtr.Zero;
	}

	public static nint ToLocalJniHandle(IEnumerable<char>? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is string text)
		{
			return JNIEnv.NewString(text);
		}
		if (value is ICharSequence)
		{
			return JNIEnv.ToLocalJniHandle((ICharSequence)value);
		}
		return ToLocalJniHandle(string.Concat(value));
	}
}
