using System;

namespace Auchan.Common.Common;

public class AttributedText
{
	public string Text { get; }

	public string[] Highlights { get; }

	public AttributedText(string text, params string[]? highlights)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new ArgumentException("text");
		}
		if (highlights == null)
		{
			highlights = Array.Empty<string>();
		}
		string text2;
		if (highlights.Length == 0)
		{
			text2 = text;
		}
		else
		{
			object[] args = highlights;
			text2 = string.Format(text, args);
		}
		Text = text2;
		Highlights = highlights;
	}

	public override string ToString()
	{
		return Text;
	}
}
