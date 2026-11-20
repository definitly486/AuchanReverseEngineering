using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Auchan.Common.Common;

namespace Auchan.Common.Extensions;

public static class ListExtensions
{
	public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IReadOnlyList<T>? list)
	{
		if (list != null)
		{
			return list.Count <= 0;
		}
		return true;
	}

	public static bool IsNotNullOrEmpty<T>([NotNullWhen(true)] this IReadOnlyList<T>? list)
	{
		if (list != null)
		{
			return list.Count > 0;
		}
		return false;
	}

	public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this List<T>? list)
	{
		if (list != null)
		{
			return list.Count <= 0;
		}
		return true;
	}

	public static bool IsNotNullOrEmptyCollection<T>([NotNullWhen(true)] this IReadOnlyCollection<T>? list)
	{
		if (list != null)
		{
			return list.Count > 0;
		}
		return false;
	}

	public static bool IsNotNullOrEmpty<T>([NotNullWhen(true)] this List<T>? list)
	{
		if (list != null)
		{
			return list.Count > 0;
		}
		return false;
	}

	public static int IndexOfIgnoreCase(this IList<string> @this, string str)
	{
		for (int i = 0; i < @this.Count; i++)
		{
			if (str.EqualsIgnoreCase(@this[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public static ReadOnlyEquatableList<T> ToReadOnlyEquatable<T>(this IReadOnlyList<T> values) where T : IEquatable<T>
	{
		if (values is ReadOnlyEquatableList<T> result)
		{
			return result;
		}
		return new ReadOnlyEquatableList<T>(values);
	}
}
