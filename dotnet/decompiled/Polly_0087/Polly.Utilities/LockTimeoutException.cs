using System;

namespace Polly.Utilities;

internal sealed class LockTimeoutException : Exception
{
	public LockTimeoutException()
		: base("Timeout waiting for lock")
	{
	}

	public LockTimeoutException(string message)
		: base(message)
	{
	}

	public LockTimeoutException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
