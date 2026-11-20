using System;

namespace SkiaSharp;

public struct SKMatrix : IEquatable<SKMatrix>
{
	private float scaleX;

	private float skewX;

	private float transX;

	private float skewY;

	private float scaleY;

	private float transY;

	private float persp0;

	private float persp1;

	private float persp2;

	public readonly bool Equals(SKMatrix obj)
	{
		if (scaleX == obj.scaleX && skewX == obj.skewX && transX == obj.transX && skewY == obj.skewY && scaleY == obj.scaleY && transY == obj.transY && persp0 == obj.persp0 && persp1 == obj.persp1)
		{
			return persp2 == obj.persp2;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKMatrix obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKMatrix left, SKMatrix right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKMatrix left, SKMatrix right)
	{
		return !left.Equals(right);
	}

	public override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(scaleX);
		hashCode.Add(skewX);
		hashCode.Add(transX);
		hashCode.Add(skewY);
		hashCode.Add(scaleY);
		hashCode.Add(transY);
		hashCode.Add(persp0);
		hashCode.Add(persp1);
		hashCode.Add(persp2);
		return hashCode.ToHashCode();
	}
}
