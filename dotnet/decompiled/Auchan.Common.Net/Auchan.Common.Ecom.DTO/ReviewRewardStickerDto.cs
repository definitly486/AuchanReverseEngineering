using System;
using Auchan.Common.Ecom.ProducModels;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ReviewRewardStickerDto
{
	[JsonProperty("text")]
	public string? Text { get; init; }

	[JsonProperty("text_color")]
	public string? TextColor { get; init; }

	[JsonProperty("bg_color")]
	public string? BackgroundColor { get; init; }

	[JsonProperty("tooltip_text")]
	public string? TooltipText { get; init; }

	public ReviewRewardSticker? Map()
	{
		string text = Text?.Trim();
		string text2 = NormalizeColor(TextColor);
		string text3 = NormalizeColor(BackgroundColor);
		if (string.IsNullOrEmpty(text) || text2 == null || text3 == null)
		{
			return null;
		}
		return new ReviewRewardSticker(text, text2, text3, TooltipText?.Trim());
	}

	private static string? NormalizeColor(string? value)
	{
		string text = value?.Trim();
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		string text2 = ((text[0] == '#') ? text.Substring(1) : text);
		if (text2.Length != 6 && text2.Length != 8)
		{
			return null;
		}
		string text3 = text2;
		for (int i = 0; i < text3.Length; i++)
		{
			if (!Uri.IsHexDigit(text3[i]))
			{
				return null;
			}
		}
		return "#" + text2;
	}
}
