using System;

namespace SkiaSharp;

internal struct SKImageInfoNative : IEquatable<SKImageInfoNative>
{
	public nint colorspace;

	public int width;

	public int height;

	public SKColorTypeNative colorType;

	public SKAlphaType alphaType;

	public readonly bool Equals(SKImageInfoNative obj)
	{
		if (colorspace == obj.colorspace && width == obj.width && height == obj.height && colorType == obj.colorType)
		{
			return alphaType == obj.alphaType;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKImageInfoNative obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKImageInfoNative left, SKImageInfoNative right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKImageInfoNative left, SKImageInfoNative right)
	{
		return !left.Equals(right);
	}

	public override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(colorspace);
		hashCode.Add(width);
		hashCode.Add(height);
		hashCode.Add(colorType);
		hashCode.Add(alphaType);
		return hashCode.ToHashCode();
	}

	public static SKImageInfoNative FromManaged(ref SKImageInfo managed)
	{
		return new SKImageInfoNative
		{
			colorspace = (managed.ColorSpace?.Handle ?? IntPtr.Zero),
			width = managed.Width,
			height = managed.Height,
			colorType = managed.ColorType.ToNative(),
			alphaType = managed.AlphaType
		};
	}
}
