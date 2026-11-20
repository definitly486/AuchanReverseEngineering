using System;
using System.Numerics;

namespace SkiaSharp;

public struct SKPoint : IEquatable<SKPoint>
{
	private float x;

	private float y;

	public readonly float X => x;

	public readonly float Y => y;

	public SKPoint(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public override readonly string ToString()
	{
		return $"{{X={x}, Y={y}}}";
	}

	public static SKPoint operator +(SKPoint pt, SKSizeI sz)
	{
		return new SKPoint(pt.x + (float)sz.Width, pt.y + (float)sz.Height);
	}

	public static SKPoint operator +(SKPoint pt, SKSize sz)
	{
		return new SKPoint(pt.x + sz.Width, pt.y + sz.Height);
	}

	public static SKPoint operator +(SKPoint pt, SKPoint sz)
	{
		return new SKPoint(pt.x + sz.X, pt.y + sz.Y);
	}

	public static SKPoint operator -(SKPoint pt, SKSizeI sz)
	{
		return new SKPoint(pt.X - (float)sz.Width, pt.Y - (float)sz.Height);
	}

	public static SKPoint operator -(SKPoint pt, SKSize sz)
	{
		return new SKPoint(pt.X - sz.Width, pt.Y - sz.Height);
	}

	public static SKPoint operator -(SKPoint pt, SKPoint sz)
	{
		return new SKPoint(pt.X - sz.X, pt.Y - sz.Y);
	}

	public static implicit operator Vector2(SKPoint point)
	{
		return new Vector2(point.x, point.y);
	}

	public static implicit operator SKPoint(Vector2 vector)
	{
		return new SKPoint(vector.X, vector.Y);
	}

	public readonly bool Equals(SKPoint obj)
	{
		if (x == obj.x)
		{
			return y == obj.y;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKPoint obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKPoint left, SKPoint right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKPoint left, SKPoint right)
	{
		return !left.Equals(right);
	}

	public override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(x);
		hashCode.Add(y);
		return hashCode.ToHashCode();
	}
}
