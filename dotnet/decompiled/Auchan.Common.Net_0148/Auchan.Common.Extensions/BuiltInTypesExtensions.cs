using System;
using System.Globalization;
using System.Text;

namespace Auchan.Common.Extensions;

public static class BuiltInTypesExtensions
{
	private const string Base36Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	private static IFormatProvider ENUSCultureInfo = CultureInfo.CreateSpecificCulture("en-US");

	public static bool? ToNullIfTrue(this bool value)
	{
		if (value)
		{
			return null;
		}
		return false;
	}

	public static float Clamp(this float value, float min, float max)
	{
		return Math.Min(Math.Max(value, min), max);
	}

	public static string ToBase36(this long value)
	{
		int num = 36;
		StringBuilder stringBuilder = new StringBuilder();
		while (value > 0)
		{
			stringBuilder.Insert(0, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"[(int)(value % num)]);
			value /= num;
		}
		return stringBuilder.ToString();
	}

	public static string ToPointsString(this decimal val, string format = "#####0.00", bool removeDecimals = true)
	{
		if (val % 1m > 0m)
		{
			return val.ToString(format);
		}
		if (removeDecimals)
		{
			format = format.SubstringSafe(0, format.IndexOf("."));
		}
		return val.ToString(format);
	}
}
