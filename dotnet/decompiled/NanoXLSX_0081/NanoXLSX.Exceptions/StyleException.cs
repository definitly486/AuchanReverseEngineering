using System;

namespace NanoXLSX.Exceptions;

[Serializable]
public class StyleException : Exception
{
	public StyleException(string message)
		: base(message)
	{
	}
}
