using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Drawing;

[Serializable]
[TypeForwardedFrom("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[TypeConverter("System.Drawing.RectangleConverter, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public struct Rectangle : IEquatable<Rectangle>
{
	private int x;

	private int y;

	private int width;

	private int height;

	public readonly int X => x;

	public readonly int Y => y;

	public readonly int Width => width;

	public readonly int Height => height;

	public Rectangle(int x, int y, int width, int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}

	public Rectangle(Point location, Size size)
	{
		x = location.X;
		y = location.Y;
		width = size.Width;
		height = size.Height;
	}

	public override readonly bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is Rectangle)
		{
			return Equals((Rectangle)obj);
		}
		return false;
	}

	public readonly bool Equals(Rectangle other)
	{
		return this == other;
	}

	public static bool operator ==(Rectangle left, Rectangle right)
	{
		if (left.X == right.X && left.Y == right.Y && left.Width == right.Width)
		{
			return left.Height == right.Height;
		}
		return false;
	}

	public static bool operator !=(Rectangle left, Rectangle right)
	{
		return !(left == right);
	}

	public override readonly int GetHashCode()
	{
		return HashCode.Combine(X, Y, Width, Height);
	}

	public override readonly string ToString()
	{
		return $"{{X={X},Y={Y},Width={Width},Height={Height}}}";
	}
}
