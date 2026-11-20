namespace NanoXLSX.Styles;

public static class BasicStyles
{
	private enum StyleEnum
	{
		bold,
		italic,
		boldItalic,
		underline,
		doubleUnderline,
		strike,
		dateFormat,
		timeFormat,
		roundFormat,
		borderFrame,
		borderFrameHeader,
		dottedFill_0_125,
		mergeCellStyle
	}

	private static Style bold;

	private static Style italic;

	private static Style boldItalic;

	private static Style underline;

	private static Style doubleUnderline;

	private static Style strike;

	private static Style dateFormat;

	private static Style timeFormat;

	private static Style roundFormat;

	private static Style borderFrame;

	private static Style borderFrameHeader;

	private static Style dottedFill_0_125;

	private static Style mergeCellStyle;

	public static Style DateFormat => GetStyle(StyleEnum.dateFormat);

	public static Style TimeFormat => GetStyle(StyleEnum.timeFormat);

	public static Style DottedFill_0_125 => GetStyle(StyleEnum.dottedFill_0_125);

	public static Style MergeCellStyle => GetStyle(StyleEnum.mergeCellStyle);

	private static Style GetStyle(StyleEnum value)
	{
		Style style = null;
		switch (value)
		{
		case StyleEnum.bold:
			if (bold == null)
			{
				bold = new Style();
				bold.CurrentFont.Bold = true;
			}
			style = bold;
			break;
		case StyleEnum.italic:
			if (italic == null)
			{
				italic = new Style();
				italic.CurrentFont.Italic = true;
			}
			style = italic;
			break;
		case StyleEnum.boldItalic:
			if (boldItalic == null)
			{
				boldItalic = new Style();
				boldItalic.CurrentFont.Italic = true;
				boldItalic.CurrentFont.Bold = true;
			}
			style = boldItalic;
			break;
		case StyleEnum.underline:
			if (underline == null)
			{
				underline = new Style();
				underline.CurrentFont.Underline = NanoXLSX.Styles.Font.UnderlineValue.u_single;
			}
			style = underline;
			break;
		case StyleEnum.doubleUnderline:
			if (doubleUnderline == null)
			{
				doubleUnderline = new Style();
				doubleUnderline.CurrentFont.Underline = NanoXLSX.Styles.Font.UnderlineValue.u_double;
			}
			style = doubleUnderline;
			break;
		case StyleEnum.strike:
			if (strike == null)
			{
				strike = new Style();
				strike.CurrentFont.Strike = true;
			}
			style = strike;
			break;
		case StyleEnum.dateFormat:
			if (dateFormat == null)
			{
				dateFormat = new Style();
				dateFormat.CurrentNumberFormat.Number = NumberFormat.FormatNumber.format_14;
			}
			style = dateFormat;
			break;
		case StyleEnum.timeFormat:
			if (timeFormat == null)
			{
				timeFormat = new Style();
				timeFormat.CurrentNumberFormat.Number = NumberFormat.FormatNumber.format_21;
			}
			style = timeFormat;
			break;
		case StyleEnum.roundFormat:
			if (roundFormat == null)
			{
				roundFormat = new Style();
				roundFormat.CurrentNumberFormat.Number = NumberFormat.FormatNumber.format_1;
			}
			style = roundFormat;
			break;
		case StyleEnum.borderFrame:
			if (borderFrame == null)
			{
				borderFrame = new Style();
				borderFrame.CurrentBorder.TopStyle = Border.StyleValue.thin;
				borderFrame.CurrentBorder.BottomStyle = Border.StyleValue.thin;
				borderFrame.CurrentBorder.LeftStyle = Border.StyleValue.thin;
				borderFrame.CurrentBorder.RightStyle = Border.StyleValue.thin;
			}
			style = borderFrame;
			break;
		case StyleEnum.borderFrameHeader:
			if (borderFrameHeader == null)
			{
				borderFrameHeader = new Style();
				borderFrameHeader.CurrentBorder.TopStyle = Border.StyleValue.thin;
				borderFrameHeader.CurrentBorder.BottomStyle = Border.StyleValue.medium;
				borderFrameHeader.CurrentBorder.LeftStyle = Border.StyleValue.thin;
				borderFrameHeader.CurrentBorder.RightStyle = Border.StyleValue.thin;
				borderFrameHeader.CurrentFont.Bold = true;
			}
			style = borderFrameHeader;
			break;
		case StyleEnum.dottedFill_0_125:
			if (dottedFill_0_125 == null)
			{
				dottedFill_0_125 = new Style();
				dottedFill_0_125.CurrentFill.PatternFill = Fill.PatternValue.gray125;
			}
			style = dottedFill_0_125;
			break;
		case StyleEnum.mergeCellStyle:
			if (mergeCellStyle == null)
			{
				mergeCellStyle = new Style();
				mergeCellStyle.CurrentCellXf.ForceApplyAlignment = true;
			}
			style = mergeCellStyle;
			break;
		}
		return style.CopyStyle();
	}

	public static Style Font(string fontName, float fontSize = 11f, bool isBold = false, bool isItalic = false)
	{
		return new Style
		{
			CurrentFont = 
			{
				Name = fontName,
				Size = fontSize,
				Bold = isBold,
				Italic = isItalic
			}
		};
	}
}
