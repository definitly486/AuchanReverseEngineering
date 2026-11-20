namespace System.Diagnostics;

public sealed class UnreachableException : Exception
{
	public UnreachableException()
		: base("Arg_UnreachableException")
	{
	}

	public UnreachableException(string? message)
		: base(message ?? "Arg_UnreachableException")
	{
	}

	public UnreachableException(string? message, Exception? innerException)
		: base(message ?? "Arg_UnreachableException", innerException)
	{
	}
}
