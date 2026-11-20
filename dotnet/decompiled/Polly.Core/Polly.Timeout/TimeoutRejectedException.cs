using System;
using System.Threading;

namespace Polly.Timeout;

public class TimeoutRejectedException : ExecutionRejectedException
{
	public TimeSpan Timeout { get; private set; } = System.Threading.Timeout.InfiniteTimeSpan;

	public TimeoutRejectedException()
		: base("The operation didn't complete within the allowed timeout.")
	{
	}

	public TimeoutRejectedException(string message)
		: base(message)
	{
	}

	public TimeoutRejectedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public TimeoutRejectedException(TimeSpan timeout)
		: base("The operation didn't complete within the allowed timeout.")
	{
		Timeout = timeout;
	}

	public TimeoutRejectedException(string message, TimeSpan timeout)
		: base(message)
	{
		Timeout = timeout;
	}

	public TimeoutRejectedException(string message, TimeSpan timeout, Exception innerException)
		: base(message, innerException)
	{
		Timeout = timeout;
	}
}
