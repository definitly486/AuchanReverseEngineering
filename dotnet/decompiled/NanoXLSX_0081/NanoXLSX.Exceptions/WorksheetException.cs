using System;

namespace NanoXLSX.Exceptions;

[Serializable]
public class WorksheetException : Exception
{
	public WorksheetException(string message)
		: base(message)
	{
	}
}
