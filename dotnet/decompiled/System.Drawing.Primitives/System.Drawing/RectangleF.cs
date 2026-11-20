using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.Drawing;

[Serializable]
[TypeForwardedFrom("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public struct RectangleF : IEquatable<RectangleF>
{
	private float x;

	private float y;

	private float width;

	private float height;

	[Browsable(false)]
	public readonly PointF Location => new PointF(X, Y);

	[Browsable(false)]
	public readonly SizeF Size => new SizeF(Width, Height);

	public float X
	{
		readonly get
		{
			return x;
		}
		set
		{
			x = value;
		}
	}

	public float Y
	{
		readonly get
		{
			return y;
		}
		set
		{
			y = value;
		}
	}

	public float Width
	{
		readonly get
		{
			return width;
		}
		set
		{
			width = value;
		}
	}

	public float Height
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

	[Browsable(false)]
	public readonly float Left => X;

	[Browsable(false)]
	public readonly float Top => Y;

	[Browsable(false)]
	public readonly float Right => X + Width;

	[Browsable(false)]
	public readonly float Bottom => Y + Height;

	public RectangleF(float x, float y, float width, float height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}

	public RectangleF(PointF location, SizeF size)
	{
		x = location.X;
		y = location.Y;
		width = size.Width;
		height = size.Height;
	}

	public RectangleF(Vector4 vector)
	{
		x = vector.X;
		y = vector.Y;
		width = vector.Z;
		height = vector.W;
	}

	public Vector4 ToVector4()
	{
		return new Vector4(x, y, width, height);
	}

	public static explicit operator Vector4(RectangleF rectangle)
	{
		return rectangle.ToVector4();
	}

	public static explicit operator RectangleF(Vector4 vector)
	{
		return new RectangleF(vector);
	}

	public override readonly bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is RectangleF)
		{
			return Equals((RectangleF)obj);
		}
		return false;
	}

	public readonly bool Equals(RectangleF other)
	{
		return this == other;
	}

	public static bool operator ==(RectangleF left, RectangleF right)
	{
		if (left.X == right.X && left.Y == right.Y && left.Width == right.Width)
		{
			return left.Height == right.Height;
		}
		return false;
	}

	public static bool operator !=(RectangleF left, RectangleF right)
	{
		return !(left == right);
	}

	public override readonly int GetHashCode()
	{
		return HashCode.Combine(X, Y, Width, Height);
	}

	public static implicit operator RectangleF(Rectangle r)
	{
		return new RectangleF(r.X, r.Y, r.Width, r.Height);
	}

	public override readonly string ToString()
	{
		return $"{{X={X},Y={Y},Width={Width},Height={Height}}}";
	}
}
