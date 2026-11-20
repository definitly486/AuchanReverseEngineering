using System;
using System.Drawing;

namespace Splat;

public static class PointMathExtensions
{
	public static PointF Floor(this Point value)
	{
		return new PointF((float)Math.Floor((double)value.X), (float)Math.Ceiling((double)value.Y));
	}

	public static bool WithinEpsilonOf(this PointF value, PointF other, float epsilon)
	{
		return value.DistanceTo(other) < epsilon;
	}

	public static float DotProduct(this PointF value, PointF other)
	{
		return value.X * other.X + value.Y * other.Y;
	}

	public static PointF ScaledBy(this PointF value, float factor)
	{
		return new PointF(value.X * factor, value.Y * factor);
	}

	public static float Length(this PointF value)
	{
		return PointF.Empty.DistanceTo(value);
	}

	public static PointF Normalize(this PointF value)
	{
		if (value.Length() == 0f)
		{
			return value;
		}
		return new PointF(value.X / value.Length(), value.Y / value.Length());
	}

	public static float AngleInDegrees(this PointF value)
	{
		return (float)(Math.Atan2(value.Y, value.X) * 180.0 / Math.PI);
	}

	public static PointF ProjectAlong(this PointF value, PointF direction)
	{
		PointF pointF = direction.Normalize();
		float factor = value.DotProduct(pointF);
		return pointF.ScaledBy(factor);
	}

	public static PointF ProjectAlongAngle(this PointF value, float angleInDegrees)
	{
		double num = (double)angleInDegrees * Math.PI / 180.0;
		PointF direction = new PointF((float)Math.Cos(num), (float)Math.Sin(num));
		return value.ProjectAlong(direction);
	}

	public static float DistanceTo(this PointF value, PointF other)
	{
		float num = other.X - value.X;
		float num2 = other.Y - value.Y;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}
}
