namespace Auchan.Common.Ecom.ProducModels;

public sealed class ReviewRewardSticker
{
	public string Text { get; }

	public string TextColor { get; }

	public string BackgroundColor { get; }

	public string? TooltipText { get; }

	public ReviewRewardSticker(string text, string textColor, string backgroundColor, string? tooltipText)
	{
		Text = text;
		TextColor = textColor;
		BackgroundColor = backgroundColor;
		TooltipText = tooltipText;
	}
}
