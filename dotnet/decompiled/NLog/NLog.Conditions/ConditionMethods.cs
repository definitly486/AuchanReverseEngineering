using System;

namespace NLog.Conditions;

[ConditionMethods]
public static class ConditionMethods
{
	[ConditionMethod("equals")]
	public static bool Equals2(object? firstValue, object? secondValue)
	{
		if (firstValue != secondValue)
		{
			return firstValue?.Equals(secondValue) ?? false;
		}
		return true;
	}

	[ConditionMethod("strequals")]
	public static bool Equals2(string? firstValue, string? secondValue, bool ignoreCase = false)
	{
		return string.Equals(firstValue, secondValue, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
	}

	[ConditionMethod("contains")]
	public static bool Contains(string? haystack, string? needle, bool ignoreCase = true)
	{
		if (haystack == null)
		{
			return false;
		}
		return haystack.IndexOf(needle, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0;
	}

	[ConditionMethod("starts-with")]
	public static bool StartsWith(string? haystack, string? needle, bool ignoreCase = true)
	{
		return haystack?.StartsWith(needle, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) ?? false;
	}

	[ConditionMethod("ends-with")]
	public static bool EndsWith(string? haystack, string? needle, bool ignoreCase = true)
	{
		return haystack?.EndsWith(needle, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) ?? false;
	}

	[ConditionMethod("length")]
	public static int Length(string? text)
	{
		return text?.Length ?? 0;
	}
}
