using System;
using System.Collections.Generic;
using NLog.Internal;

namespace NLog;

public static class GlobalDiagnosticsContext
{
	private static readonly object _lockObject = new object();

	private static Dictionary<string, object?> _dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

	private static Dictionary<string, object?>? _dictReadOnly;

	public static void Set(string item, string? value)
	{
		Set(item, (object?)value);
	}

	public static void Set(string item, object? value)
	{
		Guard.ThrowIfNull(item, "item");
		lock (_lockObject)
		{
			GetWritableDict()[item] = value;
		}
	}

	public static string Get(string item)
	{
		Guard.ThrowIfNull(item, "item");
		return Get(item, null);
	}

	public static string Get(string item, IFormatProvider? formatProvider)
	{
		Guard.ThrowIfNull(item, "item");
		return FormatHelper.ConvertToString(GetObject(item), formatProvider);
	}

	public static object? GetObject(string item)
	{
		Guard.ThrowIfNull(item, "item");
		GetReadOnlyDict().TryGetValue(item, out object value);
		return value;
	}

	public static ICollection<string> GetNames()
	{
		return GetReadOnlyDict().Keys;
	}

	public static bool Contains(string item)
	{
		Guard.ThrowIfNull(item, "item");
		return GetReadOnlyDict().ContainsKey(item);
	}

	public static void Remove(string item)
	{
		Guard.ThrowIfNull(item, "item");
		lock (_lockObject)
		{
			if (_dict.ContainsKey(item))
			{
				GetWritableDict().Remove(item);
			}
		}
	}

	public static void Clear()
	{
		lock (_lockObject)
		{
			if (_dict.Count != 0)
			{
				GetWritableDict(clearDictionary: true).Clear();
			}
		}
	}

	internal static Dictionary<string, object?> GetReadOnlyDict()
	{
		Dictionary<string, object> dictionary = _dictReadOnly;
		if (dictionary == null)
		{
			lock (_lockObject)
			{
				dictionary = (_dictReadOnly = _dict);
			}
		}
		return dictionary;
	}

	private static Dictionary<string, object?> GetWritableDict(bool clearDictionary = false)
	{
		if (_dictReadOnly != null)
		{
			_dict = CopyDictionaryOnWrite(clearDictionary);
			_dictReadOnly = null;
		}
		return _dict;
	}

	private static Dictionary<string, object?> CopyDictionaryOnWrite(bool clearDictionary)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>((!clearDictionary) ? (_dict.Count + 1) : 0, _dict.Comparer);
		if (!clearDictionary)
		{
			foreach (KeyValuePair<string, object> item in _dict)
			{
				dictionary[item.Key] = item.Value;
			}
		}
		return dictionary;
	}
}
