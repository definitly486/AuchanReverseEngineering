using System;

namespace NanoXLSX.Exceptions;

[Serializable]
public class FormatException : Exception
{
	public FormatException(string message)
		: base(message)
	{
	}
}
