using System;
using System.Drawing;

namespace Splat;

public static class SizeMathExtensions
{
	public static bool WithinEpsilonOf(this SizeF value, SizeF other, float epsilon)
	{
		float num = other.Width - value.Width;
		float num2 = other.Height - value.Height;
		return Math.Sqrt(num * num + num2 * num2) < (double)epsilon;
	}

	public static SizeF ScaledBy(this SizeF value, float factor)
	{
		return new SizeF(value.Width * factor, value.Height * factor);
	}
}
