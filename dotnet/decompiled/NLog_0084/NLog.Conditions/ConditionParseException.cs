using System;

namespace NLog.Conditions;

public class ConditionParseException : Exception
{
	public ConditionParseException()
	{
	}

	public ConditionParseException(string message)
		: base(message)
	{
	}

	public ConditionParseException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
