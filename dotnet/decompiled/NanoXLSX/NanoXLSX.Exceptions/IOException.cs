using System;

namespace NanoXLSX.Exceptions;

[Serializable]
public class IOException : Exception
{
	public IOException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
