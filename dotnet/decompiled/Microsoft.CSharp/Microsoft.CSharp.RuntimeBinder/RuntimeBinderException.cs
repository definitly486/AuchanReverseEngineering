using System;

namespace Microsoft.CSharp.RuntimeBinder;

[Serializable]
public class RuntimeBinderException : Exception
{
	public RuntimeBinderException()
	{
	}

	public RuntimeBinderException(string? message)
		: base(message)
	{
	}

	public RuntimeBinderException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
