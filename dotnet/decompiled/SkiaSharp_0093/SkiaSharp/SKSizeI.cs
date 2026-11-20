using System;

namespace SkiaSharp;

public struct SKSizeI : IEquatable<SKSizeI>
{
	private int w;

	private int h;

	public readonly int Width => w;

	public readonly int Height => h;

	public SKSizeI(int width, int height)
	{
		w = width;
		h = height;
	}

	public override readonly string ToString()
	{
		return $"{{Width={w}, Height={h}}}";
	}

	public static SKSizeI operator +(SKSizeI sz1, SKSizeI sz2)
	{
		return new SKSizeI(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
	}

	public static SKSizeI operator -(SKSizeI sz1, SKSizeI sz2)
	{
		return new SKSizeI(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
	}

	public readonly bool Equals(SKSizeI obj)
	{
		if (w == obj.w)
		{
			return h == obj.h;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKSizeI obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKSizeI left, SKSizeI right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKSizeI left, SKSizeI right)
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
