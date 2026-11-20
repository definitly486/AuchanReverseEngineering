using System;
using Java.Interop;

namespace Android.Graphics;

[JniValueMarshaler(typeof(ColorValueMarshaler))]
public struct Color
{
	private int color;

	public byte A => (byte)(color >> 24);

	public byte B => (byte)color;

	public byte G => (byte)(color >> 8);

	public byte R => (byte)(color >> 16);

	public static Color Transparent => new Color(0);

	public static Color Black => new Color(4278190080u);

	public static Color Gray => new Color(4287137928u);

	public static Color Red => new Color(4294901760u);

	public static Color White => new Color(uint.MaxValue);

	public static Color Yellow => new Color(4294967040u);

	public Color(int argb)
	{
		color = argb;
	}

	private Color(uint argb)
	{
		color = (int)argb;
	}

	public Color(byte r, byte g, byte b)
	{
		color = FromRgb(r, g, b);
	}

	public Color(int r, int g, int b)
	{
		color = FromRgb(r, g, b);
	}

	public Color(byte r, byte g, byte b, byte a)
	{
		color = FromArgb(r, g, b, a);
	}

	public Color(int r, int g, int b, int a)
	{
		color = FromArgb(r, g, b, a);
	}

	public int ToArgb()
	{
		return color;
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"Color [A={A}, R={R}, G={G}, B={B}]");
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Color color))
		{
			return false;
		}
		return this == color;
	}

	public static Color Argb(int alpha, int red, int green, int blue)
	{
		return new Color((alpha << 24) | (red << 16) | (green << 8) | blue);
	}

	public static Color Rgb(int red, int green, int blue)
	{
		return new Color(-16777216 | (red << 16) | (green << 8) | blue);
	}

	public static bool operator ==(Color left, Color right)
	{
		return left.color == right.color;
	}

	public static bool operator !=(Color left, Color right)
	{
		return !(left == right);
	}

	public static implicit operator int(Color c)
	{
		return c.color;
	}

	public override int GetHashCode()
	{
		return color;
	}

	private static int FromRgb(int red, int green, int blue)
	{
		CheckARGBValues(255, red, green, blue);
		return (255 << 24) + (red << 16) + (green << 8) + blue;
	}

	private static int FromArgb(int red, int green, int blue, int alpha)
	{
		CheckARGBValues(alpha, red, green, blue);
		return (alpha << 24) + (red << 16) + (green << 8) + blue;
	}

	private static void CheckARGBValues(int alpha, int red, int green, int blue)
	{
		if (alpha > 255 || alpha < 0)
		{
			throw CreateColorArgumentException(alpha, "alpha");
		}
		CheckRGBValues(red, green, blue);
	}

	private static void CheckRGBValues(int red, int green, int blue)
	{
		if (red > 255 || red < 0)
		{
			throw CreateColorArgumentException(red, "red");
		}
		if (green > 255 || green < 0)
		{
			throw CreateColorArgumentException(green, "green");
		}
		if (blue > 255 || blue < 0)
		{
			throw CreateColorArgumentException(blue, "blue");
		}
	}

	private static ArgumentException CreateColorArgumentException(int value, string color)
	{
		return new ArgumentException(FormattableString.Invariant($"'{value}' is not a valid  value for '{color}'. '{color}' should be greater or equal to 0 and less than or equal to 255."));
	}

	public static Color ParseColor(string colorString)
	{
		return new Color(ColorObject.ParseColor(colorString));
	}
}
