using System;
using System.Collections.Generic;
using NLog.Conditions;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets;

[NLogConfigurationItem]
public class ConsoleWordHighlightingRule
{
	private string _text = string.Empty;

	public ConditionExpression? Condition { get; set; }

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = (string.IsNullOrEmpty(value) ? string.Empty : value);
		}
	}

	public bool WholeWords { get; set; }

	public bool IgnoreCase { get; set; }

	public ConsoleOutputColor ForegroundColor { get; set; } = ConsoleOutputColor.NoChange;

	public ConsoleOutputColor BackgroundColor { get; set; } = ConsoleOutputColor.NoChange;

	public ConsoleWordHighlightingRule()
	{
	}

	public ConsoleWordHighlightingRule(string text, ConsoleOutputColor foregroundColor, ConsoleOutputColor backgroundColor)
	{
		Text = text;
		ForegroundColor = foregroundColor;
		BackgroundColor = backgroundColor;
	}

	protected internal virtual IEnumerable<KeyValuePair<int, int>>? GetWordsForHighlighting(string haystack)
	{
		if ((object)_text == string.Empty)
		{
			return null;
		}
		int num = FindNextWordForHighlighting(haystack, null);
		if (num < 0)
		{
			return null;
		}
		int num2 = FindNextWordForHighlighting(haystack, num);
		if (num2 < 0)
		{
			return new KeyValuePair<int, int>[1]
			{
				new KeyValuePair<int, int>(num, Text.Length)
			};
		}
		return YieldWordsForHighlighting(haystack, num, num2);
	}

	private IEnumerable<KeyValuePair<int, int>> YieldWordsForHighlighting(string haystack, int firstIndex, int nextIndex)
	{
		yield return new KeyValuePair<int, int>(firstIndex, _text.Length);
		yield return new KeyValuePair<int, int>(nextIndex, _text.Length);
		int index = nextIndex;
		while (index >= 0)
		{
			index = FindNextWordForHighlighting(haystack, index);
			if (index >= 0)
			{
				yield return new KeyValuePair<int, int>(index, _text.Length);
			}
		}
	}

	private int FindNextWordForHighlighting(string haystack, int? prevIndex)
	{
		int num;
		for (num = (prevIndex.HasValue ? (prevIndex.Value + _text.Length) : 0); num >= 0; num += _text.Length)
		{
			num = (IgnoreCase ? haystack.IndexOf(_text, num, StringComparison.CurrentCultureIgnoreCase) : haystack.IndexOf(_text, num));
			if (num < 0 || !WholeWords || StringHelpers.IsWholeWord(haystack, _text, num))
			{
				return num;
			}
		}
		return num;
	}

	internal bool CheckCondition(LogEventInfo logEvent)
	{
		if (Condition != null)
		{
			return true.Equals(Condition.Evaluate(logEvent));
		}
		return true;
	}
}
