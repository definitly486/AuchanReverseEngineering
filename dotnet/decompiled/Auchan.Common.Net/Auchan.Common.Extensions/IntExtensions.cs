using System;
using System.Linq;

namespace Auchan.Common.Extensions;

public static class IntExtensions
{
	public static string ToProductsCount(this int count)
	{
		string text = $"{count} товар";
		int num = int.Parse(count.ToString().Last().ToString());
		if (num >= 2 && num <= 4)
		{
			text += "а";
		}
		else if ((count >= 10 && count <= 20) || (num >= 5 && num <= 9) || num == 0)
		{
			text += "ов";
		}
		return text;
	}

	public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
	{
		if (val.CompareTo(min) < 0)
		{
			return min;
		}
		if (val.CompareTo(max) > 0)
		{
			return max;
		}
		return val;
	}
}
