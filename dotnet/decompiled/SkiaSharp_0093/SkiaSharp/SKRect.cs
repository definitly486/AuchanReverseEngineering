using System;

namespace SkiaSharp;

public struct SKRect : IEquatable<SKRect>
{
	private float left;

	private float top;

	private float right;

	private float bottom;

	public readonly float Width => right - left;

	public readonly float Height => bottom - top;

	public readonly float Left => left;

	public readonly float Top => top;

	public SKRect(float left, float top, float right, float bottom)
	{
		this.left = left;
		this.right = right;
		this.top = top;
		this.bottom = bottom;
	}

	public override readonly string ToString()
	{
		return $"{{Left={Left},Top={Top},Width={Width},Height={Height}}}";
	}

	public static SKRect Create(SKPoint location, SKSize size)
	{
		return Create(location.X, location.Y, size.Width, size.Height);
	}

	public static SKRect Create(float x, float y, float width, float height)
	{
		return new SKRect(x, y, x + width, y + height);
	}

	public readonly bool Equals(SKRect obj)
	{
		if (left == obj.left && top == obj.top && right == obj.right)
		{
			return bottom == obj.bottom;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKRect obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKRect left, SKRect right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKRect left, SKRect right)
	{
		return !left.Equals(right);
	}

	public override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(left);
		hashCode.Add(top);
		hashCode.Add(right);
		hashCode.Add(bottom);
		return hashCode.ToHashCode();
	}
}
