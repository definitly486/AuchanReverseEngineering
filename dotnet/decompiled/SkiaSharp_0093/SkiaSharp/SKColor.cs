using System;

namespace SkiaSharp;

public readonly struct SKColor : IEquatable<SKColor>
{
	private readonly uint color;

	public byte Alpha => (byte)((color >> 24) & 0xFF);

	public byte Red => (byte)((color >> 16) & 0xFF);

	public byte Green => (byte)((color >> 8) & 0xFF);

	public byte Blue => (byte)(color & 0xFF);

	public SKColor(uint value)
	{
		color = value;
	}

	public override string ToString()
	{
		return $"#{Alpha:x2}{Red:x2}{Green:x2}{Blue:x2}";
	}

	public bool Equals(SKColor obj)
	{
		return obj.color == color;
	}

	public override bool Equals(object other)
	{
		if (other is SKColor obj)
		{
			return Equals(obj);
		}
		return false;
	}

	public static bool operator ==(SKColor left, SKColor right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKColor left, SKColor right)
	{
		return !left.Equals(right);
	}

	public override int GetHashCode()
	{
		return color.GetHashCode();
	}

	public static implicit operator SKColor(uint color)
	{
		return new SKColor(color);
	}

	public static explicit operator uint(SKColor color)
	{
		return color.color;
	}
}
