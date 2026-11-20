using System;

namespace NanoXLSX.Exceptions;

[Serializable]
public class RangeException : Exception
{
	public RangeException(string message)
		: base(message)
	{
	}
}
