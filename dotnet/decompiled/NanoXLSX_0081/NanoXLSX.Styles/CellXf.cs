using System.Text;
using NanoXLSX.Exceptions;

namespace NanoXLSX.Styles;

public class CellXf : AbstractStyle
{
	public enum HorizontalAlignValue
	{
		left,
		center,
		right,
		fill,
		justify,
		general,
		centerContinuous,
		distributed,
		none
	}

	public enum TextBreakValue
	{
		wrapText,
		shrinkToFit,
		none
	}

	public enum TextDirectionValue
	{
		horizontal,
		vertical
	}

	public enum VerticalAlignValue
	{
		bottom,
		top,
		center,
		justify,
		distributed,
		none
	}

	public static readonly HorizontalAlignValue DEFAULT_HORIZONTAL_ALIGNMENT = HorizontalAlignValue.none;

	public static readonly TextBreakValue DEFAULT_ALIGNMENT = TextBreakValue.none;

	public static readonly TextDirectionValue DEFAULT_TEXT_DIRECTION = TextDirectionValue.horizontal;

	public static readonly VerticalAlignValue DEFAULT_VERTICAL_ALIGNMENT = VerticalAlignValue.none;

	private int textRotation;

	private TextDirectionValue textDirection;

	private int indent;

	[Append]
	public bool ForceApplyAlignment { get; set; }

	[Append]
	public bool Hidden { get; set; }

	[Append]
	public HorizontalAlignValue HorizontalAlign { get; set; }

	[Append]
	public bool Locked { get; set; }

	[Append]
	public TextBreakValue Alignment { get; set; }

	[Append]
	public TextDirectionValue TextDirection
	{
		get
		{
			return textDirection;
		}
		set
		{
			textDirection = value;
			CalculateInternalRotation();
		}
	}

	[Append]
	public int TextRotation
	{
		get
		{
			return textRotation;
		}
		set
		{
			textRotation = value;
			TextDirection = TextDirectionValue.horizontal;
			CalculateInternalRotation();
		}
	}

	[Append]
	public VerticalAlignValue VerticalAlign { get; set; }

	[Append]
	public int Indent
	{
		get
		{
			return indent;
		}
		set
		{
			if (value >= 0)
			{
				indent = value;
				return;
			}
			throw new StyleException("The indent value '" + value + "' is not valid. It must be >= 0");
		}
	}

	public CellXf()
	{
		HorizontalAlign = DEFAULT_HORIZONTAL_ALIGNMENT;
		Alignment = DEFAULT_ALIGNMENT;
		textDirection = DEFAULT_TEXT_DIRECTION;
		VerticalAlign = DEFAULT_VERTICAL_ALIGNMENT;
		textRotation = 0;
		Indent = 0;
	}

	internal int CalculateInternalRotation()
	{
		if (textRotation < -90 || textRotation > 90)
		{
			throw new FormatException("The rotation value (" + Utils.ToString(textRotation) + "°) is out of range. Range is form -90° to +90°");
		}
		if (textDirection == TextDirectionValue.vertical)
		{
			textRotation = 255;
			return textRotation;
		}
		if (textRotation >= 0)
		{
			return textRotation;
		}
		return 90 - textRotation;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\"StyleXF\": {\n");
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HorizontalAlign", HorizontalAlign);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Alignment", Alignment);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "TextDirection", TextDirection);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "TextRotation", TextRotation);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "VerticalAlign", VerticalAlign);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "ForceApplyAlignment", ForceApplyAlignment);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Locked", Locked);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Hidden", Hidden);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Indent", Indent);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HashCode", GetHashCode(), terminate: true);
		stringBuilder.Append("\n}");
		return stringBuilder.ToString();
	}

	public override int GetHashCode()
	{
		return ((((((((626307906 * -1521134295 + ForceApplyAlignment.GetHashCode()) * -1521134295 + Hidden.GetHashCode()) * -1521134295 + HorizontalAlign.GetHashCode()) * -1521134295 + Locked.GetHashCode()) * -1521134295 + Alignment.GetHashCode()) * -1521134295 + TextDirection.GetHashCode()) * -1521134295 + TextRotation.GetHashCode()) * -1521134295 + VerticalAlign.GetHashCode()) * -1521134295 + Indent.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is CellXf cellXf && ForceApplyAlignment == cellXf.ForceApplyAlignment && Hidden == cellXf.Hidden && HorizontalAlign == cellXf.HorizontalAlign && Locked == cellXf.Locked && Alignment == cellXf.Alignment && TextDirection == cellXf.TextDirection && TextRotation == cellXf.TextRotation && VerticalAlign == cellXf.VerticalAlign)
		{
			return Indent == cellXf.Indent;
		}
		return false;
	}

	public override AbstractStyle Copy()
	{
		return new CellXf
		{
			HorizontalAlign = HorizontalAlign,
			Alignment = Alignment,
			TextDirection = TextDirection,
			TextRotation = TextRotation,
			VerticalAlign = VerticalAlign,
			ForceApplyAlignment = ForceApplyAlignment,
			Locked = Locked,
			Hidden = Hidden,
			Indent = Indent
		};
	}

	public CellXf CopyCellXf()
	{
		return (CellXf)Copy();
	}
}
