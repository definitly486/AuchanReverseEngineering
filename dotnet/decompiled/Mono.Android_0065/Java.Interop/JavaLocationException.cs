using System;

namespace Java.Interop;

internal class JavaLocationException : Exception
{
	private string stackTrace;

	public override string StackTrace => stackTrace;

	public JavaLocationException(string stackTrace)
	{
		this.stackTrace = stackTrace;
	}
}
