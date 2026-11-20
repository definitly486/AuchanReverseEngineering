using System;
using System.Linq;
using NLog.Internal;

namespace NLog;

[Obsolete("Replaced by ScopeContext.PushNestedState or Logger.PushScopeNested using ${scopenested}. Marked obsolete on NLog 5.0")]
public static class NestedDiagnosticsContext
{
	[Obsolete("Replaced by ScopeContext.PeekNestedState. Marked obsolete on NLog 5.0")]
	public static string TopMessage => FormatHelper.ConvertToString(TopObject, null);

	[Obsolete("Replaced by ScopeContext.PeekNestedState. Marked obsolete on NLog 5.0")]
	public static object? TopObject => PeekObject();

	[Obsolete("Replaced by ScopeContext.PushNestedState or Logger.PushScopeNested using ${scopenested}. Marked obsolete on NLog 5.0")]
	public static IDisposable Push(string text)
	{
		return ScopeContext.PushNestedState(text);
	}

	[Obsolete("Replaced by ScopeContext.PushNestedState or Logger.PushScopeNested using ${scopenested}. Marked obsolete on NLog 5.0")]
	public static IDisposable Push(object value)
	{
		return ScopeContext.PushNestedState(value);
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushNestedState or Logger.PushScopeNested. Marked obsolete on NLog 5.0")]
	public static string Pop()
	{
		return Pop(null);
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushNestedState or Logger.PushScopeNested. Marked obsolete on NLog 5.0")]
	public static string Pop(IFormatProvider? formatProvider)
	{
		return FormatHelper.ConvertToString(PopObject() ?? string.Empty, formatProvider);
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushNestedState or Logger.PushScopeNested. Marked obsolete on NLog 5.0")]
	public static object? PopObject()
	{
		return ScopeContext.PopNestedContextLegacy();
	}

	[Obsolete("Replaced by ScopeContext.PeekNestedState. Marked obsolete on NLog 5.0")]
	public static object? PeekObject()
	{
		return ScopeContext.PeekNestedState();
	}

	[Obsolete("Replaced by ScopeContext.Clear. Marked obsolete on NLog 5.0")]
	public static void Clear()
	{
		ScopeContext.ClearNestedContextLegacy();
	}

	[Obsolete("Replaced by ScopeContext.GetAllNestedStates. Marked obsolete on NLog 5.0")]
	public static string[] GetAllMessages()
	{
		return GetAllMessages(null);
	}

	[Obsolete("Replaced by ScopeContext.GetAllNestedStates. Marked obsolete on NLog 5.0")]
	public static string[] GetAllMessages(IFormatProvider? formatProvider)
	{
		object[] allObjects = GetAllObjects();
		if (allObjects.Length == 0)
		{
			return ArrayHelper.Empty<string>();
		}
		return allObjects.Select((object o) => FormatHelper.ConvertToString(o, formatProvider)).ToArray();
	}

	[Obsolete("Replaced by ScopeContext.GetAllNestedStates. Marked obsolete on NLog 5.0")]
	public static object[] GetAllObjects()
	{
		return ScopeContext.GetAllNestedStates();
	}
}
