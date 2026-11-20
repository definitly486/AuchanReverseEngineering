using System;

namespace NLog.Config;

public sealed class XmlParserException : NLogConfigurationException
{
	public XmlParserException()
	{
	}

	public XmlParserException(string message)
		: base(message)
	{
	}

	public XmlParserException(string message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
