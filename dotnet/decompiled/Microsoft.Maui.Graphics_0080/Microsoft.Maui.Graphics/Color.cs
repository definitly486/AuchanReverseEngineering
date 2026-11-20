using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using Microsoft.Maui.Graphics.Converters;

namespace Microsoft.Maui.Graphics;

[DebuggerDisplay("Red={Red}, Green={Green}, Blue={Blue}, Alpha={Alpha}")]
[TypeConverter(typeof(ColorTypeConverter))]
public class Color
{
	public readonly float Red;

	public readonly float Green;

	public readonly float Blue;

	public readonly float Alpha = 1f;

	public Color(float red, float green, float blue)
	{
		Red = red.Clamp(0f, 1f);
		Green = green.Clamp(0f, 1f);
		Blue = blue.Clamp(0f, 1f);
	}

	public Color(float red, float green, float blue, float alpha)
	{
		Red = red.Clamp(0f, 1f);
		Green = green.Clamp(0f, 1f);
		Blue = blue.Clamp(0f, 1f);
		Alpha = alpha.Clamp(0f, 1f);
	}

	public Color(Vector4 color)
	{
		Red = color.X.Clamp(0f, 1f);
		Green = color.Y.Clamp(0f, 1f);
		Blue = color.Z.Clamp(0f, 1f);
		Alpha = color.W.Clamp(0f, 1f);
	}

	public override string ToString()
	{
		string value = Red.ToString(CultureInfo.InvariantCulture);
		string value2 = Green.ToString(CultureInfo.InvariantCulture);
		string value3 = Blue.ToString(CultureInfo.InvariantCulture);
		string value4 = Alpha.ToString(CultureInfo.InvariantCulture);
		return $"[Color: Red={value}, Green={value2}, Blue={value3}, Alpha={value4}]";
	}

	public override int GetHashCode()
	{
		int hashCode = Red.GetHashCode();
		hashCode = (hashCode * 397) ^ Green.GetHashCode();
		hashCode = (hashCode * 397) ^ Blue.GetHashCode();
		return (hashCode * 397) ^ Alpha.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Color color)
		{
			return ToInt() == color.ToInt();
		}
		return base.Equals(obj);
	}

	public string ToRgbaHex(bool includeAlpha = false)
	{
		if (includeAlpha || Alpha < 1f)
		{
			return "#" + ToHex(Red) + ToHex(Green) + ToHex(Blue) + ToHex(Alpha);
		}
		return "#" + ToHex(Red) + ToHex(Green) + ToHex(Blue);
	}

	private static string ToHex(float value)
	{
		string text = ((int)(255f * value)).ToString("X");
		if (text.Length == 1)
		{
			return "0" + text;
		}
		return text;
	}

	public int ToInt()
	{
		ToRgba(out var r, out var g, out var b, out var a);
		return (a << 24) | (r << 16) | (g << 8) | b;
	}

	public void ToRgba(out byte r, out byte g, out byte b, out byte a)
	{
		a = (byte)(Alpha * 255f);
		r = (byte)(Red * 255f);
		g = (byte)(Green * 255f);
		b = (byte)(Blue * 255f);
	}

	public static Color FromHsva(float h, float s, float v, float a)
	{
		h = h.Clamp(0f, 1f);
		s = s.Clamp(0f, 1f);
		v = v.Clamp(0f, 1f);
		int num = (int)Math.Floor(h * 6f) % 6;
		double num2 = (double)(h * 6f) - Math.Floor(h * 6f);
		float num3 = v * (1f - s);
		double num4 = (double)v * (1.0 - num2 * (double)s);
		double num5 = (double)v * (1.0 - (1.0 - num2) * (double)s);
		return num switch
		{
			0 => FromRgba(v, num5, num3, a), 
			1 => FromRgba(num4, v, num3, a), 
			2 => FromRgba(num3, v, num5, a), 
			3 => FromRgba(num3, num4, v, a), 
			4 => FromRgba(num5, num3, v, a), 
			_ => FromRgba(v, num3, num4, a), 
		};
	}

	public static Color FromUint(uint argb)
	{
		return FromRgba((byte)((argb & 0xFF0000) >> 16), (byte)((argb & 0xFF00) >> 8), (byte)(argb & 0xFF), (byte)((argb & 0xFF000000u) >> 24));
	}

	public static Color FromRgba(byte red, byte green, byte blue, byte alpha)
	{
		return new Color((float)(int)red / 255f, (float)(int)green / 255f, (float)(int)blue / 255f, (float)(int)alpha / 255f);
	}

	public static Color FromRgba(float r, float g, float b, float a)
	{
		return new Color(r, g, b, a);
	}

	public static Color FromRgba(double r, double g, double b, double a)
	{
		return new Color((float)r, (float)g, (float)b, (float)a);
	}

	private static Color FromArgb(ReadOnlySpan<char> colorAsHex)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 255;
		if (!colorAsHex.IsEmpty)
		{
			if (colorAsHex[0] == '#')
			{
				colorAsHex = colorAsHex.Slice(1);
			}
			if (colorAsHex.Length == 6)
			{
				num = ParseInt(colorAsHex.Slice(0, 2));
				num2 = ParseInt(colorAsHex.Slice(2, 2));
				num3 = ParseInt(colorAsHex.Slice(4, 2));
			}
			else if (colorAsHex.Length == 3)
			{
				Span<char> span = stackalloc char[2];
				span[0] = (span[1] = colorAsHex[0]);
				num = ParseInt(span);
				span[0] = (span[1] = colorAsHex[1]);
				num2 = ParseInt(span);
				span[0] = (span[1] = colorAsHex[2]);
				num3 = ParseInt(span);
			}
			else if (colorAsHex.Length == 4)
			{
				Span<char> span2 = stackalloc char[2];
				span2[0] = (span2[1] = colorAsHex[0]);
				num4 = ParseInt(span2);
				span2[0] = (span2[1] = colorAsHex[1]);
				num = ParseInt(span2);
				span2[0] = (span2[1] = colorAsHex[2]);
				num2 = ParseInt(span2);
				span2[0] = (span2[1] = colorAsHex[3]);
				num3 = ParseInt(span2);
			}
			else if (colorAsHex.Length == 8)
			{
				num4 = ParseInt(colorAsHex.Slice(0, 2));
				num = ParseInt(colorAsHex.Slice(2, 2));
				num2 = ParseInt(colorAsHex.Slice(4, 2));
				num3 = ParseInt(colorAsHex.Slice(6, 2));
			}
		}
		return FromRgba((float)num / 255f, (float)num2 / 255f, (float)num3 / 255f, (float)num4 / 255f);
	}

	public static Color FromHsla(double h, double s, double l, double a = 1.0)
	{
		ConvertToRgb((float)h, (float)s, (float)l, out var r, out var g, out var b);
		return new Color(r, g, b, (float)a);
	}

	public static Color FromHsv(float h, float s, float v)
	{
		return FromHsva(h, s, v, 1f);
	}

	private static void ConvertToRgb(float hue, float saturation, float luminosity, out float r, out float g, out float b)
	{
		if (luminosity == 0f)
		{
			r = (g = (b = 0f));
			return;
		}
		if (saturation == 0f)
		{
			r = (g = (b = luminosity));
			return;
		}
		float num = ((luminosity <= 0.5f) ? (luminosity * (1f + saturation)) : (luminosity + saturation - luminosity * saturation));
		float num2 = 2f * luminosity - num;
		float[] array = new float[3]
		{
			hue + 1f / 3f,
			hue,
			hue - 1f / 3f
		};
		float[] array2 = new float[3];
		for (int i = 0; i < 3; i++)
		{
			if (array[i] < 0f)
			{
				array[i] += 1f;
			}
			if (array[i] > 1f)
			{
				array[i] -= 1f;
			}
			if (6.0 * (double)array[i] < 1.0)
			{
				array2[i] = num2 + (num - num2) * array[i] * 6f;
			}
			else if (2.0 * (double)array[i] < 1.0)
			{
				array2[i] = num;
			}
			else if (3.0 * (double)array[i] < 2.0)
			{
				array2[i] = num2 + (num - num2) * (2f / 3f - array[i]) * 6f;
			}
			else
			{
				array2[i] = num2;
			}
		}
		r = array2[0];
		g = array2[1];
		b = array2[2];
	}

	public static Color Parse(string value)
	{
		if (TryParse(value, out var color) && color != null)
		{
			return color;
		}
		throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Color)}");
	}

	public static bool TryParse(string value, out Color color)
	{
		return TryParse(value?.AsSpan() ?? default(ReadOnlySpan<char>), out color);
	}

	private static bool TryParse(ReadOnlySpan<char> value, out Color color)
	{
		value = value.Trim();
		if (!value.IsEmpty)
		{
			if (value[0] == '#')
			{
				try
				{
					color = FromArgb(value);
					return true;
				}
				catch
				{
				}
			}
			else if (value.StartsWith("rgba".AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				if (TryParseFourColorRanges(value, out var quad, out var quad2, out var quad3, out var quad4))
				{
					bool flag = TryParseColorValue(quad, 255, acceptPercent: true, out var value2);
					flag &= TryParseColorValue(quad2, 255, acceptPercent: true, out var value3);
					flag &= TryParseColorValue(quad3, 255, acceptPercent: true, out var value4);
					if (flag & TryParseOpacity(quad4, out var value5))
					{
						color = new Color((float)value2, (float)value3, (float)value4, (float)value5);
						return true;
					}
				}
			}
			else if (value.StartsWith("rgb".AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				if (TryParseThreeColorRanges(value, out var triplet, out var triplet2, out var triplet3))
				{
					bool flag2 = TryParseColorValue(triplet, 255, acceptPercent: true, out var value6);
					flag2 &= TryParseColorValue(triplet2, 255, acceptPercent: true, out var value7);
					if (flag2 & TryParseColorValue(triplet3, 255, acceptPercent: true, out var value8))
					{
						color = new Color((float)value6, (float)value7, (float)value8);
						return true;
					}
				}
			}
			else if (value.StartsWith("hsla".AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				if (TryParseFourColorRanges(value, out var quad5, out var quad6, out var quad7, out var quad8))
				{
					bool flag3 = TryParseColorValue(quad5, 360, acceptPercent: false, out var value9);
					flag3 &= TryParseColorValue(quad6, 100, acceptPercent: true, out var value10);
					flag3 &= TryParseColorValue(quad7, 100, acceptPercent: true, out var value11);
					if (flag3 & TryParseOpacity(quad8, out var value12))
					{
						color = FromHsla(value9, value10, value11, value12);
						return true;
					}
				}
			}
			else if (value.StartsWith("hsl".AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				if (TryParseThreeColorRanges(value, out var triplet4, out var triplet5, out var triplet6))
				{
					bool flag4 = TryParseColorValue(triplet4, 360, acceptPercent: false, out var value13);
					flag4 &= TryParseColorValue(triplet5, 100, acceptPercent: true, out var value14);
					if (flag4 & TryParseColorValue(triplet6, 100, acceptPercent: true, out var value15))
					{
						color = FromHsla(value13, value14, value15);
						return true;
					}
				}
			}
			else if (value.StartsWith("hsva".AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				if (TryParseFourColorRanges(value, out var quad9, out var quad10, out var quad11, out var quad12))
				{
					bool flag5 = TryParseColorValue(quad9, 360, acceptPercent: false, out var value16);
					flag5 &= TryParseColorValue(quad10, 100, acceptPercent: true, out var value17);
					flag5 &= TryParseColorValue(quad11, 100, acceptPercent: true, out var value18);
					if (flag5 & TryParseOpacity(quad12, out var value19))
					{
						color = FromHsva((float)value16, (float)value17, (float)value18, (float)value19);
						return true;
					}
				}
			}
			else if (value.StartsWith("hsv".AsSpan(), StringComparison.OrdinalIgnoreCase))
			{
				if (TryParseThreeColorRanges(value, out var triplet7, out var triplet8, out var triplet9))
				{
					bool flag6 = TryParseColorValue(triplet7, 360, acceptPercent: false, out var value20);
					flag6 &= TryParseColorValue(triplet8, 100, acceptPercent: true, out var value21);
					if (flag6 & TryParseColorValue(triplet9, 100, acceptPercent: true, out var value22))
					{
						color = FromHsv((float)value20, (float)value21, (float)value22);
						return true;
					}
				}
			}
			else
			{
				Color namedColor = GetNamedColor(value);
				if (namedColor != null)
				{
					color = namedColor;
					return true;
				}
			}
		}
		color = null;
		return false;
	}

	private static Color GetNamedColor(ReadOnlySpan<char> value)
	{
		Span<char> span = ((value.Length > 128) ? ((Span<char>)new char[value.Length]) : stackalloc char[value.Length]);
		Span<char> span2 = span;
		int num = value.ToLowerInvariant(span2);
		return span2 switch
		{
			"default" => null, 
			"aliceblue" => Colors.AliceBlue, 
			"antiquewhite" => Colors.AntiqueWhite, 
			"aqua" => Colors.Aqua, 
			"aquamarine" => Colors.Aquamarine, 
			"azure" => Colors.Azure, 
			"beige" => Colors.Beige, 
			"bisque" => Colors.Bisque, 
			"black" => Colors.Black, 
			"blanchedalmond" => Colors.BlanchedAlmond, 
			"blue" => Colors.Blue, 
			"blueviolet" => Colors.BlueViolet, 
			"brown" => Colors.Brown, 
			"burlywood" => Colors.BurlyWood, 
			"cadetblue" => Colors.CadetBlue, 
			"chartreuse" => Colors.Chartreuse, 
			"chocolate" => Colors.Chocolate, 
			"coral" => Colors.Coral, 
			"cornflowerblue" => Colors.CornflowerBlue, 
			"cornsilk" => Colors.Cornsilk, 
			"crimson" => Colors.Crimson, 
			"cyan" => Colors.Cyan, 
			"darkblue" => Colors.DarkBlue, 
			"darkcyan" => Colors.DarkCyan, 
			"darkgoldenrod" => Colors.DarkGoldenrod, 
			"darkgray" => Colors.DarkGray, 
			"darkgreen" => Colors.DarkGreen, 
			"darkgrey" => Colors.DarkGrey, 
			"darkkhaki" => Colors.DarkKhaki, 
			"darkmagenta" => Colors.DarkMagenta, 
			"darkolivegreen" => Colors.DarkOliveGreen, 
			"darkorange" => Colors.DarkOrange, 
			"darkorchid" => Colors.DarkOrchid, 
			"darkred" => Colors.DarkRed, 
			"darksalmon" => Colors.DarkSalmon, 
			"darkseagreen" => Colors.DarkSeaGreen, 
			"darkslateblue" => Colors.DarkSlateBlue, 
			"darkslategray" => Colors.DarkSlateGray, 
			"darkslategrey" => Colors.DarkSlateGrey, 
			"darkturquoise" => Colors.DarkTurquoise, 
			"darkviolet" => Colors.DarkViolet, 
			"deeppink" => Colors.DeepPink, 
			"deepskyblue" => Colors.DeepSkyBlue, 
			"dimgray" => Colors.DimGray, 
			"dimgrey" => Colors.DimGrey, 
			"dodgerblue" => Colors.DodgerBlue, 
			"firebrick" => Colors.Firebrick, 
			"floralwhite" => Colors.FloralWhite, 
			"forestgreen" => Colors.ForestGreen, 
			"fuchsia" => Colors.Fuchsia, 
			"gainsboro" => Colors.Gainsboro, 
			"ghostwhite" => Colors.GhostWhite, 
			"gold" => Colors.Gold, 
			"goldenrod" => Colors.Goldenrod, 
			"gray" => Colors.Gray, 
			"green" => Colors.Green, 
			"grey" => Colors.Grey, 
			"greenyellow" => Colors.GreenYellow, 
			"honeydew" => Colors.Honeydew, 
			"hotpink" => Colors.HotPink, 
			"indianred" => Colors.IndianRed, 
			"indigo" => Colors.Indigo, 
			"ivory" => Colors.Ivory, 
			"khaki" => Colors.Khaki, 
			"lavender" => Colors.Lavender, 
			"lavenderblush" => Colors.LavenderBlush, 
			"lawngreen" => Colors.LawnGreen, 
			"lemonchiffon" => Colors.LemonChiffon, 
			"lightblue" => Colors.LightBlue, 
			"lightcoral" => Colors.LightCoral, 
			"lightcyan" => Colors.LightCyan, 
			"lightgoldenrodyellow" => Colors.LightGoldenrodYellow, 
			"lightgrey" => Colors.LightGrey, 
			"lightgray" => Colors.LightGray, 
			"lightgreen" => Colors.LightGreen, 
			"lightpink" => Colors.LightPink, 
			"lightsalmon" => Colors.LightSalmon, 
			"lightseagreen" => Colors.LightSeaGreen, 
			"lightskyblue" => Colors.LightSkyBlue, 
			"lightslategray" => Colors.LightSlateGray, 
			"lightslategrey" => Colors.LightSlateGrey, 
			"lightsteelblue" => Colors.LightSteelBlue, 
			"lightyellow" => Colors.LightYellow, 
			"lime" => Colors.Lime, 
			"limegreen" => Colors.LimeGreen, 
			"linen" => Colors.Linen, 
			"magenta" => Colors.Magenta, 
			"maroon" => Colors.Maroon, 
			"mediumaquamarine" => Colors.MediumAquamarine, 
			"mediumblue" => Colors.MediumBlue, 
			"mediumorchid" => Colors.MediumOrchid, 
			"mediumpurple" => Colors.MediumPurple, 
			"mediumseagreen" => Colors.MediumSeaGreen, 
			"mediumslateblue" => Colors.MediumSlateBlue, 
			"mediumspringgreen" => Colors.MediumSpringGreen, 
			"mediumturquoise" => Colors.MediumTurquoise, 
			"mediumvioletred" => Colors.MediumVioletRed, 
			"midnightblue" => Colors.MidnightBlue, 
			"mintcream" => Colors.MintCream, 
			"mistyrose" => Colors.MistyRose, 
			"moccasin" => Colors.Moccasin, 
			"navajowhite" => Colors.NavajoWhite, 
			"navy" => Colors.Navy, 
			"oldlace" => Colors.OldLace, 
			"olive" => Colors.Olive, 
			"olivedrab" => Colors.OliveDrab, 
			"orange" => Colors.Orange, 
			"orangered" => Colors.OrangeRed, 
			"orchid" => Colors.Orchid, 
			"palegoldenrod" => Colors.PaleGoldenrod, 
			"palegreen" => Colors.PaleGreen, 
			"paleturquoise" => Colors.PaleTurquoise, 
			"palevioletred" => Colors.PaleVioletRed, 
			"papayawhip" => Colors.PapayaWhip, 
			"peachpuff" => Colors.PeachPuff, 
			"peru" => Colors.Peru, 
			"pink" => Colors.Pink, 
			"plum" => Colors.Plum, 
			"powderblue" => Colors.PowderBlue, 
			"purple" => Colors.Purple, 
			"red" => Colors.Red, 
			"rosybrown" => Colors.RosyBrown, 
			"royalblue" => Colors.RoyalBlue, 
			"saddlebrown" => Colors.SaddleBrown, 
			"salmon" => Colors.Salmon, 
			"sandybrown" => Colors.SandyBrown, 
			"seagreen" => Colors.SeaGreen, 
			"seashell" => Colors.SeaShell, 
			"sienna" => Colors.Sienna, 
			"silver" => Colors.Silver, 
			"skyblue" => Colors.SkyBlue, 
			"slateblue" => Colors.SlateBlue, 
			"slategray" => Colors.SlateGray, 
			"slategrey" => Colors.SlateGrey, 
			"snow" => Colors.Snow, 
			"springgreen" => Colors.SpringGreen, 
			"steelblue" => Colors.SteelBlue, 
			"tan" => Colors.Tan, 
			"teal" => Colors.Teal, 
			"thistle" => Colors.Thistle, 
			"tomato" => Colors.Tomato, 
			"transparent" => Colors.Transparent, 
			"turquoise" => Colors.Turquoise, 
			"violet" => Colors.Violet, 
			"wheat" => Colors.Wheat, 
			"white" => Colors.White, 
			"whitesmoke" => Colors.WhiteSmoke, 
			"yellow" => Colors.Yellow, 
			"yellowgreen" => Colors.YellowGreen, 
			_ => null, 
		};
	}

	private static bool TryParseFourColorRanges(ReadOnlySpan<char> value, out ReadOnlySpan<char> quad0, out ReadOnlySpan<char> quad1, out ReadOnlySpan<char> quad2, out ReadOnlySpan<char> quad3)
	{
		int num = value.IndexOf('(');
		int num2 = value.LastIndexOf(')');
		if (num >= 0 && num2 >= 0 && num2 >= num)
		{
			value = value.Slice(num + 1, num2 - num - 1);
			int num3 = value.IndexOf(',');
			if (num3 != -1)
			{
				quad0 = value.Slice(0, num3);
				value = value.Slice(num3 + 1);
				num3 = value.IndexOf(',');
				if (num3 != -1)
				{
					quad1 = value.Slice(0, num3);
					value = value.Slice(num3 + 1);
					num3 = value.IndexOf(',');
					if (num3 != -1)
					{
						quad2 = value.Slice(0, num3);
						quad3 = value.Slice(num3 + 1);
						if (quad3.IndexOf(',') == -1)
						{
							return true;
						}
					}
				}
			}
		}
		quad0 = (quad1 = (quad2 = (quad3 = default(ReadOnlySpan<char>))));
		return false;
	}

	private static bool TryParseThreeColorRanges(ReadOnlySpan<char> value, out ReadOnlySpan<char> triplet0, out ReadOnlySpan<char> triplet1, out ReadOnlySpan<char> triplet2)
	{
		int num = value.IndexOf('(');
		int num2 = value.LastIndexOf(')');
		if (num >= 0 && num2 >= 0 && num2 >= num)
		{
			value = value.Slice(num + 1, num2 - num - 1);
			int num3 = value.IndexOf(',');
			if (num3 != -1)
			{
				triplet0 = value.Slice(0, num3);
				value = value.Slice(num3 + 1);
				num3 = value.IndexOf(',');
				if (num3 != -1)
				{
					triplet1 = value.Slice(0, num3);
					triplet2 = value.Slice(num3 + 1);
					if (triplet2.IndexOf(',') == -1)
					{
						return true;
					}
				}
			}
		}
		triplet0 = (triplet1 = (triplet2 = default(ReadOnlySpan<char>)));
		return false;
	}

	private static bool TryParseColorValue(ReadOnlySpan<char> elem, int maxValue, bool acceptPercent, out double value)
	{
		elem = elem.Trim();
		if (!elem.IsEmpty && elem[elem.Length - 1] == '%' && acceptPercent)
		{
			maxValue = 100;
			elem = elem.Slice(0, elem.Length - 1);
		}
		if (TryParseDouble(elem, out value))
		{
			value = value.Clamp(0.0, maxValue) / (double)maxValue;
			return true;
		}
		return false;
	}

	private static bool TryParseOpacity(ReadOnlySpan<char> elem, out double value)
	{
		if (TryParseDouble(elem, out value))
		{
			value = value.Clamp(0.0, 1.0);
			return true;
		}
		return false;
	}

	private static bool TryParseDouble(ReadOnlySpan<char> s, out double value)
	{
		return double.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
	}

	private static int ParseInt(ReadOnlySpan<char> s)
	{
		return int.Parse(s, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
	}

	public static implicit operator Color(Vector4 color)
	{
		return new Color(color);
	}
}
