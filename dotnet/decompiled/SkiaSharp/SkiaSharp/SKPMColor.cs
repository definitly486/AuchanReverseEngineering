using System;

namespace SkiaSharp;

public readonly struct SKPMColor : IEquatable<SKPMColor>
{
	private readonly uint color;

	public byte Alpha => (byte)((color >> SKImageInfo.PlatformColorAlphaShift) & 0xFF);

	public byte Red => (byte)((color >> SKImageInfo.PlatformColorRedShift) & 0xFF);

	public byte Green => (byte)((color >> SKImageInfo.PlatformColorGreenShift) & 0xFF);

	public byte Blue => (byte)((color >> SKImageInfo.PlatformColorBlueShift) & 0xFF);

	public SKPMColor(uint value)
	{
		color = value;
	}

	public static SKPMColor PreMultiply(SKColor color)
	{
		return SkiaApi.sk_color_premultiply((uint)color);
	}

	public static SKColor UnPreMultiply(SKPMColor pmcolor)
	{
		return SkiaApi.sk_color_unpremultiply((uint)pmcolor);
	}

	public static explicit operator SKPMColor(SKColor color)
	{
		return PreMultiply(color);
	}

	public static explicit operator SKColor(SKPMColor color)
	{
		return UnPreMultiply(color);
	}

	public override string ToString()
	{
		return $"#{Alpha:x2}{Red:x2}{Green:x2}{Blue:x2}";
	}

	public bool Equals(SKPMColor obj)
	{
		return obj.color == color;
	}

	public override bool Equals(object other)
	{
		if (other is SKPMColor obj)
		{
			return Equals(obj);
		}
		return false;
	}

	public static bool operator ==(SKPMColor left, SKPMColor right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKPMColor left, SKPMColor right)
	{
		return !left.Equals(right);
	}

	public override int GetHashCode()
	{
		return color.GetHashCode();
	}

	public static implicit operator SKPMColor(uint color)
	{
		return new SKPMColor(color);
	}

	public static explicit operator uint(SKPMColor color)
	{
		return color.color;
	}
}
