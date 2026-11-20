using System.Collections.Generic;
using System.Text;

namespace NanoXLSX.Styles;

public class Border : AbstractStyle
{
	public enum StyleValue
	{
		none,
		hair,
		dotted,
		dashDotDot,
		dashDot,
		dashed,
		thin,
		mediumDashDotDot,
		slantDashDot,
		mediumDashDot,
		mediumDashed,
		medium,
		thick,
		s_double
	}

	public static readonly StyleValue DEFAULT_BORDER_STYLE = StyleValue.none;

	public static readonly string DEFAULT_COLOR = "";

	private string diagonalColor;

	private string leftColor;

	private string rightColor;

	private string topColor;

	private string bottomColor;

	[Append]
	public string BottomColor
	{
		get
		{
			return bottomColor;
		}
		set
		{
			Fill.ValidateColor(value, useAlpha: true, allowEmpty: true);
			bottomColor = value;
		}
	}

	[Append]
	public StyleValue BottomStyle { get; set; }

	[Append]
	public string DiagonalColor
	{
		get
		{
			return diagonalColor;
		}
		set
		{
			Fill.ValidateColor(value, useAlpha: true, allowEmpty: true);
			diagonalColor = value;
		}
	}

	[Append]
	public bool DiagonalDown { get; set; }

	[Append]
	public bool DiagonalUp { get; set; }

	[Append]
	public StyleValue DiagonalStyle { get; set; }

	[Append]
	public string LeftColor
	{
		get
		{
			return leftColor;
		}
		set
		{
			Fill.ValidateColor(value, useAlpha: true, allowEmpty: true);
			leftColor = value;
		}
	}

	[Append]
	public StyleValue LeftStyle { get; set; }

	[Append]
	public string RightColor
	{
		get
		{
			return rightColor;
		}
		set
		{
			Fill.ValidateColor(value, useAlpha: true, allowEmpty: true);
			rightColor = value;
		}
	}

	[Append]
	public StyleValue RightStyle { get; set; }

	[Append]
	public string TopColor
	{
		get
		{
			return topColor;
		}
		set
		{
			Fill.ValidateColor(value, useAlpha: true, allowEmpty: true);
			topColor = value;
		}
	}

	[Append]
	public StyleValue TopStyle { get; set; }

	public Border()
	{
		BottomColor = DEFAULT_COLOR;
		TopColor = DEFAULT_COLOR;
		LeftColor = DEFAULT_COLOR;
		RightColor = DEFAULT_COLOR;
		DiagonalColor = DEFAULT_COLOR;
		LeftStyle = DEFAULT_BORDER_STYLE;
		RightStyle = DEFAULT_BORDER_STYLE;
		TopStyle = DEFAULT_BORDER_STYLE;
		BottomStyle = DEFAULT_BORDER_STYLE;
		DiagonalStyle = DEFAULT_BORDER_STYLE;
		DiagonalDown = false;
		DiagonalUp = false;
	}

	public override int GetHashCode()
	{
		return (((((((((((-153001865 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BottomColor)) * -1521134295 + BottomStyle.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DiagonalColor)) * -1521134295 + DiagonalDown.GetHashCode()) * -1521134295 + DiagonalUp.GetHashCode()) * -1521134295 + DiagonalStyle.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LeftColor)) * -1521134295 + LeftStyle.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RightColor)) * -1521134295 + RightStyle.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TopColor)) * -1521134295 + TopStyle.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Border border && BottomColor == border.BottomColor && BottomStyle == border.BottomStyle && DiagonalColor == border.DiagonalColor && DiagonalDown == border.DiagonalDown && DiagonalUp == border.DiagonalUp && DiagonalStyle == border.DiagonalStyle && LeftColor == border.LeftColor && LeftStyle == border.LeftStyle && RightColor == border.RightColor && RightStyle == border.RightStyle && TopColor == border.TopColor)
		{
			return TopStyle == border.TopStyle;
		}
		return false;
	}

	public override AbstractStyle Copy()
	{
		return new Border
		{
			BottomColor = BottomColor,
			BottomStyle = BottomStyle,
			DiagonalColor = DiagonalColor,
			DiagonalDown = DiagonalDown,
			DiagonalStyle = DiagonalStyle,
			DiagonalUp = DiagonalUp,
			LeftColor = LeftColor,
			LeftStyle = LeftStyle,
			RightColor = RightColor,
			RightStyle = RightStyle,
			TopColor = TopColor,
			TopStyle = TopStyle
		};
	}

	public Border CopyBorder()
	{
		return (Border)Copy();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\"Border\": {\n");
		AbstractStyle.AddPropertyAsJson(stringBuilder, "BottomStyle", BottomStyle);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "DiagonalColor", DiagonalColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "DiagonalDown", DiagonalDown);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "DiagonalStyle", DiagonalStyle);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "DiagonalUp", DiagonalUp);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "LeftColor", LeftColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "LeftStyle", LeftStyle);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "RightColor", RightColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "RightStyle", RightStyle);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "TopColor", TopColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "TopStyle", TopStyle);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HashCode", GetHashCode(), terminate: true);
		stringBuilder.Append("\n}");
		return stringBuilder.ToString();
	}

	internal bool IsEmpty()
	{
		bool result = true;
		if (BottomColor != DEFAULT_COLOR)
		{
			result = false;
		}
		if (TopColor != DEFAULT_COLOR)
		{
			result = false;
		}
		if (LeftColor != DEFAULT_COLOR)
		{
			result = false;
		}
		if (RightColor != DEFAULT_COLOR)
		{
			result = false;
		}
		if (DiagonalColor != DEFAULT_COLOR)
		{
			result = false;
		}
		if (LeftStyle != DEFAULT_BORDER_STYLE)
		{
			result = false;
		}
		if (RightStyle != DEFAULT_BORDER_STYLE)
		{
			result = false;
		}
		if (TopStyle != DEFAULT_BORDER_STYLE)
		{
			result = false;
		}
		if (BottomStyle != DEFAULT_BORDER_STYLE)
		{
			result = false;
		}
		if (DiagonalStyle != DEFAULT_BORDER_STYLE)
		{
			result = false;
		}
		if (DiagonalDown)
		{
			result = false;
		}
		if (DiagonalUp)
		{
			result = false;
		}
		return result;
	}

	internal static string GetStyleName(StyleValue style)
	{
		string result = "";
		switch (style)
		{
		case StyleValue.hair:
			result = "hair";
			break;
		case StyleValue.dotted:
			result = "dotted";
			break;
		case StyleValue.dashDotDot:
			result = "dashDotDot";
			break;
		case StyleValue.dashDot:
			result = "dashDot";
			break;
		case StyleValue.dashed:
			result = "dashed";
			break;
		case StyleValue.thin:
			result = "thin";
			break;
		case StyleValue.mediumDashDotDot:
			result = "mediumDashDotDot";
			break;
		case StyleValue.slantDashDot:
			result = "slantDashDot";
			break;
		case StyleValue.mediumDashDot:
			result = "mediumDashDot";
			break;
		case StyleValue.mediumDashed:
			result = "mediumDashed";
			break;
		case StyleValue.medium:
			result = "medium";
			break;
		case StyleValue.thick:
			result = "thick";
			break;
		case StyleValue.s_double:
			result = "double";
			break;
		}
		return result;
	}
}
