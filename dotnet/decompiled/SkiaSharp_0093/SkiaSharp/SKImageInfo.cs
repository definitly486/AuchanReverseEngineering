using System;

namespace SkiaSharp;

public struct SKImageInfo : IEquatable<SKImageInfo>
{
	public static readonly SKColorType PlatformColorType;

	public static readonly int PlatformColorAlphaShift;

	public static readonly int PlatformColorRedShift;

	public static readonly int PlatformColorGreenShift;

	public static readonly int PlatformColorBlueShift;

	public int Width { get; set; }

	public int Height { get; set; }

	public SKColorType ColorType { get; set; }

	public SKAlphaType AlphaType { get; set; }

	public SKColorSpace ColorSpace { get; set; }

	public readonly int BytesPerPixel => ColorType.GetBytesPerPixel();

	public readonly int RowBytes => Width * BytesPerPixel;

	public readonly SKSizeI Size => new SKSizeI(Width, Height);

	unsafe static SKImageInfo()
	{
		PlatformColorType = SkiaApi.sk_colortype_get_default_8888().FromNative();
		fixed (int* platformColorAlphaShift = &PlatformColorAlphaShift)
		{
			fixed (int* platformColorRedShift = &PlatformColorRedShift)
			{
				fixed (int* platformColorGreenShift = &PlatformColorGreenShift)
				{
					fixed (int* platformColorBlueShift = &PlatformColorBlueShift)
					{
						SkiaApi.sk_color_get_bit_shift(platformColorAlphaShift, platformColorRedShift, platformColorGreenShift, platformColorBlueShift);
					}
				}
			}
		}
	}

	public SKImageInfo(int width, int height, SKColorType colorType)
	{
		Width = width;
		Height = height;
		ColorType = colorType;
		AlphaType = SKAlphaType.Premul;
		ColorSpace = null;
	}

	public SKImageInfo(int width, int height, SKColorType colorType, SKAlphaType alphaType)
	{
		Width = width;
		Height = height;
		ColorType = colorType;
		AlphaType = alphaType;
		ColorSpace = null;
	}

	public readonly SKImageInfo WithSize(SKSizeI size)
	{
		return WithSize(size.Width, size.Height);
	}

	public readonly SKImageInfo WithSize(int width, int height)
	{
		SKImageInfo result = this;
		result.Width = width;
		result.Height = height;
		return result;
	}

	public readonly bool Equals(SKImageInfo obj)
	{
		if (ColorSpace == obj.ColorSpace && Width == obj.Width && Height == obj.Height && ColorType == obj.ColorType)
		{
			return AlphaType == obj.AlphaType;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKImageInfo obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKImageInfo left, SKImageInfo right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKImageInfo left, SKImageInfo right)
	{
		return !left.Equals(right);
	}

	public override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(ColorSpace);
		hashCode.Add(Width);
		hashCode.Add(Height);
		hashCode.Add(ColorType);
		hashCode.Add(AlphaType);
		return hashCode.ToHashCode();
	}
}
