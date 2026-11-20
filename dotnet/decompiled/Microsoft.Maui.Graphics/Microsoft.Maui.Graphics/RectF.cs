using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Android.Graphics;
using Microsoft.Maui.Graphics.Converters;

namespace Microsoft.Maui.Graphics;

[DebuggerDisplay("X={X}, Y={Y}, Width={Width}, Height={Height}")]
[TypeConverter(typeof(RectFTypeConverter))]
public struct RectF
{
	public float X { get; set; }

	public float Y { get; set; }

	public float Width { get; set; }

	public float Height { get; set; }

	public static implicit operator global::Android.Graphics.Rect(RectF rect)
	{
		return new global::Android.Graphics.Rect((int)rect.X, (int)rect.Y, (int)(rect.X + rect.Width), (int)(rect.Y + rect.Height));
	}

	public static implicit operator global::Android.Graphics.RectF(RectF rect)
	{
		return new global::Android.Graphics.RectF(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
	}

	public override string ToString()
	{
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = X.ToString(CultureInfo.InvariantCulture);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = Y.ToString(CultureInfo.InvariantCulture);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = Width.ToString(CultureInfo.InvariantCulture);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = Height.ToString(CultureInfo.InvariantCulture);
		return string.Format("{{X={0} Y={1} Width={2} Height={3}}}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	public RectF(float x, float y, float width, float height)
	{
		this = default(RectF);
		X = x;
		Y = y;
		Width = width;
		Height = height;
	}

	public bool Equals(RectF other)
	{
		if (X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width))
		{
			return Height.Equals(other.Height);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is RectF)
		{
			return Equals((RectF)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = X.GetHashCode();
		hashCode = (hashCode * 397) ^ Y.GetHashCode();
		hashCode = (hashCode * 397) ^ Width.GetHashCode();
		return (hashCode * 397) ^ Height.GetHashCode();
	}

	public static bool operator ==(RectF r1, RectF r2)
	{
		return r1.Equals(r2);
	}

	public static bool operator !=(RectF r1, RectF r2)
	{
		return !(r1 == r2);
	}

	public static implicit operator Rect(RectF rect)
	{
		return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
	}

	public static bool TryParse(string value, out RectF rectangleF)
	{
		if (!string.IsNullOrEmpty(value))
		{
			string[] array = value.Split(',');
			if (array.Length == 4 && float.TryParse(array[0], NumberStyles.Number, CultureInfo.InvariantCulture, out var result) && float.TryParse(array[1], NumberStyles.Number, CultureInfo.InvariantCulture, out var result2) && float.TryParse(array[2], NumberStyles.Number, CultureInfo.InvariantCulture, out var result3) && float.TryParse(array[3], NumberStyles.Number, CultureInfo.InvariantCulture, out var result4))
			{
				rectangleF = new RectF(result, result2, result3, result4);
				return true;
			}
		}
		rectangleF = default(RectF);
		return false;
	}
}
