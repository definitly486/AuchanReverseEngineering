using System;
using System.Drawing;

namespace Splat;

public static class RectangleMathExtensions
{
	public static PointF Center(this RectangleF value)
	{
		return new PointF(value.X + value.Width / 2f, value.Y + value.Height / 2f);
	}

	public static Tuple<RectangleF, RectangleF> Divide(this RectangleF value, float amount, RectEdge fromEdge)
	{
		switch (fromEdge)
		{
		case RectEdge.Left:
		{
			float num = Math.Max(value.Width, amount);
			RectangleF value8 = value;
			float? height = num;
			RectangleF item4 = value8.Copy(null, null, height);
			RectangleF value9 = value;
			float? x2 = value.Left + num;
			height = value.Width - num;
			return Tuple.Create(item4, value9.Copy(x2, null, height));
		}
		case RectEdge.Top:
		{
			float num = Math.Max(value.Height, amount);
			RectangleF value6 = value;
			float? height = amount;
			RectangleF item3 = value6.Copy(null, null, null, height);
			RectangleF value7 = value;
			height = value.Top + num;
			float? y = value.Height - num;
			return Tuple.Create(item3, value7.Copy(null, height, null, y));
		}
		case RectEdge.Right:
		{
			float num = Math.Max(value.Width, amount);
			RectangleF value4 = value;
			float? x = value.Right - num;
			float? y = num;
			RectangleF item2 = value4.Copy(x, null, y);
			RectangleF value5 = value;
			y = value.Width - num;
			return Tuple.Create(item2, value5.Copy(null, null, y));
		}
		case RectEdge.Bottom:
		{
			float num = Math.Max(value.Height, amount);
			RectangleF value2 = value;
			float? y = value.Bottom - num;
			float? height = num;
			RectangleF item = value2.Copy(null, y, null, height);
			RectangleF value3 = value;
			height = value.Height - num;
			return Tuple.Create(item, value3.Copy(null, null, null, height));
		}
		default:
			throw new ArgumentException("edge");
		}
	}

	public static Tuple<RectangleF, RectangleF> DivideWithPadding(this RectangleF value, float sliceAmount, float padding, RectEdge fromEdge)
	{
		Tuple<RectangleF, RectangleF> tuple = value.Divide(sliceAmount, fromEdge);
		return Tuple.Create(item2: value.Divide(padding, fromEdge).Item2, item1: tuple.Item1);
	}

	public static RectangleF InvertWithin(this RectangleF value, RectangleF containingRect)
	{
		RectangleF result = value;
		result.Y = containingRect.Height - value.Bottom;
		return result;
	}

	public static RectangleF Copy(this RectangleF value, float? x = null, float? y = null, float? width = null, float? height = null, float? top = null, float? bottom = null)
	{
		RectangleF result = new RectangleF(value.Location, value.Size);
		if (x.HasValue)
		{
			result.X = x.Value;
		}
		if (y.HasValue)
		{
			result.Y = y.Value;
		}
		if (width.HasValue)
		{
			result.Width = width.Value;
		}
		if (height.HasValue)
		{
			result.Height = height.Value;
		}
		if (top.HasValue)
		{
			if (y.HasValue)
			{
				throw new ArgumentException("Conflicting Copy arguments Y and Top");
			}
			result.Y = top.Value;
		}
		if (bottom.HasValue)
		{
			if (height.HasValue)
			{
				throw new ArgumentException("Conflicting Copy arguments Height and Bottom");
			}
			result.Height = result.Y + bottom.Value;
		}
		return result;
	}
}
