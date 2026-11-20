using System;

namespace Java.Interop;

internal sealed class JniLocationException : Exception
{
	private string stackTrace;

	public override string StackTrace => stackTrace;

	public JniLocationException(string stackTrace)
	{
		this.stackTrace = stackTrace;
	}
}
