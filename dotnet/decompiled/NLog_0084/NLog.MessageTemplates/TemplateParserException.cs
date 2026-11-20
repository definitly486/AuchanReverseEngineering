using System;

namespace NLog.MessageTemplates;

public class TemplateParserException : Exception
{
	public int Index { get; }

	public string Template { get; }

	public TemplateParserException(string message, int index, string template)
		: base(message)
	{
		Index = index;
		Template = template;
	}
}
