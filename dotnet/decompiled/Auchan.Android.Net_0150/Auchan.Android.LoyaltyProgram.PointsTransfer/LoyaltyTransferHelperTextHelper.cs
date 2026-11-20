using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using Auchan.Common.Common;
using Java.Lang;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

public static class LoyaltyTransferHelperTextHelper
{
	public static ICharSequence GetFormattedTextWithHighlight(AttributedText attributedText, string inputText)
	{
		if (string.IsNullOrWhiteSpace(attributedText?.Text) || string.IsNullOrWhiteSpace(inputText))
		{
			return new SpannableString(string.Empty);
		}
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(attributedText.Text);
		if (OperatingSystem.IsAndroidVersionAtLeast(28))
		{
			string[] highlights = attributedText.Highlights;
			foreach (string text in highlights)
			{
				int[] array = AllIndexesOf(attributedText.Text, text);
				int length = text.Length;
				int[] array2 = array;
				foreach (int num in array2)
				{
					spannableStringBuilder.SetSpan(new TypefaceSpan(Typeface.DefaultBold), num, num + length, SpanTypes.ExclusiveExclusive);
				}
			}
		}
		else
		{
			spannableStringBuilder.SetSpan(new SpannableString(attributedText.Text), 0, attributedText.Text.Length - 1, SpanTypes.ExclusiveExclusive);
		}
		return SpannableString.ValueOf(spannableStringBuilder);
	}

	private static int[] AllIndexesOf(string str, string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return new int[0];
		}
		List<int> list = new List<int>();
		int startIndex = 0;
		while (true)
		{
			startIndex = str.IndexOf(value, startIndex, StringComparison.Ordinal);
			if (startIndex == -1)
			{
				break;
			}
			list.Add(startIndex);
			startIndex += value.Length;
		}
		return list.ToArray();
	}
}
