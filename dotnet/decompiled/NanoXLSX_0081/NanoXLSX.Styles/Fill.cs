using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NanoXLSX.Exceptions;

namespace NanoXLSX.Styles;

public class Fill : AbstractStyle
{
	public enum PatternValue
	{
		none,
		solid,
		darkGray,
		mediumGray,
		lightGray,
		gray0625,
		gray125
	}

	public static readonly string DEFAULT_COLOR = "FF000000";

	public static readonly int DEFAULT_INDEXED_COLOR = 64;

	public static readonly PatternValue DEFAULT_PATTERN_FILL = PatternValue.none;

	private string backgroundColor = DEFAULT_COLOR;

	private string foregroundColor = DEFAULT_COLOR;

	[Append]
	public string BackgroundColor
	{
		get
		{
			return backgroundColor;
		}
		set
		{
			ValidateColor(value, useAlpha: true);
			backgroundColor = value;
			if (PatternFill == PatternValue.none)
			{
				PatternFill = PatternValue.solid;
			}
		}
	}

	[Append]
	public string ForegroundColor
	{
		get
		{
			return foregroundColor;
		}
		set
		{
			ValidateColor(value, useAlpha: true);
			foregroundColor = value;
			if (PatternFill == PatternValue.none)
			{
				PatternFill = PatternValue.solid;
			}
		}
	}

	[Append]
	public int IndexedColor { get; set; }

	[Append]
	public PatternValue PatternFill { get; set; }

	public Fill()
	{
		IndexedColor = DEFAULT_INDEXED_COLOR;
		PatternFill = DEFAULT_PATTERN_FILL;
		foregroundColor = DEFAULT_COLOR;
		backgroundColor = DEFAULT_COLOR;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\"Fill\": {\n");
		AbstractStyle.AddPropertyAsJson(stringBuilder, "BackgroundColor", BackgroundColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "ForegroundColor", ForegroundColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "IndexedColor", IndexedColor);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "PatternFill", PatternFill);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HashCode", GetHashCode(), terminate: true);
		stringBuilder.Append("\n}");
		return stringBuilder.ToString();
	}

	public override AbstractStyle Copy()
	{
		return new Fill
		{
			BackgroundColor = BackgroundColor,
			ForegroundColor = ForegroundColor,
			IndexedColor = IndexedColor,
			PatternFill = PatternFill
		};
	}

	public override int GetHashCode()
	{
		return (((-1564173520 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BackgroundColor)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ForegroundColor)) * -1521134295 + IndexedColor.GetHashCode()) * -1521134295 + PatternFill.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Fill fill && BackgroundColor == fill.BackgroundColor && ForegroundColor == fill.ForegroundColor && IndexedColor == fill.IndexedColor)
		{
			return PatternFill == fill.PatternFill;
		}
		return false;
	}

	public Fill CopyFill()
	{
		return (Fill)Copy();
	}

	internal static string GetPatternName(PatternValue pattern)
	{
		return pattern switch
		{
			PatternValue.solid => "solid", 
			PatternValue.darkGray => "darkGray", 
			PatternValue.mediumGray => "mediumGray", 
			PatternValue.lightGray => "lightGray", 
			PatternValue.gray0625 => "gray0625", 
			PatternValue.gray125 => "gray125", 
			_ => "none", 
		};
	}

	public static void ValidateColor(string hexCode, bool useAlpha, bool allowEmpty = false)
	{
		if (string.IsNullOrEmpty(hexCode))
		{
			if (!allowEmpty)
			{
				throw new StyleException("The color expression was null or empty");
			}
			return;
		}
		int num = (useAlpha ? 8 : 6);
		if (hexCode.Length != num)
		{
			throw new StyleException("The value '" + hexCode + "' is invalid. A valid value must contain " + num + " hex characters");
		}
		if (!Regex.IsMatch(hexCode, "[a-fA-F0-9]{6,8}"))
		{
			throw new StyleException("The expression '" + hexCode + "' is not a valid hex value");
		}
	}
}
