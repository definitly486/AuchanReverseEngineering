using System;

namespace Splat;

[Serializable]
public class LoggingException : Exception
{
	public LoggingException()
	{
	}

	public LoggingException(string message)
		: base(message)
	{
	}

	public LoggingException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
