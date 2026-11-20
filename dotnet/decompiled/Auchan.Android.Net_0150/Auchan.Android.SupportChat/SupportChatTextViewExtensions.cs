using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Android.Text;
using Android.Text.Style;
using Android.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.SupportChat;

internal static class SupportChatTextViewExtensions
{
	private sealed class PreparedHtml
	{
		public string Html { get; }

		public IReadOnlyCollection<FontSizeRange> FontSizeRanges { get; }

		public PreparedHtml(string html, IReadOnlyCollection<FontSizeRange> fontSizeRanges)
		{
			Html = html;
			FontSizeRanges = fontSizeRanges;
		}
	}

	private sealed class ParsedStyle
	{
		public bool Uppercase { get; }

		public float FontSizeSp { get; }

		public bool HasFontSize { get; }

		public string? CssColor { get; }

		public bool Bold { get; }

		public bool Italic { get; }

		public bool Underline { get; }

		public ParsedStyle(bool uppercase, float fontSizeSp, bool hasFontSize, string? cssColor, bool bold, bool italic, bool underline)
		{
			Uppercase = uppercase;
			FontSizeSp = fontSizeSp;
			HasFontSize = hasFontSize;
			CssColor = cssColor;
			Bold = bold;
			Italic = italic;
			Underline = underline;
		}
	}

	private sealed class SpanContext
	{
		public bool Uppercase { get; }

		public float FontSizeSp { get; }

		public FontSizeRange? FontSizeRange { get; }

		public bool HasCssColor { get; }

		public bool HasBold { get; }

		public bool HasItalic { get; }

		public bool HasUnderline { get; }

		public SpanContext(bool uppercase, float fontSizeSp, FontSizeRange? fontSizeRange, bool hasCssColor, bool hasBold, bool hasItalic, bool hasUnderline)
		{
			Uppercase = uppercase;
			FontSizeSp = fontSizeSp;
			FontSizeRange = fontSizeRange;
			HasCssColor = hasCssColor;
			HasBold = hasBold;
			HasItalic = hasItalic;
			HasUnderline = hasUnderline;
		}
	}

	private sealed class FontSizeRange
	{
		public string StartMarker { get; }

		public string EndMarker { get; }

		public float FontSizeSp { get; }

		public int? Start { get; set; }

		public int? End { get; set; }

		public FontSizeRange(int id, float fontSizeSp)
		{
			FontSizeSp = fontSizeSp;
			StartMarker = $"\ue000chat-font-{id}-start\ue001";
			EndMarker = $"\ue000chat-font-{id}-end\ue001";
		}
	}

	private sealed class MarkerOccurrence
	{
		public int Index { get; }

		public int Length { get; }

		public bool IsStart { get; }

		public FontSizeRange Range { get; }

		public MarkerOccurrence(int index, int length, bool isStart, FontSizeRange range)
		{
			Index = index;
			Length = length;
			IsStart = isStart;
			Range = range;
		}
	}

	private const float MIN_FONT_SIZE_SP = 8f;

	private const float MAX_FONT_SIZE_SP = 32f;

	private static readonly Regex SpanTagRegex = new Regex("^<\\s*(?<closing>/)?\\s*span\\b(?<attributes>.*?)\\s*(?<selfClosing>/)?\\s*>$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);

	private static readonly Regex StyleAttributeRegex = new Regex("\\bstyle\\s*=\\s*(?:\"(?<double>[^\"]*)\"|'(?<single>[^']*)'|(?<bare>[^\\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);

	private static readonly Regex FontSizeRegex = new Regex("^(?<value>[+-]?(?:\\d+(?:\\.\\d+)?|\\.\\d+))\\s*(?<unit>px|pt|sp|em|rem|%)?$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

	private static readonly Regex ColorRegex = new Regex("^(?:#(?:[0-9a-f]{3}|[0-9a-f]{6}|[0-9a-f]{8})|[a-z]+)$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

	public static ICollection<IDisposable> SetSupportChatHtml(this TextView textView, string html, Action<string> onLinkClick)
	{
		float num = textView.Resources?.DisplayMetrics?.ScaledDensity ?? 1f;
		float defaultFontSizeSp = textView.TextSize / num;
		PreparedHtml preparedHtml = PrepareHtml(html, defaultFontSizeSp);
		ICollection<IDisposable> result = textView.SetLinkedHtml(preparedHtml.Html, onLinkClick);
		if (preparedHtml.FontSizeRanges.Count == 0 || textView.TextFormatted == null)
		{
			return result;
		}
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(textView.TextFormatted);
		ApplyFontSizes(spannableStringBuilder, preparedHtml.FontSizeRanges, num);
		textView.SetText(spannableStringBuilder, TextView.BufferType.Spannable);
		return result;
	}

	private static PreparedHtml PrepareHtml(string html, float defaultFontSizeSp)
	{
		StringBuilder stringBuilder = new StringBuilder(html.Length);
		Stack<SpanContext> stack = new Stack<SpanContext>();
		List<FontSizeRange> fontSizeRanges = new List<FontSizeRange>();
		int num = 0;
		while (num < html.Length)
		{
			if (html[num] == '<')
			{
				int num2 = FindTagEnd(html, num);
				if (num2 >= 0)
				{
					string tag = html.Substring(num, num2 - num + 1);
					AppendTag(stringBuilder, tag, stack, fontSizeRanges, defaultFontSizeSp);
					num = num2 + 1;
				}
				else
				{
					stringBuilder.Append('<');
					num++;
				}
			}
			else if (html[num] == '&')
			{
				int num3 = html.IndexOf(';', num + 1);
				if (num3 >= 0)
				{
					stringBuilder.Append(html, num, num3 - num + 1);
					num = num3 + 1;
				}
				else
				{
					stringBuilder.Append('&');
					num++;
				}
			}
			else
			{
				int num4 = FindTextEnd(html, num);
				string text = html.Substring(num, num4 - num);
				stringBuilder.Append(IsUppercase(stack) ? text.ToUpper(CultureInfo.CurrentCulture) : text);
				num = num4;
			}
		}
		foreach (SpanContext item in stack)
		{
			if (item.FontSizeRange != null)
			{
				stringBuilder.Append(item.FontSizeRange.EndMarker);
			}
			AppendClosingStyleTags(stringBuilder, item);
		}
		return new PreparedHtml(stringBuilder.ToString(), fontSizeRanges);
	}

	private static void AppendTag(StringBuilder result, string tag, Stack<SpanContext> spanContexts, List<FontSizeRange> fontSizeRanges, float defaultFontSizeSp)
	{
		Match match = SpanTagRegex.Match(tag);
		if (!match.Success)
		{
			result.Append(tag);
			return;
		}
		if (match.Groups["closing"].Success)
		{
			if (spanContexts.Count > 0)
			{
				SpanContext spanContext = spanContexts.Pop();
				if (spanContext.FontSizeRange != null)
				{
					result.Append(spanContext.FontSizeRange.EndMarker);
				}
				AppendClosingStyleTags(result, spanContext);
			}
			result.Append(tag);
			return;
		}
		bool success = match.Groups["selfClosing"].Success;
		ParsedStyle parsedStyle = ParseStyle(inheritedFontSizeSp: (spanContexts.Count > 0) ? spanContexts.Peek().FontSizeSp : defaultFontSizeSp, inheritedUppercase: spanContexts.Count > 0 && spanContexts.Peek().Uppercase, attributes: match.Groups["attributes"].Value, defaultFontSizeSp: defaultFontSizeSp);
		result.Append(tag);
		if (!success)
		{
			if (parsedStyle.CssColor != null)
			{
				result.Append("<font color=\"").Append(parsedStyle.CssColor).Append("\">");
			}
			if (parsedStyle.Bold)
			{
				result.Append("<b>");
			}
			if (parsedStyle.Italic)
			{
				result.Append("<i>");
			}
			if (parsedStyle.Underline)
			{
				result.Append("<u>");
			}
			FontSizeRange fontSizeRange = null;
			if (parsedStyle.HasFontSize)
			{
				fontSizeRange = new FontSizeRange(fontSizeRanges.Count, parsedStyle.FontSizeSp);
				fontSizeRanges.Add(fontSizeRange);
				result.Append(fontSizeRange.StartMarker);
			}
			spanContexts.Push(new SpanContext(parsedStyle.Uppercase, parsedStyle.FontSizeSp, fontSizeRange, parsedStyle.CssColor != null, parsedStyle.Bold, parsedStyle.Italic, parsedStyle.Underline));
		}
	}

	private static void AppendClosingStyleTags(StringBuilder result, SpanContext context)
	{
		if (context.HasUnderline)
		{
			result.Append("</u>");
		}
		if (context.HasItalic)
		{
			result.Append("</i>");
		}
		if (context.HasBold)
		{
			result.Append("</b>");
		}
		if (context.HasCssColor)
		{
			result.Append("</font>");
		}
	}

	private static ParsedStyle ParseStyle(string attributes, float inheritedFontSizeSp, float defaultFontSizeSp, bool inheritedUppercase)
	{
		Match match = StyleAttributeRegex.Match(attributes);
		if (!match.Success)
		{
			return new ParsedStyle(inheritedUppercase, inheritedFontSizeSp, hasFontSize: false, null, bold: false, italic: false, underline: false);
		}
		string obj = (match.Groups["double"].Success ? match.Groups["double"].Value : (match.Groups["single"].Success ? match.Groups["single"].Value : match.Groups["bare"].Value));
		bool uppercase = inheritedUppercase;
		float fontSizeSp = inheritedFontSizeSp;
		bool hasFontSize = false;
		string cssColor = null;
		bool bold = false;
		bool italic = false;
		bool underline = false;
		string[] array = obj.Split(';');
		foreach (string text in array)
		{
			int num = text.IndexOf(':');
			if (num < 0)
			{
				continue;
			}
			string text2 = text.Substring(0, num).Trim();
			string text3 = text.Substring(num + 1).Replace("!important", "", StringComparison.OrdinalIgnoreCase).Trim();
			float fontSizeSp2;
			if (text2.Equals("text-transform", StringComparison.OrdinalIgnoreCase))
			{
				if (text3.Equals("uppercase", StringComparison.OrdinalIgnoreCase))
				{
					uppercase = true;
				}
				else if (text3.Equals("none", StringComparison.OrdinalIgnoreCase))
				{
					uppercase = false;
				}
			}
			else if (text2.Equals("font-size", StringComparison.OrdinalIgnoreCase) && TryParseFontSize(text3, inheritedFontSizeSp, defaultFontSizeSp, out fontSizeSp2))
			{
				fontSizeSp = fontSizeSp2;
				hasFontSize = true;
			}
			else if (text2.Equals("color", StringComparison.OrdinalIgnoreCase) && ColorRegex.IsMatch(text3))
			{
				cssColor = text3;
			}
			else if (text2.Equals("font-weight", StringComparison.OrdinalIgnoreCase))
			{
				bold = IsBold(text3);
			}
			else if (text2.Equals("font-style", StringComparison.OrdinalIgnoreCase))
			{
				italic = text3.Equals("italic", StringComparison.OrdinalIgnoreCase) || text3.StartsWith("oblique", StringComparison.OrdinalIgnoreCase);
			}
			else if (text2.Equals("text-decoration", StringComparison.OrdinalIgnoreCase) || text2.Equals("text-decoration-line", StringComparison.OrdinalIgnoreCase))
			{
				underline = ContainsCssWord(text3, "underline");
			}
		}
		return new ParsedStyle(uppercase, fontSizeSp, hasFontSize, cssColor, bold, italic, underline);
	}

	private static bool IsBold(string value)
	{
		if (value.Equals("bold", StringComparison.OrdinalIgnoreCase) || value.Equals("bolder", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result >= 600;
		}
		return false;
	}

	private static bool ContainsCssWord(string value, string expected)
	{
		string[] array = value.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Equals(expected, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private static bool TryParseFontSize(string value, float inheritedFontSizeSp, float defaultFontSizeSp, out float fontSizeSp)
	{
		if (value.Equals("smaller", StringComparison.OrdinalIgnoreCase))
		{
			fontSizeSp = inheritedFontSizeSp * 0.8f;
			fontSizeSp = Math.Clamp(fontSizeSp, 8f, 32f);
			return true;
		}
		if (value.Equals("larger", StringComparison.OrdinalIgnoreCase))
		{
			fontSizeSp = inheritedFontSizeSp * 1.2f;
			fontSizeSp = Math.Clamp(fontSizeSp, 8f, 32f);
			return true;
		}
		Match match = FontSizeRegex.Match(value);
		if (!match.Success || !float.TryParse(match.Groups["value"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result) || result <= 0f)
		{
			fontSizeSp = inheritedFontSizeSp;
			return false;
		}
		fontSizeSp = match.Groups["unit"].Value.ToLowerInvariant() switch
		{
			"%" => inheritedFontSizeSp * result / 100f, 
			"em" => inheritedFontSizeSp * result, 
			"rem" => defaultFontSizeSp * result, 
			_ => result, 
		};
		fontSizeSp = Math.Clamp(fontSizeSp, 8f, 32f);
		return true;
	}

	private static void ApplyFontSizes(SpannableStringBuilder builder, IReadOnlyCollection<FontSizeRange> ranges, float scaledDensity)
	{
		string text = builder.ToString();
		List<MarkerOccurrence> list = new List<MarkerOccurrence>();
		foreach (FontSizeRange range in ranges)
		{
			int num = text.IndexOf(range.StartMarker, StringComparison.Ordinal);
			int num2 = ((num < 0) ? (-1) : text.IndexOf(range.EndMarker, num + range.StartMarker.Length, StringComparison.Ordinal));
			if (num >= 0)
			{
				list.Add(new MarkerOccurrence(num, range.StartMarker.Length, isStart: true, range));
			}
			if (num2 >= 0)
			{
				list.Add(new MarkerOccurrence(num2, range.EndMarker.Length, isStart: false, range));
			}
		}
		list.Sort((MarkerOccurrence left, MarkerOccurrence right) => left.Index.CompareTo(right.Index));
		int num3 = 0;
		foreach (MarkerOccurrence item in list)
		{
			int value = item.Index - num3;
			if (item.IsStart)
			{
				item.Range.Start = value;
			}
			else
			{
				item.Range.End = value;
			}
			num3 += item.Length;
		}
		for (int num4 = list.Count - 1; num4 >= 0; num4--)
		{
			MarkerOccurrence markerOccurrence = list[num4];
			builder.Delete(markerOccurrence.Index, markerOccurrence.Index + markerOccurrence.Length);
		}
		foreach (FontSizeRange range2 in ranges)
		{
			if (range2.Start.HasValue && range2.End.HasValue && !(range2.End <= range2.Start))
			{
				int size = Math.Max(1, (int)Math.Round(range2.FontSizeSp * scaledDensity));
				builder.SetSpan(new AbsoluteSizeSpan(size), range2.Start.Value, range2.End.Value, SpanTypes.ExclusiveExclusive);
			}
		}
	}

	private static int FindTagEnd(string html, int startIndex)
	{
		char c = '\0';
		for (int i = startIndex + 1; i < html.Length; i++)
		{
			char c2 = html[i];
			if (c != 0)
			{
				if (c2 == c)
				{
					c = '\0';
				}
				continue;
			}
			switch (c2)
			{
			case '"':
			case '\'':
				c = c2;
				break;
			case '>':
				return i;
			}
		}
		return -1;
	}

	private static int FindTextEnd(string html, int startIndex)
	{
		int num = html.IndexOf('<', startIndex);
		int num2 = html.IndexOf('&', startIndex);
		if (num < 0)
		{
			if (num2 >= 0)
			{
				return num2;
			}
			return html.Length;
		}
		if (num2 < 0)
		{
			return num;
		}
		return Math.Min(num, num2);
	}

	private static bool IsUppercase(Stack<SpanContext> spanContexts)
	{
		if (spanContexts.Count > 0)
		{
			return spanContexts.Peek().Uppercase;
		}
		return false;
	}
}
