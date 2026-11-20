using System.Collections.Generic;
using System.Text;
using NanoXLSX.Exceptions;

namespace NanoXLSX.Styles;

public class Font : AbstractStyle
{
	public enum SchemeValue
	{
		major,
		minor,
		none
	}

	public enum VerticalAlignValue
	{
		subscript,
		superscript,
		none
	}

	public enum UnderlineValue
	{
		u_single,
		u_double,
		singleAccounting,
		doubleAccounting,
		none
	}

	public static readonly string DEFAULT_MAJOR_FONT = "Calibri Light";

	public static readonly string DEFAULT_MINOR_FONT = "Calibri";

	public static readonly string DEFAULT_FONT_NAME = DEFAULT_MINOR_FONT;

	public static readonly SchemeValue DEFAULT_FONT_SCHEME = SchemeValue.minor;

	public static readonly float MIN_FONT_SIZE = 1f;

	public static readonly float MAX_FONT_SIZE = 409f;

	public static readonly float DEFAULT_FONT_SIZE = 11f;

	public static readonly string DEFAULT_FONT_FAMILY = "2";

	public static readonly VerticalAlignValue DEFAULT_VERTICAL_ALIGN = VerticalAlignValue.none;

	private float size;

	private string name = DEFAULT_FONT_NAME;

	private int colorTheme;

	private string colorValue = "";

	[Append]
	public bool Bold { get; set; }

	[Append]
	public bool Italic { get; set; }

	[Append]
	public bool Strike { get; set; }

	[Append]
	public UnderlineValue Underline { get; set; } = UnderlineValue.none;

	[Append]
	public string Charset { get; set; }

	[Append]
	public int ColorTheme
	{
		get
		{
			return colorTheme;
		}
		set
		{
			if (value < 0)
			{
				throw new StyleException("The color theme number " + value + " is invalid. Should be >=0");
			}
			colorTheme = value;
		}
	}

	[Append]
	public string ColorValue
	{
		get
		{
			return colorValue;
		}
		set
		{
			Fill.ValidateColor(value, useAlpha: true, allowEmpty: true);
			colorValue = value;
		}
	}

	[Append]
	public string Family { get; set; }

	[Append(Ignore = true)]
	public bool IsDefaultFont
	{
		get
		{
			Font other = new Font();
			return Equals(other);
		}
	}

	[Append]
	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			ValidateFontScheme();
		}
	}

	[Append]
	public SchemeValue Scheme { get; set; }

	[Append]
	public float Size
	{
		get
		{
			return size;
		}
		set
		{
			if (value < MIN_FONT_SIZE)
			{
				size = MIN_FONT_SIZE;
			}
			else if (value > MAX_FONT_SIZE)
			{
				size = MAX_FONT_SIZE;
			}
			else
			{
				size = value;
			}
		}
	}

	[Append]
	public VerticalAlignValue VerticalAlign { get; set; }

	public Font()
	{
		size = DEFAULT_FONT_SIZE;
		Name = DEFAULT_FONT_NAME;
		Family = DEFAULT_FONT_FAMILY;
		ColorTheme = 1;
		ColorValue = string.Empty;
		Charset = string.Empty;
		Scheme = DEFAULT_FONT_SCHEME;
		VerticalAlign = DEFAULT_VERTICAL_ALIGN;
	}

	private void ValidateFontScheme()
	{
		if (string.IsNullOrEmpty(name) && !StyleRepository.Instance.ImportInProgress)
		{
			throw new StyleException("The font name was null or empty");
		}
		if (name.Equals(DEFAULT_MINOR_FONT))
		{
			Scheme = SchemeValue.minor;
		}
		else if (name.Equals(DEFAULT_MAJOR_FONT))
		{
			Scheme = SchemeValue.major;
		}
		else
		{
			Scheme = SchemeValue.none;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\"Font\": {\n");
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Bold", Bold);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Charset", Charset);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "ColorTheme", ColorTheme);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "ColorValue", ColorValue);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "VerticalAlign", VerticalAlign);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Family", Family);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Italic", Italic);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Name", Name);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Scheme", Scheme);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Size", Size);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Strike", Strike);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Underline", Underline);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HashCode", GetHashCode(), terminate: true);
		stringBuilder.Append("\n}");
		return stringBuilder.ToString();
	}

	public override AbstractStyle Copy()
	{
		return new Font
		{
			Bold = Bold,
			Charset = Charset,
			ColorTheme = ColorTheme,
			ColorValue = ColorValue,
			VerticalAlign = VerticalAlign,
			Family = Family,
			Italic = Italic,
			Name = Name,
			Scheme = Scheme,
			Size = Size,
			Strike = Strike,
			Underline = Underline
		};
	}

	public override int GetHashCode()
	{
		return (((((((((((-924704582 * -1521134295 + size.GetHashCode()) * -1521134295 + Bold.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Charset)) * -1521134295 + ColorTheme.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ColorValue)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Family)) * -1521134295 + Italic.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name)) * -1521134295 + Scheme.GetHashCode()) * -1521134295 + Strike.GetHashCode()) * -1521134295 + Underline.GetHashCode()) * -1521134295 + VerticalAlign.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Font font && size == font.size && Bold == font.Bold && Italic == font.Italic && Strike == font.Strike && Underline == font.Underline && Charset == font.Charset && ColorTheme == font.ColorTheme && ColorValue == font.ColorValue && Family == font.Family && Name == font.Name && Scheme == font.Scheme)
		{
			return VerticalAlign == font.VerticalAlign;
		}
		return false;
	}

	public Font CopyFont()
	{
		return (Font)Copy();
	}
}
