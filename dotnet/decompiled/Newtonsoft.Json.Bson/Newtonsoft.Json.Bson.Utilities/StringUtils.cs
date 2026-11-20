using System;

namespace Newtonsoft.Json.Bson.Utilities;

internal static class StringUtils
{
	public static string FormatWith(this string format, IFormatProvider provider, object arg0)
	{
		return format.FormatWith(provider, new object[1] { arg0 });
	}

	public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1)
	{
		return format.FormatWith(provider, new object[2] { arg0, arg1 });
	}

	private static string FormatWith(this string format, IFormatProvider provider, params object[] args)
	{
		ValidationUtils.ArgumentNotNull(format, "format");
		return string.Format(provider, format, args);
	}

	public static bool EndsWith(this string source, char value)
	{
		if (source.Length > 0)
		{
			return source[source.Length - 1] == value;
		}
		return false;
	}
}
