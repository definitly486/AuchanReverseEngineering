using System.Collections.Generic;
using System.Globalization;

namespace System.Drawing;

public static class ColorTranslator
{
	private static Dictionary<string, Color> s_htmlSysColorTable;

	public static Color FromHtml(string htmlColor)
	{
		Color value = Color.Empty;
		if (htmlColor == null || htmlColor.Length == 0)
		{
			return value;
		}
		if (htmlColor[0] == '#' && (htmlColor.Length == 7 || htmlColor.Length == 4))
		{
			if (htmlColor.Length == 7)
			{
				value = Color.FromArgb(Convert.ToInt32(htmlColor.Substring(1, 2), 16), Convert.ToInt32(htmlColor.Substring(3, 2), 16), Convert.ToInt32(htmlColor.Substring(5, 2), 16));
			}
			else
			{
				string text = char.ToString(htmlColor[1]);
				string text2 = char.ToString(htmlColor[2]);
				string text3 = char.ToString(htmlColor[3]);
				value = Color.FromArgb(Convert.ToInt32(text + text, 16), Convert.ToInt32(text2 + text2, 16), Convert.ToInt32(text3 + text3, 16));
			}
		}
		if (value.IsEmpty && string.Equals(htmlColor, "LightGrey", StringComparison.OrdinalIgnoreCase))
		{
			value = Color.LightGray;
		}
		if (value.IsEmpty)
		{
			if (s_htmlSysColorTable == null)
			{
				InitializeHtmlSysColorTable();
			}
			s_htmlSysColorTable.TryGetValue(htmlColor.ToLowerInvariant(), out value);
		}
		if (value.IsEmpty)
		{
			try
			{
				value = ColorConverterCommon.ConvertFromString(htmlColor, CultureInfo.CurrentCulture);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(ex.Message, "htmlColor", ex);
			}
		}
		return value;
	}

	private static void InitializeHtmlSysColorTable()
	{
		s_htmlSysColorTable = new Dictionary<string, Color>(27)
		{
			["activeborder"] = Color.FromKnownColor(KnownColor.ActiveBorder),
			["activecaption"] = Color.FromKnownColor(KnownColor.ActiveCaption),
			["appworkspace"] = Color.FromKnownColor(KnownColor.AppWorkspace),
			["background"] = Color.FromKnownColor(KnownColor.Desktop),
			["buttonface"] = Color.FromKnownColor(KnownColor.Control),
			["buttonhighlight"] = Color.FromKnownColor(KnownColor.ControlLightLight),
			["buttonshadow"] = Color.FromKnownColor(KnownColor.ControlDark),
			["buttontext"] = Color.FromKnownColor(KnownColor.ControlText),
			["captiontext"] = Color.FromKnownColor(KnownColor.ActiveCaptionText),
			["graytext"] = Color.FromKnownColor(KnownColor.GrayText),
			["highlight"] = Color.FromKnownColor(KnownColor.Highlight),
			["highlighttext"] = Color.FromKnownColor(KnownColor.HighlightText),
			["inactiveborder"] = Color.FromKnownColor(KnownColor.InactiveBorder),
			["inactivecaption"] = Color.FromKnownColor(KnownColor.InactiveCaption),
			["inactivecaptiontext"] = Color.FromKnownColor(KnownColor.InactiveCaptionText),
			["infobackground"] = Color.FromKnownColor(KnownColor.Info),
			["infotext"] = Color.FromKnownColor(KnownColor.InfoText),
			["menu"] = Color.FromKnownColor(KnownColor.Menu),
			["menutext"] = Color.FromKnownColor(KnownColor.MenuText),
			["scrollbar"] = Color.FromKnownColor(KnownColor.ScrollBar),
			["threeddarkshadow"] = Color.FromKnownColor(KnownColor.ControlDarkDark),
			["threedface"] = Color.FromKnownColor(KnownColor.Control),
			["threedhighlight"] = Color.FromKnownColor(KnownColor.ControlLight),
			["threedlightshadow"] = Color.FromKnownColor(KnownColor.ControlLightLight),
			["window"] = Color.FromKnownColor(KnownColor.Window),
			["windowframe"] = Color.FromKnownColor(KnownColor.WindowFrame),
			["windowtext"] = Color.FromKnownColor(KnownColor.WindowText)
		};
	}
}
