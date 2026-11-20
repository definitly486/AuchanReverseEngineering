using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Microsoft.Maui.Storage;

public static class Preferences
{
	private static IPreferences? defaultImplementation;

	internal static Type[] SupportedTypes = new Type[8]
	{
		typeof(string),
		typeof(int),
		typeof(bool),
		typeof(long),
		typeof(double),
		typeof(float),
		typeof(DateTime),
		typeof(DateTimeOffset)
	};

	private static IPreferences Current => Default;

	public static IPreferences Default => defaultImplementation ?? (defaultImplementation = new PreferencesImplementation());

	public static void Remove(string key)
	{
		Remove(key, null);
	}

	[return: NotNullIfNotNull("defaultValue")]
	public static string? Get(string key, string? defaultValue)
	{
		return Get(key, defaultValue, null);
	}

	public static bool Get(string key, bool defaultValue)
	{
		return Get(key, defaultValue, null);
	}

	public static int Get(string key, int defaultValue)
	{
		return Get(key, defaultValue, null);
	}

	public static void Set(string key, string? value)
	{
		Set(key, value, null);
	}

	public static void Set(string key, bool value)
	{
		Set(key, value, null);
	}

	public static void Set(string key, int value)
	{
		Set(key, value, null);
	}

	public static void Remove(string key, string? sharedName)
	{
		Current.Remove(key, sharedName);
	}

	public static void Clear(string? sharedName)
	{
		Current.Clear(sharedName);
	}

	[return: NotNullIfNotNull("defaultValue")]
	public static string? Get(string key, string? defaultValue, string? sharedName)
	{
		return Current.Get(key, defaultValue, sharedName);
	}

	public static bool Get(string key, bool defaultValue, string? sharedName)
	{
		return Current.Get(key, defaultValue, sharedName);
	}

	public static int Get(string key, int defaultValue, string? sharedName)
	{
		return Current.Get(key, defaultValue, sharedName);
	}

	public static long Get(string key, long defaultValue, string? sharedName)
	{
		return Current.Get(key, defaultValue, sharedName);
	}

	public static void Set(string key, string? value, string? sharedName)
	{
		Current.Set(key, value, sharedName);
	}

	public static void Set(string key, bool value, string? sharedName)
	{
		Current.Set(key, value, sharedName);
	}

	public static void Set(string key, int value, string? sharedName)
	{
		Current.Set(key, value, sharedName);
	}

	public static void Set(string key, long value, string? sharedName)
	{
		Current.Set(key, value, sharedName);
	}

	public static DateTime Get(string key, DateTime defaultValue)
	{
		return Get(key, defaultValue, null);
	}

	public static void Set(string key, DateTime value)
	{
		Set(key, value, null);
	}

	public static DateTime Get(string key, DateTime defaultValue, string? sharedName)
	{
		return Current.Get(key, defaultValue, sharedName);
	}

	public static void Set(string key, DateTime value, string? sharedName)
	{
		Current.Set(key, value, sharedName);
	}

	internal static void CheckIsSupportedType<T>()
	{
		Type typeFromHandle = typeof(T);
		if (!SupportedTypes.Contains(typeFromHandle))
		{
			throw new NotSupportedException($"Preferences using '{typeFromHandle}' type is not supported");
		}
	}
}
