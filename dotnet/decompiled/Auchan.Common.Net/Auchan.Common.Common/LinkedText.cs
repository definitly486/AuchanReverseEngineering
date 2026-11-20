using System;
using Auchan.Common.Extensions;

namespace Auchan.Common.Common;

public sealed class LinkedText
{
	public string Text { get; }

	public string[] Highlights { get; }

	public Action[] Actions { get; }

	public LinkedText(string text)
		: this(text, Array.Empty<string>(), Array.Empty<Action>())
	{
	}

	public LinkedText(string text, string highlight, Action action)
		: this(text, new string[1] { highlight }, new Action[1] { action })
	{
	}

	public LinkedText(string text, string[] highlights, Action[] actions)
	{
		if (highlights == null)
		{
			highlights = Array.Empty<string>();
		}
		if (actions == null)
		{
			actions = Array.Empty<Action>();
		}
		if (highlights.Length != actions.Length)
		{
			throw new ArgumentException("Unequal number of links and actions");
		}
		object[] args = highlights;
		Text = string.Format(text, args);
		Highlights = highlights;
		Actions = actions;
	}

	public override string ToString()
	{
		return Text;
	}

	public static LinkedText FromTextWithHref(string html, Action action)
	{
		var (text, highlight, _) = ExtractHtmlParts(html);
		return new LinkedText(text, highlight, action);
	}

	public static LinkedText FromTextWithHref(string html, Action<string> action)
	{
		var (text, highlight, link) = ExtractHtmlParts(html);
		return new LinkedText(text, highlight, delegate
		{
			action(link);
		});
	}

	public static (string Text, string Hightlight, string Link) ExtractHtmlParts(string html)
	{
		if (!html.ContainsIgnoreCase("<p>") && !html.ContainsIgnoreCase("</p>"))
		{
			html = "<p>" + html + "</p>";
		}
		if (html.ContainsIgnoreCase("</a>"))
		{
			string item = html.Substring("<p>", "<a href") + html.Substring("\">", "</a>") + html.Substring("</a>", "</p>");
			string item2 = html.Substring("\">", "</a>");
			string item3 = html.Substring("<a href=\"", "\">");
			return (Text: item, Hightlight: item2, Link: item3);
		}
		return (Text: html.Substring("<p>", "</p>"), Hightlight: "", Link: "");
	}
}
