using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Drawing;

[Serializable]
[TypeForwardedFrom("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[TypeConverter("System.Drawing.SizeConverter, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public struct Size : IEquatable<Size>
{
	private int width;

	private int height;

	public readonly int Width => width;

	public int Height
	{
		readonly get
		{
			return height;
		}
		set
		{
			height = value;
		}
	}

	public Size(Point pt)
	{
		width = pt.X;
		height = pt.Y;
	}

	public Size(int width, int height)
	{
		this.width = width;
		this.height = height;
	}

	public static implicit operator SizeF(Size p)
	{
		return new SizeF(p.Width, p.Height);
	}

	public static Size operator +(Size sz1, Size sz2)
	{
		return Add(sz1, sz2);
	}

	public static Size operator -(Size sz1, Size sz2)
	{
		return Subtract(sz1, sz2);
	}

	public static Size operator *(int left, Size right)
	{
		return Multiply(right, left);
	}

	public static Size operator *(Size left, int right)
	{
		return Multiply(left, right);
	}

	public static Size operator /(Size left, int right)
	{
		return new Size(left.width / right, left.height / right);
	}

	public static SizeF operator *(float left, Size right)
	{
		return Multiply(right, left);
	}

	public static SizeF operator *(Size left, float right)
	{
		return Multiply(left, right);
	}

	public static SizeF operator /(Size left, float right)
	{
		return new SizeF((float)left.width / right, (float)left.height / right);
	}

	public static bool operator ==(Size sz1, Size sz2)
	{
		if (sz1.Width == sz2.Width)
		{
			return sz1.Height == sz2.Height;
		}
		return false;
	}

	public static bool operator !=(Size sz1, Size sz2)
	{
		return !(sz1 == sz2);
	}

	public static explicit operator Point(Size size)
	{
		return new Point(size.Width, size.Height);
	}

	public static Size Add(Size sz1, Size sz2)
	{
		return new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
	}

	public static Size Subtract(Size sz1, Size sz2)
	{
		return new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
	}

	public override readonly bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is Size)
		{
			return Equals((Size)obj);
		}
		return false;
	}

	public readonly bool Equals(Size other)
	{
		return this == other;
	}

	public override readonly int GetHashCode()
	{
		return HashCode.Combine(Width, Height);
	}

	public override readonly string ToString()
	{
		return $"{{Width={width}, Height={height}}}";
	}

	private static Size Multiply(Size size, int multiplier)
	{
		return new Size(size.width * multiplier, size.height * multiplier);
	}

	private static SizeF Multiply(Size size, float multiplier)
	{
		return new SizeF((float)size.width * multiplier, (float)size.height * multiplier);
	}
}
