using System;
using System.Collections.Generic;
using NLog.Internal;

namespace NLog;

[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
public static class MappedDiagnosticsLogicalContext
{
	[Obsolete("Replaced by ScopeContext.TryGetProperty. Marked obsolete on NLog 5.0")]
	public static string Get(string item)
	{
		return Get(item, null);
	}

	[Obsolete("Replaced by ScopeContext.TryGetProperty. Marked obsolete on NLog 5.0")]
	public static string Get(string item, IFormatProvider? formatProvider)
	{
		return FormatHelper.ConvertToString(GetObject(item), formatProvider);
	}

	[Obsolete("Replaced by ScopeContext.TryGetProperty. Marked obsolete on NLog 5.0")]
	public static object? GetObject(string item)
	{
		Guard.ThrowIfNull(item, "item");
		if (ScopeContext.TryGetProperty(item, out object value))
		{
			return value;
		}
		return null;
	}

	[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static IDisposable SetScoped(string item, string? value)
	{
		Guard.ThrowIfNull(item, "item");
		return MappedDiagnosticsLogicalContext.SetScoped<string>(item, value);
	}

	[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static IDisposable SetScoped(string item, object? value)
	{
		Guard.ThrowIfNull(item, "item");
		return MappedDiagnosticsLogicalContext.SetScoped<object>(item, value);
	}

	[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static IDisposable SetScoped<T>(string item, T? value)
	{
		Guard.ThrowIfNull(item, "item");
		return ScopeContext.PushProperty(item, value);
	}

	[Obsolete("Replaced by ScopeContext.PushProperties or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static IDisposable SetScoped(IReadOnlyList<KeyValuePair<string, object?>> items)
	{
		return ScopeContext.PushProperties(items);
	}

	[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static void Set(string item, string? value)
	{
		MappedDiagnosticsLogicalContext.Set<string>(item, value);
	}

	[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static void Set(string item, object? value)
	{
		MappedDiagnosticsLogicalContext.Set<object>(item, value);
	}

	[Obsolete("Replaced by ScopeContext.PushProperty or Logger.PushScopeProperty using ${scopeproperty}. Marked obsolete on NLog 5.0")]
	public static void Set<T>(string item, T? value)
	{
		Guard.ThrowIfNull(item, "item");
		ScopeContext.SetMappedContextLegacy(item, value);
	}

	[Obsolete("Replaced by ScopeContext.GetAllProperties. Marked obsolete on NLog 5.0")]
	public static ICollection<string> GetNames()
	{
		return ScopeContext.GetKeysMappedContextLegacy();
	}

	[Obsolete("Replaced by ScopeContext.TryGetProperty. Marked obsolete on NLog 5.0")]
	public static bool Contains(string item)
	{
		Guard.ThrowIfNull(item, "item");
		object value;
		return ScopeContext.TryGetProperty(item, out value);
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushProperty. Marked obsolete on NLog 5.0")]
	public static void Remove(string item)
	{
		Guard.ThrowIfNull(item, "item");
		ScopeContext.RemoveMappedContextLegacy(item);
	}

	[Obsolete("Replaced by ScopeContext.Clear(). Marked obsolete on NLog 5.0")]
	public static void Clear()
	{
		Clear(free: true);
	}

	[Obsolete("Replaced by ScopeContext.Clear(). Marked obsolete on NLog 5.0")]
	public static void Clear(bool free)
	{
		ScopeContext.ClearMappedContextLegacy();
	}
}
