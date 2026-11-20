using System;

namespace SkiaSharp;

public struct SKSize : IEquatable<SKSize>
{
	public static readonly SKSize Empty;

	private float w;

	private float h;

	public readonly float Width => w;

	public readonly float Height => h;

	public SKSize(float width, float height)
	{
		w = width;
		h = height;
	}

	public override readonly string ToString()
	{
		return $"{{Width={w}, Height={h}}}";
	}

	public static SKSize operator +(SKSize sz1, SKSize sz2)
	{
		return new SKSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
	}

	public static SKSize operator -(SKSize sz1, SKSize sz2)
	{
		return new SKSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
	}

	public static explicit operator SKPoint(SKSize size)
	{
		return new SKPoint(size.Width, size.Height);
	}

	public static implicit operator SKSize(SKSizeI size)
	{
		return new SKSize(size.Width, size.Height);
	}

	public readonly bool Equals(SKSize obj)
	{
		if (w == obj.w)
		{
			return h == obj.h;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKSize obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKSize left, SKSize right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKSize left, SKSize right)
	{
		return !left.Equals(right);
	}

	public override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(w);
		hashCode.Add(h);
		return hashCode.ToHashCode();
	}
}
